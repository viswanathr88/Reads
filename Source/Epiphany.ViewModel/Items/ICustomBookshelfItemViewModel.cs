using Epiphany.Model;

namespace Epiphany.ViewModel
{
    public interface ICustomBookshelfItemViewModel
    {
        BookshelfModel Bookshelf { get; }
        bool IsEnabled { get; set; }
    }
}