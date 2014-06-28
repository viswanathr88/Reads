using Epiphany.Xml;
using System;

namespace Epiphany.Model
{
    public class UserStatusFeedItemModel : FeedItemModel
    {
        private readonly GoodreadsUserStatus userStatus;

        internal UserStatusFeedItemModel(GoodreadsUpdate update) 
            : base(update)
        {
            this.userStatus = update.Object.UserStatus;
            if (this.userStatus == null)
            {
                this.userStatus = new GoodreadsUserStatus();
            }
        }

        protected override int GetId(GoodreadsUpdate update)
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
