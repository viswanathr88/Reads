
using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public sealed class BooksViewModel : DataViewModel<IBookshelfItemViewModel>, IBooksViewModel
    {
        private string shelfName;
        private IObservablePagedCollection<IBookItemViewModel> books;
        private IList<BookSortType> filters;
        private BookSortType selectedFilter;

        private readonly IBookService bookService;

        public BooksViewModel(IBookService bookService)
        {
            if (bookService == null)
            {
                throw new ArgumentNullException(nameof(bookService));
            }

            this.bookService = bookService;
            Filters = Enum.GetValues(typeof(BookSortType)).Cast<BookSortType>().ToList();
            SelectedFilter = BookSortType.date_added;
        }

        public string ShelfName
        {
            get { return this.shelfName; }
            private set
            {
                SetProperty(ref this.shelfName, value);
            }
        }

        public IList<IBookItemViewModel> Books
        {
            get
            {
                return this.books;
            }
            private set
            {
                SetProperty(ref this.books, value as IObservablePagedCollection<IBookItemViewModel>);
            }
        }

        public IList<BookSortType> Filters
        {
            get
            {
                return this.filters;
            }
            private set
            {
                SetProperty(ref this.filters, value);
            }
        }

        public BookSortType SelectedFilter
        {
            get
            {
                return this.selectedFilter;
            }
            set
            {
                if (SetProperty(ref this.selectedFilter, value))
                {
                    CreateBookCollection();
                }
            }
        }

        public IUserItemViewModel User
        {
            get
            {
                return Parameter.User;
            }
        }

        private void CreateBookCollection()
        {
            if (Parameter != null)
            {
                var collection = this.bookService.GetBooks(Parameter.User.Id, ShelfName, SelectedFilter, BookSortOrder.d);
                Books = new ObservablePagedCollection<IBookItemViewModel, BookModel>(collection, AdapterFn);
                this.books.Loading += (sender, arg) => IsLoading = true;
                this.books.Loaded += (sender, arg) =>
                {
                    IsLoading = false;
                    IsLoaded = true;
                };
            }
        }

        public override Task LoadAsync(IBookshelfItemViewModel parameter)
        {
            IsLoading = true;
            ShelfName = parameter.Name;

            CreateBookCollection();

            return Task.FromResult<bool>(true);
        }

        private IBookItemViewModel AdapterFn(BookModel arg)
        {
            return new BookItemViewModel(arg);
        }

        protected override void Reset()
        {
            base.Reset();
            ShelfName = string.Empty;
        }
    }
}
