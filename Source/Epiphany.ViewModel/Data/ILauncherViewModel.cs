using Epiphany.Model.Authentication;
using Epiphany.ViewModel.Commands;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public interface ILauncherViewModel : IDataViewModel
    {
        Session CurrentSession { get; }
        ICommand<Session> ShowBookshelves { get; }
        ICommand ShowEvents { get; }
        ICommand<Session> ShowFriends { get; }
        ICommand<Session> ShowGroups { get; }
        ICommand<Session> ShowProfile { get; }
        ICommand ShowSearch { get; }
    }
}