using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Data
{
    public sealed class MyBooksViewModel : DataViewModel<int>, IMyBooksViewModel
    {
        private IList<IObservablePagedCollection<IBookItemViewModel>> groupedItems;
        private IBookService bookService;

        public MyBooksViewModel(IBookService bookService, ILogonService logonService)
        {
            if (bookService == null)
            {
                throw new ArgumentNullException(nameof(bookService));
            }

            this.bookService = bookService;
        }

        public IList<IObservablePagedCollection<IBookItemViewModel>> GroupedItems
        {
            get
            {
                return this.groupedItems;
            }
            private set
            {
                SetProperty(ref this.groupedItems, value);
            }
        }

        public override Task LoadAsync(int userId)
        {
            // Create the collections
            GroupedItems = new ObservableCollection<IObservablePagedCollection<IBookItemViewModel>>();

            // Create collection for currently-reading
            var currentlyReadingCollection = new ObservablePagedCollection<IBookItemViewModel, BookModel>(
                this.bookService.GetBooks(userId, "currently-reading", BookSortType.date_added, BookSortOrder.a),
                (book) => new BookItemViewModel(book));
            currentlyReadingCollection.Key = "Books you are reading";
            GroupedItems.Add(currentlyReadingCollection);

            // Create collection for reading challenge
            var readingChallengeCollection = new ObservablePagedCollection<IBookItemViewModel, BookModel>(
                this.bookService.GetBooksByYear(userId, 2016),
                (book) => new BookItemViewModel(book));
            readingChallengeCollection.Key = "Books you read in 2016";
            GroupedItems.Add(readingChallengeCollection);

            // Create collection for owned books
            var ownedBooksCollection = new ObservablePagedCollection<IBookItemViewModel, BookModel>(
                this.bookService.GetOwnedBooks(userId),
                (book) => new BookItemViewModel(book));
            ownedBooksCollection.Key = "Books you own";
            GroupedItems.Add(ownedBooksCollection);

            return Task.FromResult<bool>(true);
        }
    }
}
