using Epiphany.Xml;

namespace Epiphany.Model
{
    public sealed class ReviewFeedItemModel : FeedItemModel
    {
        private readonly int id;
        private readonly int rating = 0;
        private readonly GoodreadsBook book;

        public ReviewFeedItemModel(GoodreadsUpdate update)
            : base(update)
        {
            this.id = ParseIdFromLink(update.Link);
            if (update.Action != null)
            {
                rating = Converter.ToInt(update.Action.Rating, 0);
            }
            this.book = update.Object.Book;
        }

        public BookModel Book
        {
            get
            {
                return new BookModel(this.book);
            }
        }

        public int Rating
        {
            get
            {
                return this.rating;
            }
        }

        protected override int GetId(GoodreadsUpdate update)
        {
            return this.id;
        }
    }
}
