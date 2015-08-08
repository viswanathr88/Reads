using Epiphany.Model;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System.Linq;

namespace Epiphany.ViewModel
{
    public class SearchResultItemViewModel : ViewModelBase
    {
        private readonly ICommand<BookModel> showBook;
        private readonly ICommand<AuthorModel> showAuthor;
        private BookModel book;
        private AuthorModel author;

        public SearchResultItemViewModel(BookModel book, INavigationService navService)
        {
            this.showBook = new ShowBookCommand(navService);
            this.showAuthor = new ShowAuthorCommand(navService);
            Book = book;
            Author = book.Authors.FirstOrDefault();
        }

        public BookModel Book
        {
            get { return this.book; }
            private set
            {
                if (this.book == value) return;
                this.book = value;
                RaisePropertyChanged();
            }
        }

        public AuthorModel Author
        {
            get { return this.author; }
            private set
            {
                if (this.author == value) return;
                this.author = value;
                RaisePropertyChanged();
            }
        }

        public ICommand<BookModel> ShowBook
        {
            get { return this.showBook; }
        }

        public ICommand<AuthorModel> ShowAuthor
        {
            get { return this.showAuthor; }
        }
    }
}
