using Epiphany.ViewModel;
using System.Windows.Input;

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
            get
            {
                return new DesignBookshelvesViewModel();
            }
        }

        public IFeedViewModel Feed
        {
            get { return new DesignFeedViewModel(); }
        }

        public bool IsLoggedIn
        {
            get;
            set;
        }

        public ILauncherViewModel Launcher
        {
            get;
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

        public ICommand ShowAbout
        {
            get;
        }

        public ICommand ShowNotifications
        {
            get;
        }

        public ICommand ShowSettings
        {
            get;
        }
    }
}
