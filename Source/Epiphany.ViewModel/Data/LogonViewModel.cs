using Epiphany.Logging;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
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
        private readonly INavigationService navigationService;

        // Commands
        private readonly IAsyncCommand<bool, VoidType> verifyLoginCommand;
        private readonly IAsyncCommand<Uri, VoidType> loginCommand;
        private readonly ICommand<bool, Uri> checkUriCommand;
        private readonly IAsyncCommand<VoidType> finishLoginCommand;

        public LogonViewModel(ILogonService logonService, INavigationService navigationService, ITimerService timerService)
        {
            if (logonService == null || navigationService == null || timerService == null)
            {
                throw new ArgumentNullException();
            }

            this.logonService = logonService;
            this.navigationService = navigationService;

            this.verifyLoginCommand = new VerifyLoginCommand(logonService);
            RegisterCommand(this.verifyLoginCommand, OnVerifyLoginExecuted);
            this.verifyLoginCommand.Executing += OnVerifyLoginExecuting;

            this.loginCommand = new LoginCommand(logonService);
            RegisterCommand(this.loginCommand, OnLoginExecuted);

            this.checkUriCommand = new CheckUriCommand(logonService.Configuration.CallbackUri);
            this.checkUriCommand.Executed += OnCheckUriExecuted;

            this.finishLoginCommand = new FinishLoginCommand(logonService);
            RegisterCommand(this.finishLoginCommand, OnFinishLoginExecuted);

            this.timer = timerService.CreateTimer(() => IsSignInTakingLonger = true);
            this.timer.Interval = new TimeSpan(0, 0, 7);

        }

        public bool IsWaitingForUserInteraction
        {
            get
            {
                return this.isWaitingForUserInteraction;
            }
            private set
            {
                if (this.isWaitingForUserInteraction != value)
                {
                    this.isWaitingForUserInteraction = value;
                    RaisePropertyChanged();
                }
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
                if (this.currentUri != value)
                {
                    this.currentUri = value;
                    RaisePropertyChanged();
                }
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
                if (this.isSignInTakingLonger == value)
                {
                    return;
                }

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


        public ICommand<Uri, VoidType> Login
        {
            get
            {
                return this.loginCommand;
            }
        }

        public ICommand<bool, Uri> CheckUriForLoginCompletion
        {
            get
            {
                return this.checkUriCommand;
            }
        }

        public override async Task LoadAsync(VoidType parameter)
        {
            Log.Instance.Debug(IsLoaded.ToString());

            if (!IsLoaded)
            {
                await this.verifyLoginCommand.ExecuteAsync(parameter);
            }
        }

        private void OnVerifyLoginExecuting(object sender, CancelEventArgs e)
        {
            Error = null;
            StartTimer();
        }

        private async void OnVerifyLoginExecuted(ExecutedEventArgs e)
        {
            StopTimer();
            if (e.State == CommandExecutionState.Success)
            {
                Log.Instance.Info(this.verifyLoginCommand.Result.ToString());
                if (this.verifyLoginCommand.Result)
                {
                    IsLoginCompleted = this.verifyLoginCommand.Result;
                    IsLoaded = true;
                    NavigateHome();
                }
                else
                {
                    StartTimer();
                    await this.loginCommand.ExecuteAsync(VoidType.Empty);
                }
            }
        }

        private void OnLoginExecuted(ExecutedEventArgs e)
        {
            StopTimer();
            if (e.State == CommandExecutionState.Success)
            {
                CurrentUri = this.loginCommand.Result;
                IsWaitingForUserInteraction = true;
            }
            else
            {
                Error = this.loginCommand.Error;
                IsLoading = false;
            }
        }

        private async void OnCheckUriExecuted(object sender, ExecutedEventArgs e)
        {
            if (e.State == CommandExecutionState.Success)
            {
                if (this.checkUriCommand.Result)
                {
                    IsWaitingForUserInteraction = false;
                    IsLoading = true;
                    StartTimer();
                    await finishLoginCommand.ExecuteAsync(VoidType.Empty);
                }
            }
            else
            {
                Error = this.checkUriCommand.Error;
                IsLoading = false;
            }
        }

        private void OnFinishLoginExecuted(ExecutedEventArgs e)
        {
            StopTimer();
            if (e.State == CommandExecutionState.Success)
            {
                IsLoginCompleted = true;
                IsLoaded = true;
                NavigateHome();
            }
            else
            {
                Error = this.finishLoginCommand.Error;
            }

            IsLoading = false;
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

        private void NavigateHome()
        {
            this.navigationService.CreateFor<IHomeViewModel>().Navigate();
        }

        public override void Dispose()
        {
            base.Dispose();

            DeregisterCommand(this.verifyLoginCommand);
            this.verifyLoginCommand.Executing -= OnVerifyLoginExecuting;
            DeregisterCommand(this.loginCommand);
            this.checkUriCommand.Executed -= OnCheckUriExecuted;
            DeregisterCommand(this.finishLoginCommand);

            if (this.timer != null)
            {
                this.timer.Dispose();
            }
        }
    }
}
