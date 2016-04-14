using Epiphany.Model;

namespace Epiphany.ViewModel.Items
{
    public class BookshelfItemViewModel : ItemViewModel<BookshelfModel>
    {
        private readonly int userId;

        public BookshelfItemViewModel(BookshelfModel model, int userId) : 
            base(model) 
        {
            this.userId = userId;
        }

        public int ShelfId
        {
            get { return this.Item.Id; }
        }

        public int UserId
        {
            get { return this.userId; }
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
