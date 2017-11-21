using Epiphany.Xml;

namespace Epiphany.Model
{
    public sealed class FriendFeedItemModel : FeedItemModel
    {
        private readonly long id;
        private readonly string name;

        private UserModel friend;

        internal FriendFeedItemModel(GoodreadsUpdate update)
            : base(update)
        {
            id = ParseIdFromLink(update.Link);
            name = ParseNameFromActionText(update.ActionText);

            GoodreadsUser user = new GoodreadsUser()
            {
                Id = id,
                Name = name,
                ImageUrl = update.ImageUrl
            };

            Friend = new UserModel(user);
        }

        protected override long GetId(GoodreadsUpdate update)
        {
            return id;
        }

        public UserModel Friend
        {
            get { return this.friend; }
            private set
            {
                if (this.friend == value) return;
                this.friend = value;
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
