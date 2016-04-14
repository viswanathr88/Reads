﻿using System;
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
        private readonly IAppRateService appRateService;
        private readonly IUrlLauncher urlLauncher;
        private readonly IResourceLoader resourceLoader;
        private readonly ILocationService locationService;

        private LogonViewModel logonVM;
        private HomeViewModel homeVM;

        public RuntimeViewModelLocator()
        {
            IAuthService authService = new AuthService();
            this.serviceFactory = new ServiceFactory(authService);

            // Set up services
            this.navigationService = new NavigationService();
            this.timerService = new TimerService();
            this.appRateService = new AppRateService();
            this.urlLauncher = new UrlLauncher();
            this.resourceLoader = new ResourceLoader();
            this.locationService = new LocationService();
        }

        public HomeViewModel Home
        {
            get
            {
                if (this.homeVM == null)
                {
                    this.homeVM = new HomeViewModel(this.serviceFactory.GetUserService(), this.serviceFactory.GetLogonService(), 
                        this.navigationService, this.resourceLoader);
                }

                return this.homeVM;
            }
        }

        public LogonViewModel Logon
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

        public ProfileViewModel Profile
        {
            get
            {
                return new ProfileViewModel(
                    this.serviceFactory.GetUserService(), 
                    this.serviceFactory.GetBookshelfService(), 
                    this.navigationService,
                    this.urlLauncher,
                    this.resourceLoader);
            }
        }

        public AboutViewModel About
        {
            get
            {
                return new AboutViewModel(this.appRateService, this.urlLauncher);
            }
        }

        public AddBookViewModel AddBook
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

        public BooksViewModel Books
        {
            get { return new BooksViewModel(); }
        }

        public FriendsViewModel Friends
        {
            get { return new FriendsViewModel(this.serviceFactory.GetUserService(), this.navigationService, this.resourceLoader); }
        }

        public EventsViewModel Events
        {
            get { return new EventsViewModel(this.serviceFactory.GetEventService(), this.locationService, this.urlLauncher); }
        }

        public SearchViewModel Search
        {
            get { return new SearchViewModel(this.serviceFactory.GetBookService(), this.navigationService); }
        }

        public AuthorViewModel Author
        {
            get { return new AuthorViewModel(this.serviceFactory.GetAuthorService(), this.serviceFactory.GetBookService(), this.navigationService); }
        }

        public SettingsViewModel Settings
        {
            get { return new SettingsViewModel(); }
        }

        public BookViewModel Book
        {
            get { return new BookViewModel(); }
        }

        public void Dispose()
        {

        }
    }
}
