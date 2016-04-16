using Epiphany.Model;
using Epiphany.Model.Authentication;
using Epiphany.Model.Services;
using Epiphany.Model.Settings;
using Epiphany.Model.Web;
using RestSharp.Portable;
using RestSharp.Portable.Authenticators;
using RestSharp.Portable.HttpClient;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Epiphany.Web
{
    public class AuthService : IAuthService
    {
        private readonly AuthConfig config = new AuthConfig();
        private readonly RestClient restClient;
        private readonly TokenParser tokenParser;
        private Token temporaryToken;
        private Token permanentToken;
        private Credential cachedCredential;

        public AuthService()
        {
            this.restClient = new RestClient(config.BaseUri.ToString());
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

        public async Task RequestTemporaryToken()
        {
            restClient.Authenticator = OAuth1Authenticator.ForRequestToken(config.ConsumerKey, config.ConsumerKeySecret);
            var request = new RestRequest("oauth/request_token", Method.GET);
            var response = await this.restClient.ExecuteAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new ModelException(ModelExceptionType.NoTokens);
            
            if (!this.tokenParser.TryParseTokens(response.GetContent(), out this.temporaryToken))
            {
                if (string.IsNullOrEmpty(response.GetContent()))
                    throw new ModelException(ModelExceptionType.NoTokens);
            }
        }

        public async Task<Token> GetToken()
        {
            if (permanentToken != null)
            {
                return this.permanentToken;
            }
            if (temporaryToken == null)
            {
                return null;
            }

            var request = new RestRequest("oauth/access_token", Method.GET);
            this.restClient.Authenticator = OAuth1Authenticator.ForAccessToken(config.ConsumerKey, config.ConsumerKeySecret, 
                temporaryToken.AuthToken, temporaryToken.TokenSecret, string.Empty);
            var response = await this.restClient.ExecuteAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ModelException(ModelExceptionType.NoTokens);
            }

            if (!this.tokenParser.TryParseTokens(response.GetContent(), out this.permanentToken))
            {
                throw new ModelException(ModelExceptionType.NoTokens);
            }
            else
            {
                WriteTokenToStorage(this.permanentToken);
                this.temporaryToken = null;
            }
            return this.permanentToken;
        }

        public Uri GetAuthorizeUri()
        {
            if (this.temporaryToken == null)
                throw new ModelException(ModelExceptionType.NoTokens);

            var request = new RestRequest("oauth/authorize");
            request.AddParameter("oauth_token", temporaryToken.AuthToken);
            request.AddParameter("oauth_callback", Configuration.CallbackUri);
            request.AddParameter("mobile", 1);

            var url = this.restClient.BuildUri(request);
            return url;
        }

        public async Task<Credential> GetCredentialAsync()
        {
            if (this.permanentToken == null)
            {
                throw new ModelException(ModelExceptionType.NoTokens);
            }

            var request = new RestRequest("api/auth_user", Method.GET);
            this.restClient.Authenticator = OAuth1Authenticator.ForProtectedResource(config.ConsumerKey, 
                config.ConsumerKeySecret, permanentToken.AuthToken, permanentToken.TokenSecret);
            var response = await this.restClient.ExecuteAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK || string.IsNullOrEmpty(response.GetContent()))
            {
                throw new ModelException(ModelExceptionType.NoUserId);
            }

            Credential credential = null;
            try
            {
                XDocument document = XDocument.Parse(response.GetContent());
                XElement responseElement = document.Element("GoodreadsResponse");
                int id = int.Parse((string)responseElement.Element("user").Attribute("id"));
                string name = (string)responseElement.Element("user").Element("name");
                credential = new Credential(name, id);
            }
            catch (Exception)
            {
                throw new ModelException(ModelExceptionType.NoUserId);
            }
            WriteCredentialToDisk(credential);
            this.cachedCredential = credential;
            return credential;
        }

        public async Task Logout()
        {
            if (this.permanentToken == null)
                return;

            var request = new RestRequest("api/sign_out", Method.POST);
            this.restClient.Authenticator = OAuth1Authenticator.ForProtectedResource(config.ConsumerKey,
                config.ConsumerKeySecret, permanentToken.AuthToken, permanentToken.TokenSecret);
            var response = await this.restClient.ExecuteAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ModelException(ModelExceptionType.SignOutFailure);
            }
        }

        public bool IsCachedTokenAvailable
        {
            get
            {
                if (this.permanentToken != null)
                    return true;
                else
                    return false;
            }
        }

        public bool IsCachedCredentialAvailable
        {
            get
            {
                if (this.cachedCredential != null)
                    return true;
                else
                    return false;
            }
        }

        public Token GetCachedToken()
        {
            return this.permanentToken;
        }

        public Credential GetCachedCredential()
        {
            return this.cachedCredential;
        }

        public IWebClient GetAuthCapableWebClient()
        {
            IWebClient webClient = new WebClient(this);
            return webClient;
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
    }
}
