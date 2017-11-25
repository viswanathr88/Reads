using Epiphany.Model;

namespace Epiphany.ViewModel
{
    public interface IHomeViewModel : IDataViewModel
    {
        /// <summary>
        /// Get the feed
        /// </summary>
        IFeedViewModel Feed
        {
            get;
        }
        /// <summary>
        /// Gets ViewModel for Books
        /// </summary>
        IMyBooksViewModel Books
        {
            get;
        }
        /// <summary>
        /// Gets ViewModel for Launcher
        /// </summary>
        ILauncherViewModel Launcher
        {
            get;
        }
        /// <summary>
        /// Gets ViewModel for Community
        /// </summary>
        ICommunityViewModel Community
        {
            get;
        }
        /// <summary>
        /// Gets whether the user is logged in
        /// </summary>
        bool IsLoggedIn
        {
            get;
        }
        /// <summary>
        /// Gets the number of new notifications for the user
        /// </summary>
        int NewNotificationCount
        {
            get;
        }
        /// <summary>
        /// Gets the opacity to use for the background
        /// </summary>
        double Opacity
        {
            get;
        }
        /// <summary>
        /// Gets the user model for the currently logged in user
        /// </summary>
        UserModel CurrentlyLoggedInUser
        {
            get;
        }
    }
}