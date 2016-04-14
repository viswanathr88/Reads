using Epiphany.Model;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System.Linq;

namespace Epiphany.ViewModel.Items
{
    public sealed class SearchResultItemViewModel : ViewModelBase
    {
        private readonly ICommand<BookItemViewModel> showBook;
        private readonly ICommand<AuthorItemViewModel> showAuthor;
        private BookItemViewModel book;
        private AuthorItemViewModel author;

        public SearchResultItemViewModel(BookModel book, INavigationService navService)
        {
            this.showBook = new ShowBookFromItemCommand(navService);
            this.showAuthor = new ShowAuthorFromItemCommand(navService);
            Book = new BookItemViewModel(book);
            Author = new AuthorItemViewModel(book.Authors.FirstOrDefault());
        }

        public BookItemViewModel Book
        {
            get { return this.book; }
            private set
            {
                if (this.book == value) return;
                this.book = value;
                RaisePropertyChanged();
            }
        }

        public AuthorItemViewModel Author
        {
            get { return this.author; }
            private set
            {
                if (this.author == value) return;
                this.author = value;
                RaisePropertyChanged();
            }
        }

        public ICommand<BookItemViewModel> ShowBook
        {
            get { return this.showBook; }
        }

        public ICommand<AuthorItemViewModel> ShowAuthor
        {
            get { return this.showAuthor; }
        }
    }
}
