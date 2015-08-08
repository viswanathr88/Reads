using Epiphany.Model;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System.Linq;

namespace Epiphany.ViewModel.Items
{
    public sealed class SearchResultItemViewModel : ViewModelBase, ISearchResultItemViewModel
    {
        private readonly ICommand<IBookItemViewModel> showBook;
        private readonly ICommand<IAuthorItemViewModel> showAuthor;
        private IBookItemViewModel book;
        private IAuthorItemViewModel author;

        public SearchResultItemViewModel(BookModel book, INavigationService navService)
        {
            this.showBook = new ShowBookFromItemCommand(navService);
            this.showAuthor = new ShowAuthorFromItemCommand(navService);
            Book = new BookItemViewModel(book);
            Author = new AuthorItemViewModel(book.Authors.FirstOrDefault());
        }

        public IBookItemViewModel Book
        {
            get { return this.book; }
            private set
            {
                if (this.book == value) return;
                this.book = value;
                RaisePropertyChanged();
            }
        }

        public IAuthorItemViewModel Author
        {
            get { return this.author; }
            private set
            {
                if (this.author == value) return;
                this.author = value;
                RaisePropertyChanged();
            }
        }

        public ICommand<IBookItemViewModel> ShowBook
        {
            get { return this.showBook; }
        }

        public ICommand<IAuthorItemViewModel> ShowAuthor
        {
            get { return this.showAuthor; }
        }
    }
}
