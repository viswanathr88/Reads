using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System;
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

        private FeedViewModel feedViewModel;
        private LauncherViewModel launcherVM;

        private readonly ICommand showAboutCommand;
        private readonly ICommand showSettingsCommand;

        public HomeViewModel() {  }

        public HomeViewModel(IUserService userService, ILogonService logonService, 
            INavigationService navigationService, IResourceLoader resourceLoader)
        {
            this.userService = userService;
            this.navigationService = navigationService;
            this.logonService = logonService;
            this.resourceLoader = resourceLoader;

            this.showAboutCommand = new ShowAboutCommand(navigationService);
            this.showSettingsCommand = new ShowSettingsCommand(navigationService);

            Feed.PropertyChanged += OnChildVMPropertyChanged;
        }

        public int NewNotificationCount
        {
            get { throw new NotImplementedException(); }
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
            /*if (!Feed.IsLoaded)
            {
                await Feed.LoadAsync(parameter);
            }*/
        }

        private void OnChildVMPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
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
    }
}
