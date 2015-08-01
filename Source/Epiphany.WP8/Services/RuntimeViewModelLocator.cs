using Epiphany.Model.Services;
using Epiphany.Settings;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Services;
using System;

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

        public RuntimeViewModelLocator()
        {
            IAuthService authService = new AuthService();
            this.serviceFactory = new ServiceFactory(authService);

            // Set up services
            this.navigationService = new NavigationService();
            this.appSettings = AppSettings.Instance;
            this.timerService = new TimerService();
        }

        public IHomeViewModel Home
        {
            get { throw new NotImplementedException(); }
        }

        public ILogonViewModel Logon
        {
            get { throw new NotImplementedException(); }
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

        public void Dispose()
        {

        }
    }
}
