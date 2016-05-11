namespace Epiphany.ViewModel
{
    public interface IHomeViewModel : IDataViewModel
    {
        IFeedViewModel Feed { get; }
        IMyBooksViewModel Books { get; }
        ILauncherViewModel Launcher { get; }
        ICommunityViewModel Community { get; }
        bool IsLoggedIn { get; }
        int NewNotificationCount { get; }
        double Opacity { get; }
    }
}