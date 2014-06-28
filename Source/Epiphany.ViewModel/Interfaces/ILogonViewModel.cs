using Epiphany.ViewModel.Commands;
using System;
using System.ComponentModel;

namespace Epiphany.ViewModel
{
    public interface ILogonViewModel : INotifyPropertyChanged, IDisposable
    {
        bool IsWaitingForUserInteraction
        {
            get;
        }

        bool IsSignInTakingLonger
        {
            get;
        }

        object Error
        {
            get;
        }

        Uri CurrentUri
        {
            get;
            set;
        }

        ICommand<Uri, VoidType> Login
        {
            get;
        }

        ICommand<bool, Uri> CheckUriForLoginCompletion
        {
            get;
        }
    }
}
