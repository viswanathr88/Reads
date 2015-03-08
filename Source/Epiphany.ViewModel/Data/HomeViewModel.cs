using Epiphany.Model.Services;
using Epiphany.Settings;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public class HomeViewModel : DataViewModel<VoidType>
    {
        private readonly IUserService userService;
        private readonly INavigationService navigationService;
        private readonly IAppSettings appSettings;

        private FeedViewModel feedViewModel;

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

        public override void Load(VoidType param)
        {
            if (!FeedViewModel.IsLoaded)
            {
                FeedViewModel.Load(param);
            }
        }

        public int NewNotificationCount
        {
            get { throw new NotImplementedException(); }
        }

        public FeedViewModel FeedViewModel
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
