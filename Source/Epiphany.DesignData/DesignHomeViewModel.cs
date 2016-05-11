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

        public IBookshelvesViewModel Books
        {
            get { return new DesignBookshelvesViewModel(); }
        }

        public ICommunityViewModel Community
        {
            get { return null; }
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
