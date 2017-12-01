using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public sealed class MyBooksViewModel : DataViewModel<int>, IMyBooksViewModel
    {
        private readonly IBookService bookService;

        private ILazyObservableCollection<IBookItemViewModel> currentlyReadingBooks;
        private ILazyObservableCollection<IBookItemViewModel> readingChallengeBooks;
        private ILazyObservableCollection<IBookItemViewModel> ownedBooks;

        public MyBooksViewModel(IBookService bookService)
        {
            if (bookService == null)
            {
                throw new ArgumentNullException(nameof(bookService));
            }

            this.bookService = bookService;
        }

        public ILazyObservableCollection<IBookItemViewModel> CurrentlyReadingBooks
        {
            get
            {
                return this.currentlyReadingBooks;
            }
            private set
            {
                SetProperty(ref this.currentlyReadingBooks, value);
            }
        }

        public ILazyObservableCollection<IBookItemViewModel> ReadingChallengeBooks
        {
            get
            {
                return this.readingChallengeBooks;
            }
            private set
            {
                SetProperty(ref this.readingChallengeBooks, value);
            }
        }

        public ILazyObservableCollection<IBookItemViewModel> OwnedBooks
        {
            get
            {
                return this.ownedBooks;
            }
            private set
            {
                SetProperty(ref this.ownedBooks, value);
            }
        }

        public override Task LoadAsync(int userId)
        {
            // Create collection for currently-reading
            CurrentlyReadingBooks = new LazyObservablePagedCollection<IBookItemViewModel, BookModel>(
                this.bookService.GetBooks(userId, "currently-reading", BookSortType.date_added, BookSortOrder.d),
                (book) => new BookItemViewModel(book));

            // Create collection for reading challenge
            ReadingChallengeBooks = new LazyObservablePagedCollection<IBookItemViewModel, BookModel>(
                this.bookService.GetBooksByYear(userId, DateTime.Now.Year),
                (book) => new BookItemViewModel(book));

            // Create collection for owned books
            OwnedBooks = new LazyObservablePagedCollection<IBookItemViewModel, BookModel>(
                this.bookService.GetOwnedBooks(userId),
                (book) => new BookItemViewModel(book));

            return Task.FromResult<bool>(true);
        }
    }
}
