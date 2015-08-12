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

            // Goodreads returns the book image not as part of the book
            // but as part of the feed item itself. So let's set the 
            // image url as the book image url
            if (this.book != null)
            {
                string imageUrl = string.IsNullOrEmpty(this.book.ImageUrl) ? this.book.SmallImageUrl : this.book.ImageUrl;
                if (string.IsNullOrEmpty(imageUrl))
                {
                    this.book.ImageUrl = this.ImageUrl;
                }
            }
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
