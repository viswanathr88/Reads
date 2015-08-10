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
        private readonly IResourceLoader resourceLoader;

        private IFeedViewModel feedViewModel;
        private ILauncherViewModel launcherVM;

        private readonly ICommand showAboutCommand;
        private readonly ICommand showSettingsCommand;

        public HomeViewModel(IUserService userService, ILogonService logonService, 
            INavigationService navigationService, IAppSettings settings, IResourceLoader resourceLoader)
        {
            if (userService == null || navigationService == null 
                || settings == null || logonService == null || resourceLoader == null)
            {
                throw new ArgumentNullException("services");
            }

            this.userService = userService;
            this.navigationService = navigationService;
            this.appSettings = settings;
            this.logonService = logonService;
            this.resourceLoader = resourceLoader;

            this.showAboutCommand = new ShowAboutCommand(navigationService);
            this.showSettingsCommand = new ShowSettingsCommand(navigationService);
        }

        public int NewNotificationCount
        {
            get { throw new NotImplementedException(); }
        }

        public IFeedViewModel Feed
        {
            get
            {
                if (this.feedViewModel == null)
                {
                    this.feedViewModel = new FeedViewModel(userService, navigationService, appSettings, resourceLoader);
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
            get { return this.showSettingsCommand; }
        }

        public override async Task LoadAsync()
        {
            if (Feed.FetchFeed.CanExecute(VoidType.Empty))
            {
                await Feed.FetchFeed.ExecuteAsync(VoidType.Empty);
            }
        }
    }
}
