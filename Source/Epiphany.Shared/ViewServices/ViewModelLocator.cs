﻿using Epiphany.Logging;
using Epiphany.Model.Services;
using Epiphany.Settings;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Services;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;

namespace Epiphany.View.Services
{
    public class ViewModelLocator
    {
        //
        // Model Services and factory
        //
        private readonly IAuthService authService;
        private readonly ServiceFactory modelFactory;
        private readonly IAppSettings appSettings;
        //
        // View Services
        //
        private readonly NavigationService navigationService;
        private readonly ITimerService timerService;
        //
        // View Models
        //
        private HomeViewModel homeViewModel;
        private LogonViewModel logonViewModel;
        private AboutViewModel aboutViewModel;

        public ViewModelLocator()
        {
            this.authService = new AuthService();
            // Setup the service factory
            this.modelFactory = new ServiceFactory(this.authService);
            this.appSettings = AppSettings.Instance;
            //
            // Setup all the view services
            //
            this.navigationService = new NavigationService();
            this.timerService = new TimerService();
        }

        public async Task InitializeAsync()
        {
            await this.navigationService.InitializeAsync();
            Log.Instance.Debug("Complete", GetType().ToString());

        }
        public LogonViewModel Logon
        {
            get
            {
                if (this.logonViewModel == null)
                {
                    this.logonViewModel = new LogonViewModel(this.modelFactory.GetLogonService(), this.navigationService, this.timerService);
                }

                return this.logonViewModel;
            }
        }

        public HomeViewModel Home
        {
            get
            {
                if (this.homeViewModel == null)
                {
                    this.homeViewModel = new HomeViewModel(this.modelFactory.GetUserService(), this.navigationService, this.appSettings);
                }

                return this.homeViewModel;
            }
        }

        public AboutViewModel About
        {
            get
            {
                if (this.aboutViewModel == null)
                {
                    this.aboutViewModel = new AboutViewModel(null, null);
                }

                return this.aboutViewModel;
            }
        }
    }
}
