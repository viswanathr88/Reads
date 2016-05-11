namespace Epiphany.ViewModel
{
    public interface IHomeViewModel : IDataViewModel
    {
        IFeedViewModel Feed { get; }
        IBookshelvesViewModel Books { get; }
        ILauncherViewModel Launcher { get; }
        ICommunityViewModel Community { get; }
        bool IsLoggedIn { get; }
        int NewNotificationCount { get; }
        double Opacity { get; }
    }
}