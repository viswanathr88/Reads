using Epiphany.Model.Authentication;
using System.Text.RegularExpressions;

namespace Epiphany.View.Services
{
    class TokenParser
    {
        /// <summary>
        /// Parse OAuth token and secret from the webresponse
        /// </summary>
        /// <uri name="response">The web response string</uri>
        /// <returns>True if parsing succeeded, false otherwise</returns>
        public bool TryParseTokens(string responseText, out Token token)
        {
            token = null;
            var pattern = string.Format("oauth_token={0}&oauth_token_secret={1}", "(.+?)", "(.+)");
            Regex regex = new Regex(pattern);
            Match match;
            if ((match = regex.Match(responseText)).Success == false)
            {
                return false;
            }
            else
            {
                string oAuthToken = string.Empty;
                string oAuthTokenSecret = string.Empty;
                oAuthToken = match.Groups[1].ToString();
                oAuthTokenSecret = match.Groups[2].ToString();
                token = new Token(oAuthToken, oAuthTokenSecret);
                return true;
            }
        }
    }
}
