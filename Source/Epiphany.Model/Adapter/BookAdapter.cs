using Epiphany.Xml;

namespace Epiphany.Model.Adapter
{
    class BookAdapter : IAdapter<BookModel, GoodreadsBook>
    {
        public BookModel Convert(GoodreadsBook item)
        {
            return new BookModel(item);
        }
    }

    class ReviewToBookAdapter : IAdapter<BookModel, GoodreadsReview>
    {
        public BookModel Convert(GoodreadsReview item)
        {
            return new BookModel(item);
        }
    }
}
