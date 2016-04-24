using Epiphany.Logging;
using Epiphany.Model.Authentication;
using Epiphany.Model.Messaging;
using Epiphany.Model.Settings;
using Epiphany.Web;
using Epiphany.Xml;
using System;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    /// <summary>
    /// Represents the logon service that presides over login and authentication
    /// </summary>
    class LogonService : ILogonService
    {
        private readonly IWebClient webClient;
        private readonly IMessenger messenger;

        private LogonState state;
        private Session session;
        private AuthConfig authConfig;

        private Token temporaryToken;
        private Token permanentToken;
        private Credential credential;
        /// <summary>
        /// Create an instance of LogonService
        /// </summary>
        /// <param name="webClient">Web client</param>
        /// <param name="messenger">messenger</param>
        public LogonService(IWebClient webClient, IMessenger messenger)
        {
            if (webClient == null || messenger == null)
            {
                throw new ArgumentNullException(nameof(webClient));
            }

            this.webClient = webClient;
            this.messenger = messenger;
            this.authConfig = new AuthConfig();
            State = LogonState.NotConnected;

            // Rehydrate the session if token and credentials are already available
            RehydrateSession();

        }
        /// <summary>
        /// Gets the configuration
        /// </summary>
        public AuthConfig Configuration
        {
            get
            {
                return this.authConfig;
            }
        }
        /// <summary>
        /// Gets the current session
        /// </summary>
        public Session Session
        {
            get
            {
                return this.session;
            }
            private set
            {
                if (this.session == value) return;
                this.session = value;
                
                // Send a message for listeners
                SessionChangedMessage msg = new SessionChangedMessage(this, this.session);
                this.messenger.SendMessage<SessionChangedMessage>(this, msg);
                RaiseSessionChanged(session);
            }
        }
        /// <summary>
        /// Gets the current logon state
        /// </summary>
        public LogonState State
        {
            get
            {
                return this.state;
            }
            private set
            {
                if (this.state == value) return;
                this.state = value;
            }
        }
        /// <summary>
        /// Gets the current token
        /// </summary>
        public Token ActiveToken
        {
            get
            {
                Token token = null;
                if (this.permanentToken != null)
                {
                    token = this.permanentToken;
                }
                else if (this.temporaryToken != null)
                {
                    token = this.temporaryToken;
                }

                return token;
            }
        }

        /// <summary>
        /// Verifies if we are logged in already. True if we are logged in, False otherwise
        /// </summary>
        /// <returns></returns>
        public async Task<bool> TryVerifyLogin()
        {
            bool result = false;

            if (this.permanentToken == null)
            {
                Logger.LogError("No token is available");
                return result;
            }

            try
            {
                Uri authUserUri = new Uri(Configuration.SecureBaseUri, ServiceUrls.AuthUserUrl);
                WebRequest request = new WebRequest(authUserUri.ToString(), WebMethod.Get);
                request.Authenticate = true;

                var webResponse = await this.webClient.ExecuteAsync(request);
                webResponse.Validate(System.Net.HttpStatusCode.OK, true);

                // Parse the response and extract the user id
                var authUserResponse = Parser.GetAuthUserResponse(webResponse.Content);
                int id = int.Parse(authUserResponse.AuthenticatedUser.Id);
                this.credential = new Credential(authUserResponse.AuthenticatedUser.Name, id);

                // Store the token and credential
                StoreToken(this.permanentToken);
                StoreCredential(this.credential);
                Session = new Session(credential, permanentToken);
                State = LogonState.Connected;
                result = true;
            }
            catch (Exception ex)
            {
                Logger.LogWarn(ex.ToString());
                result = false;
            }

            return result;
        }
        /// <summary>
        /// Starts the login process
        /// </summary>
        /// <returns></returns>
        public async Task<Uri> StartLogin()
        {
            Logger.LogDebug("Requesting temporary token");
            State = LogonState.Connecting;

            WebRequest request = new WebRequest(Configuration.RequestTokenUri.ToString(), WebMethod.Get);
            request.Authenticate = true;

            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.OK, true);

            TokenParser parser = new TokenParser();
            if (!parser.TryParseTokens(response.Content, out this.temporaryToken))
            {
                Logger.LogError("Parsing tokens failed");
                throw new ModelException(ModelExceptionType.ParseError);
            }

            // Temporary token is available
            RaiseTokenChanged(null, this.temporaryToken);

            Uri authorizeUri = GetAuthorizeUri();
            Logger.LogInfo("Authorize Uri = " + authorizeUri.ToString());

            return authorizeUri;
        }
        /// <summary>
        /// After user has authenticated for oauth, complete the login process by fetching permanent tokens
        /// </summary>
        /// <returns></returns>
        public async Task FinishLogin()
        {
            // Request for permanent tokens and create the session
            if (this.state == LogonState.NotConnected)
            {
                Logger.LogError("State is not Connected. It should be Connecting!");
                throw new ModelException(ModelExceptionType.NoTokens);
            }

            if (this.temporaryToken == null)
            {
                Logger.LogError("Request tokens are not available");
                throw new ModelException(ModelExceptionType.NoTokens);
            }

            Logger.LogDebug("Requesting for permanent tokens");

            WebRequest request = new WebRequest(Configuration.AccessTokenUri.ToString(), WebMethod.Get);
            request.Authenticate = true;

            var webResponse = await this.webClient.ExecuteAsync(request);
            webResponse.Validate(System.Net.HttpStatusCode.OK, true);

            TokenParser parser = new TokenParser();
            if (!parser.TryParseTokens(webResponse.Content, out this.permanentToken))
            {
                Logger.LogError("Server did not return tokens");
                throw new ModelException(ModelExceptionType.EmptyServerResponse);
            }

            // We have the access token
            RaiseTokenChanged(this.temporaryToken, this.permanentToken);

            // Let's just verify login again as this will fetch credentials
            if (!await TryVerifyLogin())
            {
                Logger.LogInfo("Login failed");
                this.temporaryToken = null;
                this.permanentToken = null;
                this.credential = null;
                Session = null;
                State = LogonState.NotConnected;
            }
        }

        public async Task Logout()
        {
            if (this.permanentToken == null)
            {
                Logger.LogError("No token available");
                throw new ModelException(ModelExceptionType.NoTokens);
            }

            Uri uri = new Uri(Configuration.SecureBaseUri, "api/sign_out");

            WebRequest request = new WebRequest(uri.ToString(), WebMethod.Post);
            request.Authenticate = true;

            var webResponse = await this.webClient.ExecuteAsync(request);
            webResponse.Validate(System.Net.HttpStatusCode.OK);

            this.state = LogonState.NotConnected;
            Session = null;
            Logger.LogInfo(this.state.ToString());
            
        }
        /// <summary>
        /// Event that is raised when the session changes
        /// </summary>
        public event EventHandler<SessionChangedEventArgs> SessionChanged;
        protected void RaiseSessionChanged(Session session) =>
            SessionChanged?.Invoke(this, new SessionChangedEventArgs(session));
        /// <summary>
        /// Event that is raised when the token changes
        /// </summary>
        public event EventHandler<TokenChangedEventArgs> TokenChanged;
        protected void RaiseTokenChanged(Token oldToken, Token newToken) =>
            TokenChanged?.Invoke(this, new TokenChangedEventArgs(newToken, oldToken));
        /// <summary>
        /// Get the full authorize uri after the request tokens have been fetched
        /// </summary>
        /// <returns></returns>
        private Uri GetAuthorizeUri()
        {
            if (this.temporaryToken == null)
            {
                Logger.LogError("Request token is not available");
                throw new ModelException(ModelExceptionType.NoTokens);
            }

            // Let's use the web request to add parameters to the url
            Uri uri = new Uri(Configuration.SecureBaseUri, "oauth/authorize");
            WebRequest request = new WebRequest(uri.ToString(), WebMethod.Get);

            request.Parameters["oauth_token"] = temporaryToken.AuthToken;
            request.Parameters["oauth_callback"] = Configuration.CallbackUri.ToString();
            request.Parameters["mobile"] = "1";

            return new Uri(request.Url, UriKind.Absolute);
        }

        private void RehydrateSession()
        {
            // Read token
            string accessToken = ApplicationSettings.Instance.AccessToken;
            if (string.IsNullOrEmpty(accessToken))
            {
                Logger.LogDebug("No previous token to rehydrate");
                return;
            }

            string accessTokenSecret = ApplicationSettings.Instance.AccessTokenSecret;
            if (string.IsNullOrEmpty(accessTokenSecret))
            {
                Logger.LogDebug("No token secret found");
                return;
            }

            // Create the permanent token
            this.permanentToken = new Token(accessToken, accessTokenSecret);

            // Read credentials
            string username = ApplicationSettings.Instance.CurrentUsername;
            if (string.IsNullOrEmpty(username))
            {
                Logger.LogDebug("No username found in cache");
                return;
            }

            int userid = ApplicationSettings.Instance.CurrentUserId;
            if (userid == -1)
            {
                Logger.LogDebug("No userid found in cache");
                return;
            }

            this.credential = new Credential(username, userid);
            Session = new Session(credential, permanentToken);
            State = LogonState.Connected;
        }

        private void StoreToken(Token token)
        {
            ApplicationSettings.Instance.AccessToken = token.AuthToken;
            ApplicationSettings.Instance.AccessTokenSecret = token.TokenSecret;
        }

        private void StoreCredential(Credential credential)
        {
            ApplicationSettings.Instance.CurrentUserId = credential.UserId;
            ApplicationSettings.Instance.CurrentUsername = credential.Name;
        }
    }
}
