using Epiphany.ViewModel.Commands;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public interface ILauncherViewModel : INotifyPropertyChanged, IDisposable
    {
        ICommand<VoidType, int> ShowMyProfile
        {
            get;
        }

        ICommand<VoidType, int> ShowMyBooks
        {
            get;
        }

        ICommand<VoidType, int> ShowMyFriends
        {
            get;
        }

        ICommand ShowSearch
        {
            get;
        }

        ICommand ShowEvents
        {
            get;
        }

        ICommand ShowMyGroups
        {
            get;
        }
    }
}
