using System;
using Epiphany.Model;

namespace Epiphany.ViewModel.Items
{
    public class BookshelfItemViewModel : ItemViewModel<BookshelfModel>, IBookshelfItemViewModel
    {
        private readonly UserModel user;

        public BookshelfItemViewModel(UserModel user, BookshelfModel model) : 
            base(model) 
        {
            this.user = user;
        }

        public long ShelfId
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

        public IUserItemViewModel User
        {
            get
            {
                return new UserItemViewModel(this.user);
            }
        }
    }
}
