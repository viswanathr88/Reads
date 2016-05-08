using System.Threading.Tasks;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public interface IHomeViewModel : IDataViewModel
    {
        IFeedViewModel Feed { get; }
        IBookshelvesViewModel Books { get; }
        bool IsLoggedIn { get; }
        ILauncherViewModel Launcher { get; }
        int NewNotificationCount { get; }
        double Opacity { get; }
        ICommand ShowAbout { get; }
        ICommand ShowNotifications { get; }
        ICommand ShowSettings { get; }
    }
}