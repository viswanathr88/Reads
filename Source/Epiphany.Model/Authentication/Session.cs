
namespace Epiphany.Model.Authentication
{
    /// <summary>
    /// Represents a session, used to talk to the service
    /// </summary>
    public class Session
    {
        private string id;
        private string name;
        private string token;
        private string tokenSecret;

        internal Session(Credential credential, Token token)
        {
            this.id = credential.UserId.ToString();
            this.name = credential.Name;
            this.token = token.AuthToken;
            this.tokenSecret = token.TokenSecret;
        }
        /// <summary>
        /// Gets the user id
        /// </summary>
        public string UserId
        {
            get
            {
                return this.id;
            }
        }
        /// <summary>
        /// Gets the name of the user
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }
        /// <summary>
        /// Gets the auth token
        /// </summary>
        public string Token
        {
            get
            {
                return this.token;
            }
        }
        /// <summary>
        /// Gets the auth token secret
        /// </summary>
        public string TokenSecret
        {
            get
            {
                return this.tokenSecret;
            }
        }
    }
}
