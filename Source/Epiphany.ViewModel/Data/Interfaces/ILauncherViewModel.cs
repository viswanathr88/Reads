using Epiphany.Model.Authentication;
using Epiphany.ViewModel.Commands;
using System.Windows.Input;
namespace Epiphany.ViewModel
{
    public interface ILauncherViewModel : IDataViewModel
    {
        /// <summary>
        /// Shows My Books
        /// </summary>
        ICommand<Session> ShowBookshelves { get; }
        /// <summary>
        /// Shows Events View
        /// </summary>
        ICommand ShowEvents { get; }
        /// <summary>
        /// Show Friends View
        /// </summary>
        ICommand<Session> ShowFriends { get; }
        /// <summary>
        /// Show Groups View
        /// </summary>
        ICommand<Session> ShowGroups { get; }
        /// <summary>
        /// Show Profile View
        /// </summary>
        ICommand<Session> ShowProfile { get; }
        /// <summary>
        /// Show Search View
        /// </summary>
        ICommand ShowSearch { get; }
        /// <summary>
        /// Gets the current session with user information
        /// </summary>
        Session CurrentSession { get; }
    }
}
