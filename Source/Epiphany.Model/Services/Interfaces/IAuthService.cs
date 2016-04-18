using Epiphany.Model.Authentication;
using Epiphany.Web;
using System;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    public interface IAuthService
    {
        AuthConfig Configuration
        {
            get;
        }
        /// <summary>
        /// Requests a temporary token from the server
        /// </summary>
        /// <returns></returns>
        Task RequestTemporaryToken();
        /// <summary>
        /// Gets a permanent token
        /// </summary>
        /// <returns>Token</returns>
        Task<Token> GetToken();
        /// <summary>
        /// Gets the authorize uri
        /// </summary>
        /// <returns>Uri</returns>
        Uri GetAuthorizeUri();
        /// <summary>
        /// Gets the credential for the currently logged in user
        /// </summary>
        /// <returns>credential</returns>
        Task<Credential> GetCredentialAsync();
        /// <summary>
        /// Logs the current user out
        /// </summary>
        /// <returns></returns>
        Task Logout();
        /// <summary>
        /// Returns true if a cached token is available
        /// </summary>
        bool IsCachedTokenAvailable
        {
            get;
        }
        /// <summary>
        /// Returns true if a cached credential is available
        /// </summary>
        bool IsCachedCredentialAvailable
        {
            get;
        }
        /// <summary>
        /// Gets token from previous session. Should call this after calling IsCachedTokenAvailable
        /// </summary>
        /// <returns></returns>
        Token GetCachedToken();
        /// <summary>
        /// Gets credential from previous session. Should call this after calling IsCachedCredential available
        /// </summary>
        /// <returns></returns>
        Credential GetCachedCredential();
        /// <summary>
        /// Returns the web client that can perform authenticated web methods
        /// </summary>
        /// <returns></returns>
        IWebClient GetAuthCapableWebClient();
    }
}
