using Epiphany.ViewModel;
using System;
using System.Windows.Input;

namespace Epiphany.View.DesignData
{
    public sealed class DesignHomeViewModel : DataViewModel, IHomeViewModel
    {
        public IFeedViewModel Feed
        {
            get { return new DesignFeedViewModel(); }
        }

        public ILauncherViewModel Launcher
        {
            get { return null; }
        }

        public int NewNotificationCount
        {
            get { return 0; }
        }

        public ICommand ShowAbout
        {
            get { return null; }
        }

        public ICommand ShowNotifications
        {
            get { return null; }
        }

        public ICommand ShowSettings
        {
            get { return null; }
        }

        public override System.Threading.Tasks.Task LoadAsync()
        {
            throw new NotImplementedException();
        }
    }
}
