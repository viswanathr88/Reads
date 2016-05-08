using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public sealed class BookshelvesViewModel : DataViewModel<int>, IBookshelvesViewModel
    {
        private readonly IBookshelfService bookshelfService;
        private readonly ILogonService logonService;
        private readonly IBookService bookService;

        private IObservablePagedCollection<IBookItemViewModel> currentlyReadingList;
        private IObservablePagedCollection<IBookshelfItemViewModel> shelves;

        private bool isCurrentReadingListLoading;
        private bool isBookshelvesLoading;

        public BookshelvesViewModel(IBookshelfService bookshelfService, IBookService bookService, ILogonService logonService)
        {
            if (bookshelfService == null)
            {
                throw new ArgumentNullException(nameof(bookshelfService));
            }

            if (logonService == null)
            {
                throw new ArgumentNullException(nameof(logonService));
            }

            if (bookService == null)
            {
                throw new ArgumentNullException(nameof(bookService));
            }

            this.bookshelfService = bookshelfService;
            this.bookService = bookService;
            this.logonService = logonService;
        }

        public IList<IBookItemViewModel> CurrentlyReadingList
        {
            get
            {
                return this.currentlyReadingList;
            }
            private set
            {

                SetProperty(ref this.currentlyReadingList, value as IObservablePagedCollection<IBookItemViewModel>);
            }
        }

        public IList<IBookshelfItemViewModel> Shelves
        {
            get
            {
                return this.shelves;
            }
            private set
            {
                SetProperty(ref this.shelves, value as IObservablePagedCollection<IBookshelfItemViewModel>);
            }
        }

        public bool IsCurrentlyReadingListLoading
        {
            get
            {
                return this.isCurrentReadingListLoading;
            }
            private set
            {
                SetProperty(ref this.isCurrentReadingListLoading, value);
            }
        }

        public bool IsBookshelvesLoading
        {
            get
            {
                return this.isBookshelvesLoading;
            }

            private set
            {
                SetProperty(ref this.isBookshelvesLoading, value);
            }
        }

        public async override Task LoadAsync(int userId)
        {
            var shelfCollection = this.bookshelfService.GetBookshelves(userId);
            Shelves = new ObservablePagedCollection<IBookshelfItemViewModel, BookshelfModel>(shelfCollection, BookshelfModelAdapterFn);
            this.shelves.Loading += (obj, args) => IsBookshelvesLoading = true;
            this.shelves.Loaded += (obj, args) => IsBookshelvesLoading = false;

            var bookCollection = this.bookService.GetBooks(userId, "currently-reading", BookSortType.date_added, BookSortOrder.d);
            CurrentlyReadingList = new ObservablePagedCollection<IBookItemViewModel, BookModel>(bookCollection, BookModelAdapterFn);
            this.currentlyReadingList.Loading += (obj, args) => IsCurrentlyReadingListLoading = true;
            this.currentlyReadingList.Loaded += (obj, args) => IsCurrentlyReadingListLoading = false;

            await Task.Delay(1);
        }

        private IBookItemViewModel BookModelAdapterFn(BookModel model)
        {
            return new BookItemViewModel(model);
        }

        private IBookshelfItemViewModel BookshelfModelAdapterFn(BookshelfModel model)
        {
            IBookshelfItemViewModel item = null;
            if (model != null && model.Name != "currently-reading")
            {
                item = new BookshelfItemViewModel(model);
            }

            return item;
        }
    }
}
