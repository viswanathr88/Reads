using Epiphany.Logging;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Services;
using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public sealed class LogonViewModel : DataViewModel<VoidType>, ILogonViewModel
    {
        private bool isWaitingForUserInteraction;
        private Uri currentUri;
        private ITimer timer;
        private bool isSignInTakingLonger;
        private bool isLoginCompleted;

        // Services
        private readonly ILogonService logonService;

        public LogonViewModel()
        {

        }

        public LogonViewModel(ILogonService logonService, ITimerService timerService)
        {
            if (logonService == null || timerService == null)
            {
                throw new ArgumentNullException();
            }

            this.logonService = logonService;

            this.timer = timerService.CreateTimer(() => IsSignInTakingLonger = true);
            this.timer.Interval = new TimeSpan(0, 0, 7);
        }

        public Uri CallbackUri
        {
            get
            {
                return this.logonService.Configuration.CallbackUri;
            }
        }

        public bool IsWaitingForUserInteraction
        {
            get
            {
                return this.isWaitingForUserInteraction;
            }
            private set
            {
                if (this.isWaitingForUserInteraction == value) return;
                this.isWaitingForUserInteraction = value;
                RaisePropertyChanged();
            }
        }

        public Uri CurrentUri
        {
            get
            {
                return this.currentUri;
            }
            set
            {
                if (this.currentUri == value) return;
                this.currentUri = value;
                RaisePropertyChanged();
            }
        }

        public bool IsSignInTakingLonger
        {
            get
            {
                return this.isSignInTakingLonger;
            }
            private set
            {
                if (this.isSignInTakingLonger == value) return;
                this.isSignInTakingLonger = value;
                RaisePropertyChanged();
            }
        }


        public bool IsLoginCompleted
        {
            get 
            { 
                return this.isLoginCompleted; 
            }
            private set 
            {
                if (this.isLoginCompleted == value) return;
                this.isLoginCompleted = value;
                RaisePropertyChanged();
            }
        }

        public override async Task LoadAsync(VoidType parameter)
        {
            // First verify if we are already logged in
            try
            {
                StartTimer();
                bool fLoggedIn = await Task.Run(async () => await this.logonService.TryVerifyLogin());
                StopTimer();
                Logger.LogDebug("TryVerifyLogin result = " + fLoggedIn);

                if (fLoggedIn)
                {
                    // Login was successfully verified
                    IsLoginCompleted = true;
                    IsLoaded = true;
                }
                else
                {
                    // Need to login
                    Logger.LogDebug("Starting login");
                    StartTimer();
                    CurrentUri = await Task.Run(async () => await this.logonService.StartLogin());
                    StopTimer();
                    IsWaitingForUserInteraction = true;
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Error = ex;
            }
            finally
            {
                StopTimer();
            }
            
        }

        public async Task CheckUriAsync(Uri uri)
        {
            if (uri.ToString().StartsWith(logonService.Configuration.CallbackUri.ToString()))
            {
                if (uri.ToString().Contains("authorize=1"))
                {
                    // Goodreads authorization has succeeded
                    IsWaitingForUserInteraction = false;
                    IsLoading = true;
                    
                    // Complete the login process
                    StartTimer();
                    await this.logonService.FinishLogin();
                    StopTimer();

                    // Set properties
                    IsLoginCompleted = true;
                    IsLoading = false;
                    IsLoaded = true;
                }
            }
        }

        private void StartTimer()
        {
            StopTimer();
            this.timer.Start();
        }

        private void StopTimer()
        {
            if (this.timer.IsEnabled)
            {
                this.timer.Stop();
            }

            if (IsSignInTakingLonger)
            {
                IsSignInTakingLonger = false;
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            if (this.timer != null)
            {
                this.timer.Dispose();
            }
        }
    }
}
