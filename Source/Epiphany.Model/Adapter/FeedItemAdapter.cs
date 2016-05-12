using Epiphany.Logging;
using Epiphany.Xml;

namespace Epiphany.Model.Adapter
{
    class FeedItemAdapter : IAdapter<FeedItemModel, GoodreadsUpdate>
    {
        public FeedItemModel Convert(GoodreadsUpdate item)
        {
            FeedItemModel model = null;
            switch (item.Type.ToLower())
            {
                case "friend":
                    model = new FriendFeedItemModel(item);
                    break;
                case "review":
                    model = new ReviewFeedItemModel(item);
                    break;
                case "userstatus":
                    model = new UserStatusFeedItemModel(item);
                    break;
                case "readstatus":
                    model = new ReadStatusFeedItemModel(item);
                    break;
                case "userchallenge":
                    model = new UserChallengeFeedItemModel(item);
                    break;
                default:
                    Logger.LogWarn($"Unknown Type {item.Type} received");
                    model = null;
                    break;
            }

            return model;
        }
    }
}
