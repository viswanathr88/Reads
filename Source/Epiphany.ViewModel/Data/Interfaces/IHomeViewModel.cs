using System;
using System.Windows.Input;
namespace Epiphany.ViewModel
{
    public interface IHomeViewModel : IDataViewModel
    {
        /// <summary>
        /// Gets the feed VM
        /// </summary>
        IFeedViewModel Feed { get; }
        /// <summary>
        /// Get the launcher
        /// </summary>
        ILauncherViewModel Launcher { get; }
        /// <summary>
        /// Gets the count of new notifications
        /// </summary>
        int NewNotificationCount { get; }
        /// <summary>
        /// Shows the about info
        /// </summary>
        ICommand ShowAbout { get; }
        /// <summary>
        /// Shows notifications
        /// </summary>
        ICommand ShowNotifications { get; }
        /// <summary>
        /// Shows Settings
        /// </summary>
        ICommand ShowSettings { get; }
    }
}
