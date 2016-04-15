using System;
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
        private readonly IDeviceServices deviceServices;
        private readonly IResourceLoader resourceLoader;

        private LogonViewModel logonVM;
        private HomeViewModel homeVM;

        public RuntimeViewModelLocator()
        {
            IAuthService authService = new AuthService();
            this.serviceFactory = new ServiceFactory(authService);

            // Set up services
            this.navigationService = new NavigationService();
            this.timerService = new TimerService();
            this.resourceLoader = new ResourceLoader();
        }

        public INavigationService NavigationService
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public HomeViewModel Home
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public LogonViewModel Logon
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public AddBookViewModel AddBook
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public AboutViewModel About
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ProfileViewModel Profile
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public BooksViewModel Books
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public FriendsViewModel Friends
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public EventsViewModel Events
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public SearchViewModel Search
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public AuthorViewModel Author
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public BookViewModel Book
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public SettingsViewModel Settings
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
