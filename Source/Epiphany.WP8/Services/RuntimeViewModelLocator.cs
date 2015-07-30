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
            get { throw new NotImplementedException(); }
        }

        public void Dispose()
        {
            
        }
    }
}
