using Epiphany.Model.Services;
using Epiphany.Settings;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Services;

namespace Epiphany.View.Services
{
    sealed class RuntimeViewModelLocator : IViewModelLocator
    {
        private readonly ServiceFactory serviceFactory;
        private readonly INavigationService navigationService;
        private readonly ITimerService timerService;
        private readonly IAppSettings appSettings;
        private readonly IAppRateService appRateService;
        private readonly IUrlLauncher urlLauncher;
        private readonly IResourceLoader resourceLoader;

        private ILogonViewModel logonVM;
        private IHomeViewModel homeVM;

        public RuntimeViewModelLocator()
        {
            IAuthService authService = new AuthService();
            this.serviceFactory = new ServiceFactory(authService);

            // Set up services
            this.navigationService = new NavigationService();
            this.appSettings = AppSettings.Instance;
            this.timerService = new TimerService();
            this.appRateService = new AppRateService();
            this.urlLauncher = new UrlLauncher();
            this.resourceLoader = new ResourceLoader();
        }

        public IHomeViewModel Home
        {
            get
            {
                if (this.homeVM == null)
                {
                    this.homeVM = new HomeViewModel(this.serviceFactory.GetUserService(), this.serviceFactory.GetLogonService(), 
                        this.navigationService, this.appSettings);
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
                    this.logonVM = new LogonViewModel(this.serviceFactory.GetLogonService(), navigationService, this.timerService);
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
                    this.urlLauncher);
            }
        }

        public IAboutViewModel About
        {
            get
            {
                IAboutViewModel vm = new AboutViewModel(this.appRateService, this.urlLauncher);
                return vm;
            }
        }

        public IAddBookViewModel AddBook
        {
            get
            {
                IAddBookViewModel vm = new AddBookViewModel(
                    this.serviceFactory.GetLogonService(),
                    this.serviceFactory.GetBookService(),
                    this.serviceFactory.GetBookshelfService(),
                    this.navigationService
                    );

                return vm;
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

        public void Dispose()
        {

        }

    }
}
