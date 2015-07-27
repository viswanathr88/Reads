using Epiphany.Logging;
using Epiphany.Model.Authentication;
using Epiphany.Model.Messaging;
using System;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    class LogonService : ILogonService
    {
        private readonly IAuthService authService;
        private readonly IMessenger messenger;

        private LogonState state;
        private Session session;

        public LogonService(IAuthService authService, IMessenger messenger)
        {
            if (authService == null || messenger == null)
            {
                throw new ArgumentNullException();
            }

            this.authService = authService;
            this.messenger = messenger;
            State = LogonState.NotConnected;

            //
            // Rehydrate the session if token and credentials are already available
            //
            if (this.authService.IsCachedCredentialAvailable &&
                this.authService.IsCachedTokenAvailable)
            {
                Session = new Session(this.authService.GetCachedCredential(), this.authService.GetCachedToken());
            }
        }

        public AuthConfig Configuration
        {
            get
            {
                return this.authService.Configuration;
            }
        }

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
                //
                // Send a message for listeners
                //
                SessionChangedMessage msg = new SessionChangedMessage(this, this.session);
                this.messenger.SendMessage<SessionChangedMessage>(this, msg);
                RaiseSessionChanged(session);
            }
        }

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

        public async Task<Uri> StartLogin()
        {
            //
            // Request for a temporary token and return the authorize uri
            //
            State = LogonState.Connecting;
            await this.authService.RequestTemporaryToken();
            Uri authorizeUri = this.authService.GetAuthorizeUri();

            return authorizeUri;
        }

        public async Task FinishLogin()
        {
            //
            // Request for permanent tokens and create the session
            //
            if (this.state == LogonState.NotConnected)
            {
                throw new ModelException(ModelExceptionType.NoTokens);
            }

            Token token = await this.authService.GetToken();
            Credential credential = await this.authService.GetCredentialAsync();
            Session = new Session(credential, token);
            State = LogonState.Connected;
        }

        public async Task<bool> TryVerifyLogin()
        {
            bool result = false;

            try
            {
                Credential credential = await authService.GetCredentialAsync();
                Token token = await authService.GetToken();
                Session = new Session(credential, token);
                State = LogonState.Connected;
                result = true;
            }
            catch (Exception ex)
            {
                Log.Instance.Warn(ex.StackTrace);
            }
            return result;
        }

        public async Task Logout()
        {
            await this.authService.Logout();
            this.state = LogonState.NotConnected;
            Session = null;
        }

        public event EventHandler<SessionChangedEventArgs> SessionChanged;


        private void RaiseSessionChanged(Session session)
        {
            if (SessionChanged != null)
            {
                SessionChanged(this, new SessionChangedEventArgs(session));
            }
        }
    }
}
