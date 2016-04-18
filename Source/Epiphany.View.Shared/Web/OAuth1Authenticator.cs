using Epiphany.Web;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace Epiphany.Web
{
    /// <summary>
    /// OAuth1 authenticator implementation
    /// </summary>
    public sealed class OAuth1Authenticator : IAuthenticator
    {
        private readonly string consumerKey;
        private readonly string consumerKeySecret;
        private readonly string token;
        private readonly string tokenSecret;
        /// <summary>
        /// Create an instance of OAuthAuthenticator mostly for request tokens
        /// </summary>
        /// <param name="consumerKey">consumer api key</param>
        /// <param name="consumerKeySecret">api key secret</param>
        public OAuth1Authenticator(string consumerKey, string consumerKeySecret)
        {
            this.consumerKey = consumerKey;
            this.consumerKeySecret = consumerKeySecret;
        }
        /// <summary>
        /// Create an instance of OAuth1Authenticator for use with existing tokens
        /// </summary>
        /// <param name="consumerKey">api key</param>
        /// <param name="consumerKeySecret">api key secret</param>
        /// <param name="token">token</param>
        /// <param name="tokenSecret">token secret</param>
        public OAuth1Authenticator(string consumerKey, string consumerKeySecret,
            string token, string tokenSecret)
        {
            this.consumerKey = consumerKey;
            this.consumerKeySecret = consumerKeySecret;
            this.token = token;
            this.tokenSecret = tokenSecret;
        }
        /// <summary>
        /// Authenticate the request with oauth 1.0
        /// </summary>
        /// <param name="request"></param>
        public void Authenticate(WebRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            string url = request.Url;

            // Just get the base url
            int queryStringStart = url.IndexOf('?');
            if (queryStringStart != -1)
            {
                url = url.Substring(0, queryStringStart);
            }
            
            // Create a sorted dictionary for holding parameters
            IDictionary<string, string> parameters = new SortedDictionary<string, string>();
            
            // Copy all parameters from the request
            foreach (var parameter in request.Parameters)
            {
                parameters.Add(parameter);
            }

            // Get oauth parameters
            foreach (var parameter in GetOAuthParameters(consumerKey))
            {
                parameters.Add(parameter);
            }

            StringBuilder signatureUrlBuilder = new StringBuilder();
            signatureUrlBuilder.AppendFormat("{0}&", request.Method.ToString().ToUpperInvariant());
            signatureUrlBuilder.AppendFormat("{0}&", Uri.EscapeDataString(url));
            signatureUrlBuilder.Append(Uri.EscapeDataString(NormalizeParameters(parameters)));

            string signatureUrl = signatureUrlBuilder.ToString();
            string signature = GetSignature(signatureUrl, this.consumerKeySecret, this.tokenSecret);
            signature = Uri.EscapeDataString(signature);
            parameters.Add("oauth_signature", signature);

            // Now that we have the signature, form the authorization header and add it to the request
            StringBuilder authHeaderBuilder = new StringBuilder();
            authHeaderBuilder.Append("OAuth ");

            foreach (var parameter in parameters)
            {
                if (parameter.Key.StartsWith("oauth_"))
                {
                    authHeaderBuilder.AppendFormat("{0}=\"{1}\",", parameter.Key, parameter.Value);
                }
            }

            // Remove the last comma
            authHeaderBuilder.Remove(authHeaderBuilder.Length - 1, 1);

            // Add authorization header to request
            request.Headers["Authorization"] = authHeaderBuilder.ToString();
        }

        /// <summary>
        /// Gets all the oauth parameters
        /// </summary>
        /// <param name="apiKey">api key</param>
        /// <returns></returns>
        private IDictionary<string, string> GetOAuthParameters(string apiKey)
        {
            Random random = new Random();
            DateTime date = new DateTime(1970,1,1,0,0,0,DateTimeKind.Utc);
            TimeSpan timespan = DateTime.UtcNow - date;
            string oauthTimestamp = timespan.TotalSeconds.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
            string oauthNonce = random.Next(1000).ToString();

            var parameters = new SortedDictionary<string, string>();
            parameters.Add("oauth_nonce", oauthNonce);
            parameters.Add("oauth_timestamp", oauthTimestamp);
            parameters.Add("oauth_consumer_key", apiKey);
            parameters.Add("oauth_signature_method", "HMAC-SHA1");
            parameters.Add("oauth_version", "1.0");

            if (!string.IsNullOrEmpty(this.token))
            {
                parameters.Add("oauth_token", this.token);
            }

            return parameters;
        }
        /// <summary>
        /// Get signature for getting the first token url
        /// </summary>
        /// <param name="url"></param>
        /// <param name="consumerSecret"></param>
        /// <returns></returns>
        private string GetSignature(string url, string consumerSecret)
        {
            return GetSignature(url, consumerSecret, string.Empty);
        }
        /// <summary>
        /// Gets signature by using the token secret as a part of the key
        /// </summary>
        /// <param name="url"></param>
        /// <param name="consumerSecret"></param>
        /// <param name="token"></param>
        /// <param name="tokenSecret"></param>
        /// <returns></returns>
        private string GetSignature(string url, string consumerSecret, string tokenSecret)
        {
            //calculating the signature 
            MacAlgorithmProvider HmacSha1Provider = MacAlgorithmProvider.OpenAlgorithm("HMAC_SHA1");
            string key = string.Format("{0}&{1}", consumerSecret, tokenSecret);
            IBuffer keyBuffer = CryptographicBuffer.ConvertStringToBinary(key, BinaryStringEncoding.Utf8);

            CryptographicKey cryptoKey = HmacSha1Provider.CreateKey(keyBuffer);
            IBuffer urlBuffer = CryptographicBuffer.ConvertStringToBinary(url, BinaryStringEncoding.Utf8);

            string signature = CryptographicBuffer.EncodeToBase64String(CryptographicEngine.Sign(cryptoKey, urlBuffer));
            return signature;
        }

        private string NormalizeParameters(IDictionary<string, string> parameters)
        {
            StringBuilder paramBuilder = new StringBuilder();
            string separator = "=";
            string spacer = "&";
            int total = parameters.Count;
            int count = 0;

            foreach (var parameter in parameters)
            {
                paramBuilder.Append(parameter.Key);
                paramBuilder.Append(separator);
                paramBuilder.Append(Uri.EscapeDataString(parameter.Value));

                count++;

                if (count < total)
                {
                    paramBuilder.Append(spacer);
                }
            }

            return paramBuilder.ToString();
        }
    }
}
