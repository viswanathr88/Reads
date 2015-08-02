using Epiphany.ViewModel.Commands;
using System;

namespace Epiphany.ViewModel
{
    public interface ILogonViewModel : IDataViewModel
    {
        /// <summary>
        /// Command to check a given uri for logon completion
        /// </summary>
        ICommand<bool, Uri> CheckUriForLoginCompletion { get; }
        /// <summary>
        /// Gets or sets the current uri
        /// </summary>
        Uri CurrentUri { get; set; }
        /// <summary>
        /// Returns true if login has completed
        /// </summary>
        bool IsLoginCompleted { get; }
        /// <summary>
        /// Returns true if sign in is taking longer than user
        /// </summary>
        bool IsSignInTakingLonger { get; }
        /// <summary>
        /// Returns true if the VM is waiting for some user interaction during login
        /// </summary>
        bool IsWaitingForUserInteraction { get; }
        /// <summary>
        /// Starts the login process
        /// </summary>
        ICommand<Uri, VoidType> Login { get; }
    }
}
