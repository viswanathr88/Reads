using Epiphany.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epiphany.Model;
using Epiphany.Model.Authentication;
using Epiphany.Web;
using Windows.Storage.Streams;
using Windows.Security.Cryptography.Core;
using Windows.Security.Cryptography;
using System.Net;
using System.IO;
using Epiphany.Logging;
using System.Net.Http;
using Epiphany.Model.Settings;

namespace Epiphany.Web
{
    public sealed class OAuth1Authenticator2 : IAuthService
    {
        private readonly AuthConfig config = new AuthConfig();
        private readonly TokenParser tokenParser;
        private Token temporaryToken;
        private Token permanentToken;
        private Credential cachedCredential;

        public OAuth1Authenticator2()
        {
            this.tokenParser = new TokenParser();
            this.permanentToken = ReadTokensFromStorage();

            if (this.permanentToken != null)
            {
                // Read credentials from storage only if we have a token
                this.cachedCredential = ReadCredentialFromStorage();
            }
        }

        public AuthConfig Configuration
        {
            get
            {
                return this.config;
            }
        }

        public bool IsCachedCredentialAvailable
        {
            get
            {
                return (this.cachedCredential != null);
            }
        }

        public bool IsCachedTokenAvailable
        {
            get
            {
                return (this.permanentToken != null);
            }
        }

        public IWebClient GetAuthCapableWebClient()
        {
            //IWebClient client = new WebClient(this);
            return null;
        }

        public Credential GetCachedCredential()
        {
            return this.cachedCredential;
        }

        public Token GetCachedToken()
        {
            return this.permanentToken;
        }

        public async Task RequestTemporaryToken()
        {
            IDictionary<string, string> parameters = GetOAuthParameters(config.ConsumerKey);
            string signedUrl = CalculateOAuthSignedUrl(parameters, config.RequestTokenUri.ToString(), config.ConsumerKeySecret, string.Empty, false);

            HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create(signedUrl);
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            string content = string.Empty;
            if (response != null)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    content = reader.ReadToEnd();
                }
            }

