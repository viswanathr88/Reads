using Epiphany.Logging;
using Epiphany.Model.Authentication;

namespace Epiphany.Web
{
    /// <summary>
    /// Represents the Factory to create authenticators
    /// </summary>
    public sealed class AuthenticatorFactory : IAuthenticatorFactory
    {
        private AuthConfig config = new AuthConfig();
        private Token currentToken;
        /// <summary>
        /// Create an oauth authenticator
        /// </summary>
        /// <returns></returns>
        public IAuthenticator CreateOAuthAuthenticator()
        {
            IAuthenticator authenticator = null;
            if (currentToken == null)
            {
                authenticator = new OAuth1Authenticator(config.ConsumerKey, config.ConsumerKeySecret);
            }
            else
            {
                authenticator = new OAuth1Authenticator(config.ConsumerKey, config.ConsumerKeySecret,
                    currentToken.AuthToken, currentToken.TokenSecret);
            }

            return authenticator;
        }
        /// <summary>
        /// Callback when the current token changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnTokenChanged(object sender, TokenChangedEventArgs e)
        {
            Logger.LogDebug("New token received." + e.NewToken?.AuthToken);
            this.currentToken = e.NewToken;
        }
    }
}
