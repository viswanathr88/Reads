using Epiphany.Model.Authentication;
using Epiphany.Model.Services;
using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Tests.Mock
{
    class MockLogonService : ILogonService
    {
        // ILogonService
        private AuthConfig config = new AuthConfig(
                "TestConsumerKey",
                "TestConsumerKeySecret",
                new Uri("http://www.TestBaseUri.com"),
                new Uri("http://www.TestRequestTokenUri.com"),
                new Uri("http://www.TestAuthorizeUri.com"),
                new Uri("http://www.TestAccessTokenUri.com"),
                new Uri("http://www.TestCallbackUri.com"));

        public AuthConfig Configuration
        {
            get { return this.config; }
        }

        public Model.Authentication.Session Session
        {
            get { throw new NotImplementedException(); }
        }

        public LogonState State
        {
            get;
            private set;
        }

        public Task<Uri> StartLogin()
        {
            return Task.FromResult<Uri>(config.AuthorizeUri);
        }

        public Task FinishLogin()
        {
            throw new NotImplementedException();
        }

        public Task<bool> TryVerifyLogin()
        {
            if (PassVerifyLogin)
            {
                State = LogonState.Connected;

                return Task.FromResult<bool>(true);
            }
            else
            {
                State = LogonState.NotConnected;
                return Task.FromResult<bool>(false);
            }
            
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public event EventHandler<Model.Authentication.SessionChangedEventArgs> SessionChanged;


        // properties
        public bool PassVerifyLogin
        {
            get;
            set;
        }
    }
}
