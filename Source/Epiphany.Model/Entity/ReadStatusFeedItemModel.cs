using Epiphany.Xml;
using System;

namespace Epiphany.Model
{
    public sealed class ReadStatusFeedItemModel : FeedItemModel
    {
        private readonly GoodreadsReadStatus readStatus;

        public ReadStatusFeedItemModel(GoodreadsUpdate update)
            : base(update)
        {
            this.readStatus = update.Object.ReadStatus;
            if (this.readStatus == null)
            {
                this.readStatus = new GoodreadsReadStatus();
            }
        }

        protected override long GetId(GoodreadsUpdate update)
        {
            return update.Object.ReadStatus.Id;
        }

        public int ReviewId
        {
            get
            {
                return Converter.ToInt(this.readStatus.ReviewId, 0);
            }
        }

        public string Status
        {
            get
            {
                return this.readStatus.Status;
            }
        }

        public DateTime StatusUpdateTime
        {
            get
            {
                return Converter.ToDateTime(this.readStatus.UpdatedAt);
            }
        }

        public BookModel Book
        {
            get
            {
                return new BookModel(this.readStatus.Review.Book);
            }
        }

        public int UserId
        {
            get
            {
                return Converter.ToInt(this.readStatus.UserId, 0);
            }
        }
    }
}
