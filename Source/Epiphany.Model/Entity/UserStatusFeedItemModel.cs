using Epiphany.Xml;
using System;
using System.Text.RegularExpressions;

namespace Epiphany.Model
{
    public class UserStatusFeedItemModel : FeedItemModel
    {
        private GoodreadsUserStatus userStatus;

        internal UserStatusFeedItemModel(GoodreadsUpdate update) 
            : base(update)
        {
            if (update.Object == null)
            {
                throw new ArgumentNullException(nameof(update.Object));
            }
            else
            {
                this.userStatus = update.Object.UserStatus;
                if (this.userStatus == null)
                {
                    this.userStatus = new GoodreadsUserStatus();
                }
            }
        }

        protected override long GetId(GoodreadsUpdate update)
        {
            return this.userStatus.Id;
        }

        public int Page
        {
            get
            {
                return Converter.ToInt(userStatus.Page, 0);
            }
        }

        public int Percentage
        {
            get
            {
                return Converter.ToInt(userStatus.Percent, 0);
            }
        }

        public BookModel Book
        {
            get
            {
                return new BookModel(userStatus.Book);
            }
        }
    }
}
