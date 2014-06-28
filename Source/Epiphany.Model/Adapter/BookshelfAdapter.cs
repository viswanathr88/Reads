using Epiphany.Xml;

namespace Epiphany.Model.Adapter
{
    class BookshelfAdapter : IAdapter<BookshelfModel, GoodreadsUserShelf>
    {
        public BookshelfModel Convert(GoodreadsUserShelf item)
        {
            BookshelfModel shelf = new BookshelfModel(item.Id)
            {
                Name = item.Name,
                BooksCount = Converter.ToInt(item.BookCount, 0),
                Description = item.Description,
                IsExclusive = Converter.ToBool(item.IsExclusive, false),
                IsFeatured = Converter.ToBool(item.IsFeatured, false),
                IsSticky = Converter.ToBool(item.IsSticky, false)
            };

            return shelf;
        }
    }
}
