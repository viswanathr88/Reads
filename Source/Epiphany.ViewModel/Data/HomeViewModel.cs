using Epiphany.Model.Services;
using Epiphany.Settings;
using Epiphany.ViewModel.Services;
using System;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    sealed class HomeViewModel : DataViewModel, IHomeViewModel
    {
        private readonly IUserService userService;
        private readonly INavigationService navigationService;
        private readonly IAppSettings appSettings;

        private IFeedViewModel feedViewModel;

        public HomeViewModel(IUserService userService, INavigationService navigationService, IAppSettings settings)
        {
            if (userService == null || navigationService == null || settings == null)
            {
                throw new ArgumentNullException();
            }

            this.userService = userService;
            this.navigationService = navigationService;
            this.appSettings = settings;
        }

        public override void Load()
        {
            if (!FeedViewModel.IsLoaded)
            {
                //FeedViewModel.Load(param);
            }
        }

        public int NewNotificationCount
        {
            get { throw new NotImplementedException(); }
        }

        public IFeedViewModel FeedViewModel
        {
            get
            {
                if (this.feedViewModel == null)
                {
                    this.feedViewModel = new FeedViewModel(userService, navigationService, appSettings);
                }

                return this.feedViewModel;
            }
        }

        public ICommand ShowNotifications
        {
            get { throw new NotImplementedException(); }
        }

        public ICommand ShowAbout
        {
            get { throw new NotImplementedException(); }
        }
    }
}
