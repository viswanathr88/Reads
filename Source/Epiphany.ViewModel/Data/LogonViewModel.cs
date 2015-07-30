using Epiphany.Logging;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System;

namespace Epiphany.ViewModel
{
    sealed class LogonViewModel : DataViewModel, ILogonViewModel
    {
        private bool isWaitingForUserInteraction;
        private object error;
        private Uri currentUri;
        private ITimer timer;
        private bool isSignInTakingLonger;
        private bool isLoginCompleted;

        // Services
        private readonly ILogonService logonService;
        private readonly INavigationService navigationService;

        // Commands
        private readonly ICommand<bool, VoidType> verifyLoginCommand;
        private readonly ICommand<Uri, VoidType> loginCommand;
        private readonly ICommand<bool, Uri> checkUriCommand;
        private readonly ICommand<VoidType, VoidType> finishLoginCommand;

        public LogonViewModel(ILogonService logonService, INavigationService navigationService, ITimerService timerService)
        {
            if (logonService == null || navigationService == null || timerService == null)
            {
                throw new ArgumentNullException();
            }

            this.logonService = logonService;
            this.navigationService = navigationService;

            this.verifyLoginCommand = new VerifyLoginCommand(logonService);
            this.verifyLoginCommand.Executing += OnVerifyLoginExecuting;
            this.verifyLoginCommand.Executed += OnVerifyLoginExecuted;

            this.loginCommand = new LoginCommand(logonService);
            this.loginCommand.Executing += OnCommandExecuting;
            this.loginCommand.Executed += OnLoginExecuted;

            this.checkUriCommand = new CheckUriCommand(logonService.Configuration.CallbackUri);
            this.checkUriCommand.Executed += OnCheckUriExecuted;

            this.finishLoginCommand = new FinishLoginCommand(logonService);
            this.finishLoginCommand.Executing += OnCommandExecuting;
            this.finishLoginCommand.Executed += OnFinishLoginExecuted;

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
                if (this.isLoginCompleted != value) return;
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

        public override void Load()
        {
            Log.Instance.Debug(IsLoaded.ToString());

            if (!IsLoaded)
            {
                this.verifyLoginCommand.Execute(VoidType.Empty);
            }
        }

        private void OnVerifyLoginExecuting(object sender, CancelEventArgs e)
        {
            IsLoading = true;
            Error = null;
            StartTimer();
        }

        private void OnVerifyLoginExecuted(object sender, ExecutedEventArgs e)
        {
            StopTimer();
            if (e.State == CommandExecutionState.Success)
            {
                Log.Instance.Info(this.verifyLoginCommand.Result.ToString());
                if (this.verifyLoginCommand.Result)
                {
                    IsLoginCompleted = this.verifyLoginCommand.Result;
                }
                else
                {
                    StartTimer();
                    this.loginCommand.Execute(VoidType.Empty);
                }
            }
        }

        private void OnLoginExecuted(object sender, ExecutedEventArgs e)
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

        private void OnCheckUriExecuted(object sender, ExecutedEventArgs e)
        {
            if (e.State == CommandExecutionState.Success)
            {
                if (this.checkUriCommand.Result)
                {
                    IsWaitingForUserInteraction = false;
                    IsLoading = true;
                    StartTimer();
                    finishLoginCommand.Execute(VoidType.Empty);
                }
            }
            else
            {
                Error = this.checkUriCommand.Error;
                IsLoading = false;
            }
        }

        private void OnFinishLoginExecuted(object sender, ExecutedEventArgs e)
        {
            StopTimer();
            if (e.State == CommandExecutionState.Success)
            {
                IsLoginCompleted = true;
                IsLoaded = true;
            }
            else
            {
                Error = this.finishLoginCommand.Error;
            }

            IsLoading = false;
        }

        private void OnCommandExecuting(object sender, CancelEventArgs e)
        {
            IsLoading = true;
            Error = null;
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

            this.verifyLoginCommand.Executing -= OnVerifyLoginExecuting;
            this.verifyLoginCommand.Executed -= OnVerifyLoginExecuted;

            this.loginCommand.Executing -= OnCommandExecuting;
            this.loginCommand.Executed -= OnLoginExecuted;

            this.checkUriCommand.Executed -= OnCheckUriExecuted;

            this.finishLoginCommand.Executing -= OnCommandExecuting;
            this.finishLoginCommand.Executed -= OnFinishLoginExecuted;

            if (this.timer != null)
            {
                this.timer.Dispose();
            }
        }
    }
}
