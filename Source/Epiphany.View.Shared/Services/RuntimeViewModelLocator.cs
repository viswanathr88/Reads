using Epiphany.Logging;
using Epiphany.Model.Authentication;
using Epiphany.Model.Services;
using Epiphany.Model.Settings;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Services;
using Epiphany.Web;

namespace Epiphany.View.Services
{
    sealed class RuntimeViewModelLocator : IViewModelLocator
    {
        private readonly ServiceFactory serviceFactory;
        private readonly INavigationService navigationService;
        private readonly ITimerService timerService;
        private readonly IDeviceServices deviceServices;
        private readonly IResourceLoader resourceLoader;

        private LogonViewModel logonVM;
        private HomeViewModel homeVM;

        public RuntimeViewModelLocator()
        {
            // Setup logging
            SetupLogging();

            // Set SettingStore as the backing store for AppSettings
            ApplicationSettings.Instance.Store = new SettingStorage();

            AuthenticatorFactory factory = new AuthenticatorFactory();
            this.serviceFactory = new ServiceFactory(factory);

            // Get the Logon service
            ILogonService logonService = this.serviceFactory.GetLogonService();

            // Register Authentication factory for TokenChanged events
            logonService.TokenChanged += factory.OnTokenChanged;

            // If token is already available, call OnTokenChanged on AuthenticatorFactory
            if (logonService.ActiveToken != null)
            {
                factory.OnTokenChanged(logonService, new TokenChangedEventArgs(logonService.ActiveToken, null));
            }

            // Set up services
            this.navigationService = new NavigationService();
            this.timerService = new TimerService();
            this.deviceServices = new DeviceServices();
            //this.resourceLoader = new ResourceLoader();
        }

        public IHomeViewModel Home
        {
            get
            {
                if (this.homeVM == null)
                {
                    this.homeVM = new HomeViewModel(this.serviceFactory.GetUserService(), this.serviceFactory.GetLogonService(), 
                        this.navigationService, this.resourceLoader, this.timerService, this.serviceFactory.GetBookshelfService(),
                        this.serviceFactory.GetBookService());
                }

                return this.homeVM;
            }
        }

        public ILogonViewModel Logon
        {
            get
            {
                if (this.logonVM == null)
                {
                    this.logonVM = new LogonViewModel(this.serviceFactory.GetLogonService(), this.timerService);
                }

                return this.logonVM;
            }
        }

        public IProfileViewModel Profile
        {
            get
            {
                return new ProfileViewModel(
                    this.serviceFactory.GetUserService(), 
                    this.serviceFactory.GetBookshelfService(), 
                    this.navigationService,
                    this.deviceServices,
                    this.resourceLoader);
            }
        }

        public IAboutViewModel About
        {
            get
            {
                return new AboutViewModel(this.deviceServices);
            }
        }

        public IAddBookViewModel AddBook
        {
            get
            {
                return new AddBookViewModel(
                    this.serviceFactory.GetLogonService(),
                    this.serviceFactory.GetBookService(),
                    this.serviceFactory.GetBookshelfService(),
                    this.navigationService
                    );
            }
        }

        public IBooksViewModel Books
        {
            get { return new BooksViewModel(); }
        }

        public IFriendsViewModel Friends
        {
            get { return new FriendsViewModel(this.serviceFactory.GetUserService(), this.navigationService, this.resourceLoader); }
        }

        public IEventsViewModel Events
        {
            get { return new EventsViewModel(this.serviceFactory.GetEventService(), this.deviceServices); }
        }

        public ISearchViewModel Search
        {
            get { return new SearchViewModel(this.serviceFactory.GetBookService(), Home.IsLoggedIn); }
        }

        public IAuthorViewModel Author
        {
            get { return new AuthorViewModel(this.serviceFactory.GetAuthorService(), this.serviceFactory.GetBookService(), this.navigationService); }
        }

        public ISettingsViewModel Settings
        {
            get { return new SettingsViewModel(); }
        }

        public IBookViewModel Book
        {
            get { return new BookViewModel(); }
        }

        public INavigationService NavigationService
        {
            get
            {
                return this.navigationService;
            }
        }

        public IScanViewModel Scanner
        {
            get
            {
                return new ScanViewModel();
            }
        }

        /// <summary>
        /// Setup logging
        /// </summary>
        private void SetupLogging()
        {
            if (Logger.Writers.Count == 0)
            {
                Logger.Writers.Add(new DebugConsoleWriter());
                Logger.LogDebug("Logging setup completed");
            }
        }

        public void Dispose()
        {

        }
    }
}
