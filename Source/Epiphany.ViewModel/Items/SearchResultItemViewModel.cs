using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using System;
using System.Linq;

namespace Epiphany.ViewModel.Items
{
    public sealed class SearchResultItemViewModel : ItemViewModel<WorkModel>, ISearchResultItemViewModel
    {
        private IBookItemViewModel book;
        private IAuthorItemViewModel author;

        private readonly IBookService bookService;
        private readonly IAsyncCommand<BookModel> addToReadingListCommand;
        private readonly IAsyncCommand<BookModel> removeFromReadingList;

        public SearchResultItemViewModel(IBookService bookService, WorkModel work)
            : base(work)
        {

            if (bookService == null)
            {
                throw new ArgumentNullException(nameof(bookService));
            }

            this.bookService = bookService;

            this.addToReadingListCommand = new AddToReadingListCommand(bookService);
            this.addToReadingListCommand.Executing += OnCommandExecuting;
            this.addToReadingListCommand.Executed += AddToReadingListCommand_Executed;

            this.removeFromReadingList = new RemoveFromReadingListCommand(bookService);
            this.removeFromReadingList.Executing += OnCommandExecuting;
            this.removeFromReadingList.Executed += RemoveFromReadingList_Executed;

            Book = new BookItemViewModel(work.Book);
            Author = new AuthorItemViewModel(work.Book.Authors.FirstOrDefault());
        }

        public IBookItemViewModel Book
        {
            get { return this.book; }
            private set
            {
                SetProperty(ref this.book, value);
            }
        }

        public IAuthorItemViewModel Author
        {
            get { return this.author; }
            private set
            {
                SetProperty(ref this.author, value);
            }
        }

        public double AverageRating
        {
            get
            {
                return Item.AverageRating;
            }
        }

        public int RatingsCount
        {
            get
            {
                return Item.RatingsCount;
            }
        }

        public bool Reviewed
        {
            get
            {
                return (Item.Book != null && Item.Book.UserReview != null);
            }
        }

        public IAsyncCommand<BookModel> AddToReadingList
        {
            get
            {
                return this.addToReadingListCommand;
            }
        }

        public IAsyncCommand<BookModel> RemoveFromReadingList
        {
            get
            {
                return this.removeFromReadingList;
            }
        }

        private void OnCommandExecuting(object sender, CancelEventArgs e)
        {
            IsLoading = true;
        }

        private void AddToReadingListCommand_Executed(object sender, ExecutedEventArgs e)
        {
            IsLoading = false;
            RaisePropertyChanged(nameof(Reviewed));
        }

        private void RemoveFromReadingList_Executed(object sender, ExecutedEventArgs e)
        {
            IsLoading = false;
            RaisePropertyChanged(nameof(Reviewed));
        }
    }
}
