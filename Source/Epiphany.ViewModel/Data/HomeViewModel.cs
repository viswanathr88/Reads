using Epiphany.Model.Authentication;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public sealed class HomeViewModel : DataViewModel<VoidType>
    {
        private readonly IUserService userService;
        private readonly INavigationService navigationService;
        private readonly ILogonService logonService;
        private readonly IResourceLoader resourceLoader;
        private readonly ITimerService timerService;

        private FeedViewModel feedViewModel;
        private LauncherViewModel launcherVM;
        private SpotlightViewModel spotlightVM;

        private readonly ICommand showAboutCommand;
        private readonly ICommand showSettingsCommand;

        private bool isLoggedIn;
        private double opacity = 0;

        public HomeViewModel() {  }

        public HomeViewModel(IUserService userService, ILogonService logonService, 
            INavigationService navigationService, IResourceLoader resourceLoader,
            ITimerService timerService)
        {
            this.userService = userService;
            this.navigationService = navigationService;
            this.logonService = logonService;
            this.resourceLoader = resourceLoader;
            this.timerService = timerService;

            this.showAboutCommand = new ShowAboutCommand(navigationService);
            this.showSettingsCommand = new ShowSettingsCommand(navigationService);

            Feed.PropertyChanged += OnChildVMPropertyChanged;

            IsLoggedIn = (this.logonService.Session != null);
            Opacity = IsLoggedIn ? 0 : 0.15;

            this.logonService.SessionChanged += LogonService_SessionChanged;
        }

        public int NewNotificationCount
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsLoggedIn
        {
            get
            {
                return this.isLoggedIn;
            }
            private set
            {
                SetProperty(ref this.isLoggedIn, value);
            }
        }

        public double Opacity
        {
            get
            {
                return this.opacity;
            }
            private set
            {
                SetProperty(ref this.opacity, value);
            }
        }

        public FeedViewModel Feed
        {
            get
            {
                if (this.feedViewModel == null)
                {
                    this.feedViewModel = new FeedViewModel(userService, navigationService, resourceLoader);
                }

                return this.feedViewModel;
            }
        }

        public LauncherViewModel Launcher
        {
            get
            {
                if (this.launcherVM == null)
                {
                    this.launcherVM = new LauncherViewModel(this.navigationService, this.logonService);
                }

                return this.launcherVM;
            }
        }

        public SpotlightViewModel Spotlight
        {
            get
            {
                if (this.spotlightVM == null)
                {
                    this.spotlightVM = new SpotlightViewModel(this.timerService);
                }

                return this.spotlightVM;
            }
        }

        public ICommand ShowNotifications
        {
            get { throw new NotImplementedException(); }
        }

        public ICommand ShowAbout
        {
            get { return this.showAboutCommand; }
        }

        public ICommand ShowSettings
        {
            get { return this.showSettingsCommand; }
        }

        public override async Task LoadAsync(VoidType parameter)
        {
            await Task.Delay(1);
            /*if (!Feed.IsLoaded)
            {
                await Feed.LoadAsync(parameter);
            }*/
        }

        private void OnChildVMPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsLoading))
            {
                IsLoading = Feed.IsLoading;
            }
            else if (e.PropertyName == nameof(IsLoaded))
            {
                IsLoaded = Feed.IsLoaded;
            }
        }

        private void LogonService_SessionChanged(object sender, SessionChangedEventArgs e)
        {
            if (e.Session != null)
            {
                IsLoggedIn = true;
                IsLoaded = false;
                Opacity = 0;
            }
        }
    }
}
