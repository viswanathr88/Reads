using Epiphany.Logging;
using Epiphany.Xml;
using System;
using System.Text.RegularExpressions;

namespace Epiphany.Model
{
    public sealed class UserChallengeFeedItemModel : FeedItemModel
    {
        private string readingChallengeLink;

        public UserChallengeFeedItemModel(GoodreadsUpdate update) : base(update)
        {
            GetReadingChallengeLink(update.ActionText);
        }

        public string ReadingChallengeLink
        {
            get
            {
                return readingChallengeLink;
            }
            private set
            {
                this.readingChallengeLink = value;
            }
        }

        protected override long GetId(GoodreadsUpdate update)
        {
            return 0;
        }

        private void GetReadingChallengeLink(string actionText)
        {
            Match m;
            string HRefPattern = "href\\s*=\\s*(?:[\"'](?<1>[^\"']*)[\"']|(?<1>\\S+))";

            try
            {
                m = Regex.Match(actionText, HRefPattern, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1));

                if (m.Success)
                {
                    ReadingChallengeLink = m.Groups[1].Value;
                }

                Regex regex = new Regex(HRefPattern);
                ActionText = regex.Replace(actionText, string.Empty);

            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }
    }
}
