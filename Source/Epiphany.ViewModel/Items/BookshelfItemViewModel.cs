using Epiphany.Model;

namespace Epiphany.ViewModel.Items
{
    public class BookshelfItemViewModel : ItemViewModel<BookshelfModel>, IBookshelfItemViewModel
    {

        public BookshelfItemViewModel(BookshelfModel model) : 
            base(model) 
        {
        }

        public int ShelfId
        {
            get { return this.Item.Id; }
        }

        public string Name
        {
            get { return this.Item.Name; }
        }

        public int NumberOfBooks
        {
            get { return this.Item.BooksCount; }
        }
    }
}
