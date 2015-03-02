using Epiphany.Model;
using Epiphany.Model.Authentication;
using Epiphany.Model.Services;
using Epiphany.Model.Web;
using Epiphany.View.Web;
using RestSharp.Portable;
using RestSharp.Portable.Authenticators;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Security.Authentication.Web;
using Windows.Storage;

namespace Epiphany.View.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthConfig config = new AuthConfig();
        private readonly RestClient restClient;
        private readonly TokenParser tokenParser;
        private readonly IWebClient webClient;
        private Token temporaryToken;
        private Token permanentToken;
        private Credential cachedCredential;
        private const string settingContainerKey = "AuthInfo";
        private const string accessTokenKey = "AccessToken";
        private const string accessTokenSecretKey = "AccessTokenSecret";
        private const string currentUserIdKey = "CurrentUserId";
        private const string currentUserNameKey = "CurrentUserName";

        public AuthService()
        {
            this.restClient = new RestClient(config.BaseUri.ToString());
            this.tokenParser = new TokenParser();
            this.permanentToken = ReadTokensFromStorage();
            this.cachedCredential = ReadCredentialFromStorage();

            this.webClient = new WebClient(this);
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
            var request = new RestRequest("oauth/request_token", HttpMethod.Get);
            IRestResponse response = await this.restClient.Execute(request);

            if (response == null || response.RawBytes == null || response.RawBytes.Length <= 0)
            {
                throw new ModelException(ModelExceptionType.NoTokens);
            }

            string content = Encoding.UTF8.GetString(response.RawBytes, 0, response.RawBytes.Length);
            if (!this.tokenParser.TryParseTokens(content, out this.temporaryToken))
            {
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

            var request = new RestRequest("oauth/access_token", HttpMethod.Get);
            this.restClient.Authenticator = OAuth1Authenticator.ForAccessToken(config.ConsumerKey, config.ConsumerKeySecret, 
                temporaryToken.AuthToken, temporaryToken.TokenSecret, string.Empty);
            IRestResponse response = await this.restClient.Execute(request);

            if (response == null || response.RawBytes == null || response.RawBytes.Length <= 0)
            {
                throw new ModelException(ModelExceptionType.NoTokens);
            }

            string content = Encoding.UTF8.GetString(response.RawBytes, 0, response.RawBytes.Length);
            if (!this.tokenParser.TryParseTokens(content, out this.permanentToken))
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
            request.AddParameter("oauth_callback", this.Configuration.CallbackUri);
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

            var request = new RestRequest("api/auth_user", HttpMethod.Get);
            this.restClient.Authenticator = OAuth1Authenticator.ForProtectedResource(config.ConsumerKey, 
                config.ConsumerKeySecret, permanentToken.AuthToken, permanentToken.TokenSecret);
            IRestResponse<string> response = await this.restClient.Execute<string>(request);

            if (string.IsNullOrEmpty(response.Data))
            {
                throw new ModelException(ModelExceptionType.NoUserId);
            }

            Credential credential = null;
            try
            {
                XDocument document = XDocument.Parse(response.Data);
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

            var request = new RestRequest("api/sign_out", HttpMethod.Get);
            this.restClient.Authenticator = OAuth1Authenticator.ForProtectedResource(config.ConsumerKey,
                config.ConsumerKeySecret, permanentToken.AuthToken, permanentToken.TokenSecret);
            IRestResponse<string> response = await this.restClient.Execute<string>(request);

            if (!(response.IsSuccess && response.StatusCode == System.Net.HttpStatusCode.OK))
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
            return this.webClient;
        }

        private Token ReadTokensFromStorage()
        {
            Token accessToken = null;
            ApplicationDataContainer settings = ApplicationData.Current.RoamingSettings;

            if (settings.Containers.ContainsKey(settingContainerKey))
            {
                bool hasAccessToken = settings.Containers[settingContainerKey].Values.ContainsKey(accessTokenKey);
                bool hasAccessTokenKey = settings.Containers[settingContainerKey].Values.ContainsKey(accessTokenSecretKey);

                if (hasAccessToken && hasAccessTokenKey)
                {
                    string token = (string)settings.Containers[settingContainerKey].Values[accessTokenKey];
                    string tokenSecret = (string)settings.Containers[settingContainerKey].Values[accessTokenSecretKey];

                    if (!string.IsNullOrWhiteSpace(token) && !string.IsNullOrWhiteSpace(tokenSecret))
                    {
                        accessToken = new Token(token, tokenSecret);
                    }
                }
            }

            return accessToken;
        }

        private Credential ReadCredentialFromStorage()
        {
            Credential credential = null;
            ApplicationDataContainer settings = ApplicationData.Current.RoamingSettings;

            if (settings.Containers.ContainsKey(settingContainerKey))
            {
                bool hasCurrentUserId = settings.Containers[settingContainerKey].Values.ContainsKey(currentUserIdKey);
                bool hasCurrentUserName = settings.Containers[settingContainerKey].Values.ContainsKey(currentUserNameKey);

                if (hasCurrentUserId && hasCurrentUserName)
                {
                    string strcurrentUserId = (string)settings.Containers[settingContainerKey].Values[currentUserIdKey];
                    string currentUserName = (string)settings.Containers[settingContainerKey].Values[currentUserNameKey];

                    if (!string.IsNullOrWhiteSpace(strcurrentUserId) && !string.IsNullOrWhiteSpace(currentUserName))
                    {
                        int currentUserId = int.Parse(strcurrentUserId);
                        credential = new Credential(currentUserName, currentUserId);
                    }
                }
            }

            return credential;
        }

        private void WriteTokenToStorage(Token token)
        {
            ApplicationDataContainer settings = ApplicationData.Current.RoamingSettings;
            settings.CreateContainer(settingContainerKey, ApplicationDataCreateDisposition.Always);

            if (settings.Containers.ContainsKey(settingContainerKey))
            {
                settings.Containers[settingContainerKey].Values[accessTokenKey] = token.AuthToken;
                settings.Containers[settingContainerKey].Values[accessTokenSecretKey] = token.TokenSecret;                
            }
        }

        private void WriteCredentialToDisk(Credential credential)
        {
            ApplicationDataContainer settings = ApplicationData.Current.RoamingSettings;
            settings.CreateContainer(settingContainerKey, ApplicationDataCreateDisposition.Always);

            if (settings.Containers.ContainsKey(settingContainerKey))
            {
                settings.Containers[settingContainerKey].Values[currentUserIdKey] = credential.UserId.ToString();
                settings.Containers[settingContainerKey].Values[currentUserNameKey] = credential.Name;
            }
        }
    }
}
