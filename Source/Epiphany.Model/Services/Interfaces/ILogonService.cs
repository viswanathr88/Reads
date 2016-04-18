using Epiphany.Model.Authentication;
using System;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    /// <summary>
    /// Represents the state of authentication
    /// </summary>
    public enum LogonState
    {
        NotConnected,
        Connecting,
        Connected
    };
    /// <summary>
    /// Interface for a logon service
    /// </summary>
    public interface ILogonService
    {
        /// <summary>
        /// Gets the configuration
        /// </summary>
        AuthConfig Configuration
        {
            get;
        }
        /// <summary>
        /// Get the session
        /// </summary>
        Session Session
        {
            get;
        }
        /// <summary>
        /// Get the current token used for authentication
        /// </summary>
        Token ActiveToken
        {
            get;
        }
        /// <summary>
        /// Get the auth state
        /// </summary>
        LogonState State
        {
            get;
        }
        /// <summary>
        /// Begin login
        /// </summary>
        /// <returns>The uri to be authenticated against</returns>
        Task<Uri> StartLogin();
        /// <summary>
        /// Complete login. The user is authenticated after this
        /// </summary>
        /// <returns></returns>
        Task FinishLogin();
        /// <summary>
        /// Verify if the user is logged in
        /// </summary>
        /// <returns>True, if the user is logged in,  False otherwise</returns>
        Task<bool> TryVerifyLogin();
        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        Task Logout();
        /// <summary>
        /// Event that is raised when the session changes
        /// </summary>
        event EventHandler<SessionChangedEventArgs> SessionChanged;
        /// <summary>
        /// Event that is raised when the token changes
        /// </summary>
        event EventHandler<TokenChangedEventArgs> TokenChanged;
    }
}
