namespace Epiphany.Model.Authentication
{
    /// <summary>
    /// Event args for Token changed event
    /// </summary>
    public class TokenChangedEventArgs
    {
        private Token oldToken;
        private Token newToken;
        /// <summary>
        /// Create an instance of TokenChangedEventArgs
        /// </summary>
        /// <param name="newToken">New token</param>
        /// <param name="oldToken">Old token</param>
        public TokenChangedEventArgs(Token newToken, Token oldToken)
        {
            this.newToken = newToken;
            this.oldToken = oldToken;
        }
        /// <summary>
        /// Gets the new token
        /// </summary>
        public Token NewToken
        {
            get
            {
                return this.newToken;
            }
        }
        /// <summary>
        /// Gets the old token
        /// </summary>
        public Token OldTken
        {
            get
            {
                return this.oldToken;
            }
        }
    }
}
