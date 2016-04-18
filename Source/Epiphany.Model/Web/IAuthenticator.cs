namespace Epiphany.Web
{
    /// <summary>
    /// Represents an interface that all authenticators need to implement
    /// </summary>
    public interface IAuthenticator
    {
        /// <summary>
        /// Authenticate the web request
        /// </summary>
        /// <param name="request">Web request</param>
        void Authenticate(WebRequest request);
    }
}