            if (!string.IsNullOrEmpty(content))
            {
                this.tokenParser.TryParseTokens(content, out this.temporaryToken);
            }
        }

        public Uri GetAuthorizeUri()
        {
            if (this.temporaryToken == null)
            {
                Logger.LogError("Request token is not available!");
                throw new ModelException(ModelExceptionType.NoTokens);
            }

            if (Configuration.AuthorizeUri == null)
            {
                Logger.LogError("AuthorizeUri is null");
                throw new ModelException(ModelExceptionType.UnexpectedError);
            }

            // Create a Uri builder for the auth url
            UriBuilder builder = new UriBuilder(Configuration.AuthorizeUri);

            // Create encoded parameters
            using (var urlEncodedContant = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("oauth_token", this.temporaryToken.AuthToken),
                new KeyValuePair<string, string>("oauth_callback", this.Configuration.CallbackUri.ToString()),
                new KeyValuePair<string, string>("mobile", "1")
            }))
            {
                builder.Query = urlEncodedContant.ReadAsStringAsync().Result;
            }

            // return the new uri from the builder
            return builder.Uri;
        }

        public async Task<Token> GetToken()
        {
            if (permanentToken != null)
            {
                Logger.LogDebug("Returning cached token");
                return this.permanentToken;
            }

            if (temporaryToken == null)
            {
                Logger.LogError("Request token is not available!");
                throw new ModelException(ModelExceptionType.NoTokens);
            }

            IDictionary<string, string> parameters = GetOAuthParameters(config.ConsumerKey);
            parameters.Add("oauth_token", this.temporaryToken.AuthToken);
            string signedUrl = CalculateOAuthSignedUrl(parameters, Configuration.AccessTokenUri.ToString(), Configuration.ConsumerKeySecret, this.temporaryToken.TokenSecret, true);

            HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create(signedUrl);
            request.Method = "GET";

            string content = string.Empty;
            try
            {
                HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
                if (response == null)
                {
                    Logger.LogError("HttpWebResponse is null!");
                    throw new ModelException(ModelExceptionType.UnexpectedError);
                }

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    Logger.LogError("Response returned " + response.StatusCode);
                    throw new ModelException(ModelExceptionType.ServerUnreachable);
                }

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    content = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                throw new ModelException(ModelExceptionType.NoTokens);
            }

            if (string.IsNullOrEmpty(content))
            {
                Logger.LogError("Content is null");
                throw new ModelException(ModelExceptionType.EmptyServerResponse);
            }

            if (!this.tokenParser.TryParseTokens(content, out this.permanentToken))
            {
                Logger.LogError("TryParseTokens failed to parse!");
                throw new ModelException(ModelExceptionType.ParseError);
            }
            else
            {
                WriteTokenToStorage(this.permanentToken);
                this.temporaryToken = null;
            }

            return this.permanentToken;
        }

        public async Task<Credential> GetCredentialAsync()
        {
            if (this.permanentToken == null)
            {
                throw new ModelException(ModelExceptionType.NoTokens);
            }

            string url = @"https://www.goodreads.com/api/auth_user";

            IDictionary<string, string> parameters = GetOAuthParameters(config.ConsumerKey);
            parameters.Add("oauth_token", this.permanentToken.AuthToken);
            string signedUrl = CalculateOAuthSignedUrl(parameters, url, Configuration.ConsumerKeySecret, this.permanentToken.TokenSecret, true);

            HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create(signedUrl);
            request.Method = "GET";

            string content = string.Empty;
            try
            {
                HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
                if (response == null)
                {
                    Logger.LogError("HttpWebResponse is null!");
                    throw new ModelException(ModelExceptionType.UnexpectedError);
                }

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    Logger.LogError("Response returned " + response.StatusCode);
                    throw new ModelException(ModelExceptionType.ServerUnreachable);
                }

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    content = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                throw new ModelException(ModelExceptionType.NoTokens);
            }

            if (string.IsNullOrEmpty(content))
            {
                Logger.LogError("Content is null");
                throw new ModelException(ModelExceptionType.EmptyServerResponse);
            }

            return null;
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        private Token ReadTokensFromStorage()
        {
            Token accessToken = null;
            string token = ApplicationSettings.Instance.AccessToken;

            if (!string.IsNullOrEmpty(token))
            {
                // Read the secret only if token is valid
                string tokenSecret = ApplicationSettings.Instance.AccessTokenSecret;
                if (!string.IsNullOrEmpty(tokenSecret))
                {
                    accessToken = new Token(token, tokenSecret);
                }
            }

            return accessToken;
        }

        private Credential ReadCredentialFromStorage()
        {
            Credential credential = null;

            int id = ApplicationSettings.Instance.CurrentUserId;
            string name = ApplicationSettings.Instance.CurrentUsername;

            if (id != -1 && !string.IsNullOrEmpty(name))
            {
                credential = new Credential(name, id);
            }

            return credential;
        }

        private void WriteTokenToStorage(Token token)
        {
            ApplicationSettings.Instance.AccessToken = token.AuthToken;
            ApplicationSettings.Instance.AccessTokenSecret = token.TokenSecret;
        }

        private void WriteCredentialToDisk(Credential credential)
        {
            ApplicationSettings.Instance.CurrentUserId = credential.UserId;
            ApplicationSettings.Instance.CurrentUsername = credential.Name;
        }

        private SortedDictionary<string, string> GetOAuthParameters(string apiKey)
        {
            Random random = new Random();
            DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timespan = DateTime.UtcNow - date;
            string oauthTimestamp = timespan.TotalSeconds.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
            string oauthNonce = random.Next(1000).ToString();

            var parameters = new SortedDictionary<string, string>();
            parameters.Add("oauth_nonce", oauthNonce);
            parameters.Add("oauth_timestamp", oauthTimestamp);
            parameters.Add("oauth_consumer_key", apiKey);
            parameters.Add("oauth_signature_method", "HMAC-SHA1");
            parameters.Add("oauth_version", "1.0");

            return parameters;
        }

        public string CalculateOAuthSignedUrl(IDictionary<string, string> parameters, string url, string secret, string tokenSecret, bool toggle)
        {
            StringBuilder baseString = new StringBuilder();
            string str;
            IBuffer keyMaterial;

            foreach (var param in parameters)
            {
                baseString.Append(param.Key);
                baseString.Append("=");
                baseString.Append(Uri.EscapeDataString(param.Value));
                baseString.Append("&");
            }

            //removing the extra ampersand 
            baseString.Remove(baseString.Length - 1, 1);
            str = "GET&" + Uri.EscapeDataString(url) + "&" + Uri.EscapeDataString(baseString.ToString());

            //calculating the signature 
            MacAlgorithmProvider HmacSha1Provider = MacAlgorithmProvider.OpenAlgorithm("HMAC_SHA1");

            if (toggle)
            {
                keyMaterial = CryptographicBuffer.ConvertStringToBinary(secret + "&" + tokenSecret, BinaryStringEncoding.Utf8);
            }
            else
            {
                keyMaterial = CryptographicBuffer.ConvertStringToBinary(secret + "&", BinaryStringEncoding.Utf8);
            }

            CryptographicKey cryptoKey = HmacSha1Provider.CreateKey(keyMaterial);
            IBuffer dataString = CryptographicBuffer.ConvertStringToBinary(str, BinaryStringEncoding.Utf8);

            return url + "?" + baseString.ToString() + "&oauth_signature=" + Uri.EscapeDataString(CryptographicBuffer.EncodeToBase64String(CryptographicEngine.Sign(cryptoKey, dataString)));
        }

    }
}
