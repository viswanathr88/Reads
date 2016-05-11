using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public sealed class MyBooksViewModel : DataViewModel<int>, IMyBooksViewModel
    {
        private readonly IBookService bookService;

        private IList<IBookItemViewModel> currentlyReadingBooks;
        private IList<IBookItemViewModel> readingChallengeBooks;
        private IList<IBookItemViewModel> ownedBooks;

        private bool isCurrentlyReadingBooksLoading;
        private bool isReadingChallengeBooksLoading;
        private bool isOwnedBooksLoading;

        public MyBooksViewModel(IBookService bookService)
        {
            if (bookService == null)
            {
                throw new ArgumentNullException(nameof(bookService));
            }

            this.bookService = bookService;
        }

        public IList<IBookItemViewModel> CurrentlyReadingBooks
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

        public IList<IBookItemViewModel> ReadingChallengeBooks
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

        public IList<IBookItemViewModel> OwnedBooks
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

        public bool IsCurrentlyReadingBooksLoading
        {
            get
            {
                return this.isCurrentlyReadingBooksLoading;
            }
            private set
            {
                SetProperty(ref this.isCurrentlyReadingBooksLoading, value);
            }
        }

        public bool IsReadingChallengeBooksLoading
        {
            get
            {
                return this.isReadingChallengeBooksLoading;
            }
            private set
            {
                SetProperty(ref this.isReadingChallengeBooksLoading, value);
            }
        }

        public bool IsOwnedBooksLoading
        {
            get
            {
                return this.isOwnedBooksLoading;
            }
            private set
            {
                SetProperty(ref this.isOwnedBooksLoading, value);
            }
        }

        public override Task LoadAsync(int userId)
        {
            // Create collection for currently-reading
            var currentlyReadingCollection = new ObservablePagedCollection<IBookItemViewModel, BookModel>(
                this.bookService.GetBooks(userId, "currently-reading", BookSortType.date_added, BookSortOrder.d),
                (book) => new BookItemViewModel(book));
            currentlyReadingCollection.Loading += (sender, arg) => IsCurrentlyReadingBooksLoading = true;
            currentlyReadingCollection.Loaded += (sender, arg) => IsCurrentlyReadingBooksLoading = false;
            CurrentlyReadingBooks = currentlyReadingCollection;

            // Create collection for reading challenge
            var readingChallengeCollection = new ObservablePagedCollection<IBookItemViewModel, BookModel>(
                this.bookService.GetBooksByYear(userId, DateTime.Now.Year),
                (book) => new BookItemViewModel(book));
            readingChallengeCollection.Loading += (sender, arg) => IsReadingChallengeBooksLoading = true;
            readingChallengeCollection.Loaded += (sender, arg) => IsReadingChallengeBooksLoading = false;
            ReadingChallengeBooks = readingChallengeCollection;

            // Create collection for owned books
            var ownedBooksChallenge = new ObservablePagedCollection<IBookItemViewModel, BookModel>(
                this.bookService.GetOwnedBooks(userId),
                (book) => new BookItemViewModel(book));
            ownedBooksChallenge.Loading += (sender, arg) => IsOwnedBooksLoading = true;
            ownedBooksChallenge.Loaded += (sender, arg) => IsOwnedBooksLoading = false;
            OwnedBooks = ownedBooksChallenge;

            return Task.FromResult<bool>(true);
        }
    }
}
