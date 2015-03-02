using System;
using System.Net;

namespace Epiphany.Model.Authentication
{
    /// <summary>
    /// Represents configuration properties for authentication
    /// </summary>
    public class AuthConfig
    {
        private string consumerKey;
        private string consumerKeySecret;
        private Uri baseUri;
        private Uri requestTokenUri;
        private Uri authorizeUri;
        private Uri accessTokenUri;
        private Uri callbackUri;
        /// <summary>
        /// Creates an instance of Auth Config
        /// </summary>
        /// <param name="consumerKey">Consumer Key</param>
        /// <param name="consumerKeySecret">Consumer Key Secret</param>
        /// <param name="requestTokenUri">RequestToken Uri</param>
        /// <param name="authorizeUri">Authorize Uri</param>
        /// <param name="accessTokenUri">Access AuthToken Uri</param>
        /// <param name="callbackUri">Callback Uri</param>
        public AuthConfig(string consumerKey, string consumerKeySecret, Uri baseUri,
            Uri requestTokenUri, Uri authorizeUri, Uri accessTokenUri,
            Uri callbackUri = null)
        {
            if (string.IsNullOrEmpty(consumerKey))
                throw new ArgumentNullException("consumerKey", "Consumer Key cannot be null");
            if (string.IsNullOrEmpty(consumerKeySecret))
                throw new ArgumentNullException("consumerKeySecret", "Consumer key secret cannot be null");
            if (baseUri == null)
                throw new ArgumentNullException("baseUri", "Base uri cannot be null");
            if (requestTokenUri == null)
                throw new ArgumentNullException("requestTokenUri", "Request token uri cannot be null");
            if (authorizeUri == null)
                throw new ArgumentNullException("authorizeUri", "Authorize uri cannot be null");
            if (accessTokenUri == null)
                throw new ArgumentNullException("accessTokenUri", "Access token uri cannot be null");

            this.consumerKey = consumerKey;
            this.consumerKeySecret = consumerKeySecret;
            this.baseUri = baseUri;
            this.requestTokenUri = requestTokenUri;
            this.authorizeUri = authorizeUri;
            this.accessTokenUri = accessTokenUri;
            if (callbackUri != null)
                this.callbackUri = callbackUri;
        }

        public AuthConfig()
        {
            this.consumerKey = "fDfi6rdiIgfTp49R0xj8MQ";
            this.consumerKeySecret = "xWMNPMCpx7Xu6SRa794vP8BZ1d9muqNVsYnCucPiQ";
            this.baseUri = new Uri("http://www.goodreads.com");
            this.requestTokenUri = new Uri("http://www.goodreads.com/oauth/request_token");
            this.authorizeUri = new Uri("http://www.goodreads.com/oauth/authorize");
            this.accessTokenUri = new Uri("http://www.goodreads.com/oauth/access_token");
            this.callbackUri = new Uri("http://myepiphanyapp.com/goodreads_oauth_callback");
        }
        /// <summary>
        /// Gets the consumer key
        /// </summary>
        public string ConsumerKey
        {
            get { return this.consumerKey; }
        }
        /// <summary>
        /// Gets the consumer key secret
        /// </summary>
        public string ConsumerKeySecret
        {
            get { return this.consumerKeySecret; }
        }
        /// <summary>
        /// Gets the uri to request author temporary token
        /// </summary>
        public Uri RequestTokenUri
        {
            get { return this.requestTokenUri; }
        }
        /// <summary>
        /// Gets the uri to authorize
        /// </summary>
        public Uri AuthorizeUri
        {
            get { return this.authorizeUri; }
        }
        /// <summary>
        /// Gets the uri to request author permanent token
        /// </summary>
        public Uri AccessTokenUri
        {
            get { return this.accessTokenUri; }
        }
        /// <summary>
        /// Gets the callback uri
        /// </summary>
        public Uri CallbackUri
        {
            get { return this.callbackUri; }
        }

        public Uri BaseUri
        {
            get { return this.baseUri; }
        }
    }
}
