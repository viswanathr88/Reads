using System;

namespace Epiphany.Model.Authentication
{
    /// <summary>
    /// Represents an auth token
    /// </summary>
    public class Token
    {
        private string token;
        private string tokenSecret;
        /// <summary>
        /// Creates an auth token
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="tokenSecret">token secret</param>
        public Token(string token, string tokenSecret)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(tokenSecret))
                throw new ArgumentNullException("token", "token or secret cannot be null");

            this.token = token;
            this.tokenSecret = tokenSecret;
        }
        /// <summary>
        /// Gets the token
        /// </summary>
        public string AuthToken
        {
            get { return this.token; }
        }
        /// <summary>
        /// Gets the token secret
        /// </summary>
        public string TokenSecret
        {
            get { return this.tokenSecret; }
        }
    }
}
