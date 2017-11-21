using Epiphany.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiphany.Model
{
    public enum FeedItemType
    {
        Review,
        Comment,
        UserStatus,
        Friend,
        ReadStatus,
        UserChallenge
    };

    public abstract class FeedItemModel : Entity<long>
    {
        private readonly GoodreadsUpdate update;
        private FeedItemType itemType;

        internal FeedItemModel(GoodreadsUpdate update)
        {
            this.update = update;
            itemType = ToFeedItemType(update.Type);
        }

        public override long Id
        {
            get
            {
                return GetId(update);
            }
        }

        public FeedItemType ItemType
        {
            get
            {
                return this.itemType;
            }
        }

        public UserModel User
        {
            get
            {
                return new UserModel(this.update.Actor);
            }
        }

        public string ActionText
        {
            get
            {
                return this.update.ActionText;
            }
            protected set
            {
                this.update.ActionText = value;
            }
        }

        public string Link
        {
            get
            {
                return this.update.Link;
            }
        }

        public string ImageUrl
        {
            get
            {
                return this.update.ImageUrl;
            }
        }

        public DateTime UpdateTime
        {
            get
            {
                return Converter.ToDateTime(this.update.UpdatedAt);
            }
        }

        public string Body
        {
            get
            {
                return this.update.Body;
            }
        }

        private FeedItemType ToFeedItemType(string strType)
        {
            FeedItemType itemType = FeedItemType.Review;
            //
            // This should throw an exception if an unknown feed item type is encountered
            //
            itemType = (FeedItemType)Enum.Parse(typeof(FeedItemType), strType, true);

            return itemType;
        }

        protected abstract long GetId(GoodreadsUpdate update);

        protected long ParseIdFromLink(string link)
        {
            long id = -1;
            if (!string.IsNullOrEmpty(link))
            {
                // Get the Id from the Link.
                // Uri.Segments is not available in PCL
                char[] separators = new char[1];
                separators[0] = '/';
                string[] parts = link.Split(separators);
                if (parts.Length != 0)
                {
                    separators[0] = '-';
                    string[] parts2 = parts[parts.Length - 1].Split(separators);
                    if (parts2.Length != 0)
                        id = long.Parse(parts2[0]);
                    else
                        id = long.Parse(parts[parts.Length - 1]);
                }
            }
            return id;
        }
    }
}
