
using Epiphany.Model;
namespace Epiphany.ViewModel
{
    public sealed class CustomBookshelfItemViewModel : ViewModelBase, ICustomBookshelfItemViewModel
    {
        private bool isEnabled;
        private BookshelfModel bookshelf;

        public CustomBookshelfItemViewModel(BookshelfModel bookshelf, bool isEnabled)
        {
            Bookshelf = bookshelf;
            IsEnabled = isEnabled;
        }

        public BookshelfModel Bookshelf
        {
            get { return this.bookshelf; }
            private set
            {
                if (this.bookshelf == value) return;
                this.bookshelf = value;
                RaisePropertyChanged();
            }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set
            {
                if (this.isEnabled == value) return;
                this.isEnabled = value;
                RaisePropertyChanged();
            }
        }
    }
}
