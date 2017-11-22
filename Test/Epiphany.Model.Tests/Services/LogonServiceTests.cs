using Epiphany.Model.Authentication;
using Epiphany.Model.Messaging;
using Epiphany.Model.Services;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Threading.Tasks;
using Epiphany.Web;

namespace Epiphany.Model.Tests.Services
{
    /*[TestClass]
    public class LogonServiceTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            MockAuthService authService = new MockAuthService();
            authService.IsCachedCredentialAvailable = false;
            authService.IsCachedTokenAvailable = false;

            var mockWebClient = new StubIWebClient();
            
            ILogonService service = new LogonService(mockWebClient, Messenger.Instance);
            Assert.IsNotNull(service, "service is null");
            Assert.IsNull(service.Session, "Session is not null");
            Assert.IsTrue(service.State == LogonState.NotConnected, "State is not NotConnected");

            authService.IsCachedCredentialAvailable = true;
            authService.IsCachedTokenAvailable = false;

            service = new LogonService(mockWebClient, Messenger.Instance);
            Assert.IsNotNull(service, "service is null");
            Assert.IsNull(service.Session, "Session is not null");
            Assert.IsTrue(service.State == LogonState.NotConnected, "State is not NotConnected");

            authService.IsCachedCredentialAvailable = false;
            authService.IsCachedTokenAvailable = true;

            service = new LogonService(mockWebClient, Messenger.Instance);
            Assert.IsNotNull(service, "service is null");
            Assert.IsNull(service.Session, "Session is not null");
            Assert.IsTrue(service.State == LogonState.NotConnected, "State is not NotConnected");

            authService.IsCachedCredentialAvailable = true;
            authService.IsCachedTokenAvailable = true;
            Token token = authService.GetCachedToken();
            Credential credential = authService.GetCachedCredential();

            Messenger.Instance.Subscribe<SessionChangedMessage>(this, (object o, SessionChangedMessage m) =>
            {
                Assert.IsTrue(m.Session.Name == credential.Name, "Name does not match");
                Assert.IsTrue(m.Session.UserId == credential.UserId.ToString(), "UserId does not match");
                Assert.IsTrue(m.Session.Token == token.AuthToken, "Token does not match");
                Assert.IsTrue(m.Session.TokenSecret == token.TokenSecret, "TokenSecret does not match");
            });

            service = new LogonService(mockWebClient, Messenger.Instance);
            Assert.IsNotNull(service, "service is null");
            Assert.IsNotNull(service.Session, "Session is not null");
            Assert.IsTrue(service.State == LogonState.NotConnected, "State is not NotConnected");

            Assert.IsTrue(service.Session.Name == credential.Name, "Name does not match");
            Assert.IsTrue(service.Session.UserId == credential.UserId.ToString(), "UserId does not match");
            Assert.IsTrue(service.Session.Token == token.AuthToken, "Token does not match");
            Assert.IsTrue(service.Session.TokenSecret == token.TokenSecret, "TokenSecret does not match");
        }

        [TestMethod]
        public void ConfigurationTest()
        {
            AuthConfig config = new AuthConfig(
                "TestConsumerKey",
                "TestConsumerKeySecret",
                new Uri("http://www.TestBaseUri.com"),
                new Uri("http://www.TestRequestTokenUri.com"),
                new Uri("http://www.TestAuthorizeUri.com"),
                new Uri("http://www.TestAccessTokenUri.com"),
                new Uri("http://www.TestCallbackUri.com"));
            
            MockAuthService authService = new MockAuthService();
            authService.Configuration = config;

            ILogonService service = new LogonService(authService, Messenger.Instance);
            Assert.IsNotNull(service, "service is null");
            Assert.IsNotNull(authService.Configuration, "Configuration is null");

            Assert.IsTrue(authService.Configuration.AccessTokenUri == config.AccessTokenUri, "AccessTokenUri does not match");
            Assert.IsTrue(authService.Configuration.AuthorizeUri == config.AuthorizeUri, "AuthorizeUri does not match");
            Assert.IsTrue(authService.Configuration.BaseUri == config.BaseUri, "BaseUri does not match");
            Assert.IsTrue(authService.Configuration.CallbackUri == config.CallbackUri, "CallbackUri does not match");
            Assert.IsTrue(authService.Configuration.RequestTokenUri == config.RequestTokenUri, "RequestTokenUri does not match");
            Assert.IsTrue(authService.Configuration.ConsumerKey == config.ConsumerKey, "ConsumerKey does not match");
            Assert.IsTrue(authService.Configuration.ConsumerKeySecret == config.ConsumerKeySecret, "ConsumerKeySecret does not match");
        }

        [TestMethod]
        public async Task TryVerifyLoginTest()
        {
            MockAuthService authService = new MockAuthService();

            authService.ShouldGetCredentialFail = true;
            authService.ShouldGetTokenFail = true;
            ILogonService service = new LogonService(authService, Messenger.Instance);
            bool result = await service.TryVerifyLogin();
            Assert.IsFalse(result, "result is true");

            authService.ShouldGetCredentialFail = true;
            authService.ShouldGetTokenFail = false;
            service = new LogonService(authService, Messenger.Instance);
            Assert.IsNotNull(service, "service is null");
            result = await service.TryVerifyLogin();
            Assert.IsFalse(result, "result is true");

            authService.ShouldGetCredentialFail = false;
            authService.ShouldGetTokenFail = true;
            service = new LogonService(authService, Messenger.Instance);
            Assert.IsNotNull(service, "service is null");
            result = await service.TryVerifyLogin();
            Assert.IsFalse(result, "result is true");

            authService.ShouldGetCredentialFail = false;
            authService.ShouldGetTokenFail = false;
            service = new LogonService(authService, Messenger.Instance);
            Assert.IsNotNull(service, "service is null");
            service.SessionChanged += ((object sender, SessionChangedEventArgs e) =>
            {
                Assert.IsNotNull(e.Session, "Session is null");
            });
            result = await service.TryVerifyLogin();
            Assert.IsTrue(result, "result is false");

            Assert.IsTrue(service.State == LogonState.Connected, "State is not Connected");
        }

        [TestMethod]
        public async Task StartLoginTest()
        {
            MockAuthService authService = new MockAuthService();

            ILogonService service = new LogonService(authService, Messenger.Instance);
            Uri uri = await service.StartLogin();

            Assert.IsTrue(service.State == LogonState.Connecting, "State is not Connecting");
            Assert.IsTrue(uri == authService.GetAuthorizeUri(), "AuthorizeUri does not match");
        }

        [TestMethod]
        public async Task FinishLoginTest()
        {
            MockAuthService authService = new MockAuthService();
            authService.ShouldGetCredentialFail = false;
            authService.ShouldGetTokenFail = false;

            // Expected failure when FinishLogin is called without calling StartLogin
            ILogonService service = new LogonService(authService, Messenger.Instance);
            Assert.IsNotNull(service, "service is null");
            var ex = await AssertHelper.ThrowsExceptionAsync<ModelException>(async () =>
            {
                await service.FinishLogin();
            });
            Assert.IsTrue(ex.Type == ModelExceptionType.NoTokens);

            await service.StartLogin();
            Assert.IsTrue(service.State == LogonState.Connecting, "State is not connecting");

            service.SessionChanged += ((object sender, SessionChangedEventArgs e) =>
            {
                Assert.IsNotNull(e.Session, "Session is null");
            });
            await service.FinishLogin();
            Assert.IsTrue(service.State == LogonState.Connected, "State is not Connected");
        }

        [TestMethod]
        public async Task LogoutTest()
        {
            MockAuthService authService = new MockAuthService();
            Assert.IsFalse(authService.LogoutWasCalled, "LogoutWasCalled is true");

            ILogonService service = new LogonService(authService, Messenger.Instance);
            Assert.IsNotNull(service, "service is null");

            service.SessionChanged += ((object sender, SessionChangedEventArgs e) =>
            {
                Assert.IsNull(e.Session, "Session is null");
            });
            await service.Logout();
            Assert.IsTrue(authService.LogoutWasCalled, "LogoutWasCalled is false");
            Assert.IsTrue(service.State == LogonState.NotConnected);
            Assert.IsTrue(service.Session == null);
        }
    }*/
}
