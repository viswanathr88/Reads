using Epiphany.Xml;

namespace Epiphany.Model.Adapter
{
    public class OwnedBookAdapter : IAdapter<BookModel, GoodreadsOwnedBook>
    {
        public BookModel Convert(GoodreadsOwnedBook item)
        {
            GoodreadsBook book = item.Book;
            book.UserReview = item.Review;

            return new BookModel(book);
        }
    }
}
