using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public sealed class HomeViewModel : DataViewModel, IHomeViewModel
    {
        private readonly IUserService userService;
        private readonly INavigationService navigationService;
        private readonly IAppSettings appSettings;
        private readonly ILogonService logonService;

        private IFeedViewModel feedViewModel;
        private ILauncherViewModel launcherVM;

        private readonly ICommand showAboutCommand;

        public HomeViewModel(IUserService userService, ILogonService logonService, 
            INavigationService navigationService, IAppSettings settings)
        {
            if (userService == null || navigationService == null 
                || settings == null || logonService == null)
            {
                throw new ArgumentNullException("services");
            }

            this.userService = userService;
            this.navigationService = navigationService;
            this.appSettings = settings;
            this.logonService = logonService;

            this.showAboutCommand = new ShowAboutCommand(navigationService);
        }

        public int NewNotificationCount
        {
            get { throw new NotImplementedException(); }
        }

        public IFeedViewModel FeedViewModel
        {
            get
            {
                if (this.feedViewModel == null)
                {
                    this.feedViewModel = new FeedViewModel(userService, navigationService, appSettings);
                }

                return this.feedViewModel;
            }
        }

        public ILauncherViewModel Launcher
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
            get { throw new NotImplementedException(); }
        }

        public override Task LoadAsync()
        {
            return Task.FromResult(true);
        }
    }
}
