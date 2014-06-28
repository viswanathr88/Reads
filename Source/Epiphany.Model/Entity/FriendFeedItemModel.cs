using Epiphany.Xml;

namespace Epiphany.Model
{
    public sealed class FriendFeedItemModel : FeedItemModel
    {
        private readonly int id;
        private readonly string name;

        internal FriendFeedItemModel(GoodreadsUpdate update)
            : base(update)
        {
            id = ParseIdFromLink(update.Link);
            name = ParseNameFromActionText(update.ActionText);
        }

        protected override int GetId(GoodreadsUpdate update)
        {
            return id;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        private string ParseNameFromActionText(string actionText)
        {
            string name = string.Empty;
            if (!string.IsNullOrEmpty(actionText))
            {
                name = actionText.Replace("is now friends with", "");
                name.Trim();
            }
            return name;
        }
    }
}
