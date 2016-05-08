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
    public sealed class HomeViewModel : DataViewModel<VoidType>, IHomeViewModel
    {
        private readonly IUserService userService;
        private readonly INavigationService navigationService;
        private readonly ILogonService logonService;
        private readonly IResourceLoader resourceLoader;
        private readonly ITimerService timerService;
        private readonly IBookshelfService bookshelfService;
        private readonly IBookService bookService;

        private IFeedViewModel feedViewModel;
        private ILauncherViewModel launcherVM;
        private IBookshelvesViewModel bookshelvesVM;

        private readonly ICommand showAboutCommand;
        private readonly ICommand showSettingsCommand;

        private bool isLoggedIn;
        private double opacity = 0;

        public HomeViewModel(IUserService userService, ILogonService logonService, 
            INavigationService navigationService, IResourceLoader resourceLoader,
            ITimerService timerService, IBookshelfService bookshelfService, IBookService bookService)
        {
            this.userService = userService;
            this.navigationService = navigationService;
            this.logonService = logonService;
            this.resourceLoader = resourceLoader;
            this.timerService = timerService;
            this.bookshelfService = bookshelfService;
            this.bookService = bookService;

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

        public IFeedViewModel Feed
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

        public IBookshelvesViewModel Books
        {
            get
            {
                if (this.bookshelvesVM == null)
                {
                    this.bookshelvesVM = new BookshelvesViewModel(bookshelfService, bookService, logonService);
                }
                return this.bookshelvesVM;
            }
        }

        public override async Task LoadAsync(VoidType parameter)
        {
            if (IsLoggedIn && !IsLoaded)
            {
                IsLoading = true;

                // Start loading your feed but not await
                Task feedLoadTask = Feed.LoadAsync(parameter);

                // This should finish quickly as it is just creating the collection
                await Books.LoadAsync(int.Parse(this.logonService.Session.UserId));

                // Wait for the feed task to finish
                await feedLoadTask;

                IsLoading = false;
                IsLoaded = true;
            }
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
            else
            {
                IsLoggedIn = false;
                Opacity = 0.15;
            }
        }
    }
}
