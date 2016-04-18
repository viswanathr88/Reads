using Epiphany.Model.Authentication;
using Epiphany.Model.Services;
using Epiphany.Web;
using System;
using System.Threading.Tasks;

namespace Epiphany.Model.Tests.Services
{
    public class MockAuthService : IAuthService
    {
        public AuthConfig Configuration
        {
            get;
            set;
        }

        public Task RequestTemporaryToken()
        {
            return Task.FromResult<int>(10);
        }

        public async Task<Token> GetToken()
        {
            Token token = null;
            if (!ShouldGetTokenFail)
            {
                token = new Token("TestToken", "TestTokenSecret");
            }
            return await Task.FromResult<Token>(token);
        }

        public Uri GetAuthorizeUri()
        {
            return new Uri("http://www.testauthorizeuri.com");
        }

        public async Task<Credential> GetCredentialAsync()
        {
            Credential credential = null; 
            if (!ShouldGetCredentialFail)
            {
                credential = new Credential("TestUser", 10);
            }
            return await Task.FromResult<Credential>(credential);
        }

        public Task Logout()
        {
            LogoutWasCalled = true;
            return Task.FromResult<bool>(true);
        }

        public bool IsCachedTokenAvailable
        {
            get;
            set;
        }

        public bool IsCachedCredentialAvailable
        {
            get;
            set;
        }

        public Token GetCachedToken()
        {
            Token token = null;
            if (IsCachedTokenAvailable)
            {
                token = new Token("TestToken", "TestTokenSecret");
            }

            return token;
        }

        public Credential GetCachedCredential()
        {
            Credential credential = null;
            if (IsCachedCredentialAvailable)
            {
                credential = new Credential("TestUser", 10);
            }

            return credential;
        }

        public IWebClient GetAuthCapableWebClient()
        {
            throw new NotImplementedException();
        }

        public bool ShouldGetCredentialFail
        {
            get;
            set;
        }

        public bool ShouldGetTokenFail
        {
            get;
            set;
        }

        public bool LogoutWasCalled
        {
            get;
            private set;
        }
    }
}
