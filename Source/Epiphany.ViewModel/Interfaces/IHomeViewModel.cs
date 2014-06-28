using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public interface IHomeViewModel : INotifyPropertyChanged, IDisposable
    {
        int NewNotificationCount
        {
            get;
        }
        IFeedViewModel FeedViewModel
        {
            get;
        }

        ILauncherViewModel LauncherViewModel
        {
            get;
        }

        ICommand ShowNotifications
        {
            get;
        }

        ICommand ShowAbout
        {
            get;
        }
    }
}
