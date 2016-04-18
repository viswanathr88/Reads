namespace Epiphany.Web
{
    /// <summary>
    /// Factory interface for creating different authenticators
    /// </summary>
    public interface IAuthenticatorFactory
    {
        /// <summary>
        /// Creates an oauth authenticator
        /// /// </summary>
        /// <returns></returns>
        IAuthenticator CreateOAuthAuthenticator();
    }
}
