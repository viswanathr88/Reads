using System;
using Epiphany.ViewModel;

namespace Epiphany.View.DesignData
{
    public sealed class DesignHomeViewModel : DesignBaseViewModel, IHomeViewModel
    {
        public DesignHomeViewModel()
        {
            IsLoggedIn = true;
            Opacity = 0;
        }

        public IMyBooksViewModel Books
        {
            get { return new DesignMyBooksViewModel(); }
        }

        public ICommunityViewModel Community
        {
            get;
        }

        public IFeedViewModel Feed
        {
            get { return new DesignFeedViewModel(); }
        }

        public ILauncherViewModel Launcher
        {
            get;
        }

        public bool IsLoggedIn
        {
            get;
            set;
        }

        public int NewNotificationCount
        {
            get;
        }

        public double Opacity
        {
            get;
            set;
        }
    }
}
