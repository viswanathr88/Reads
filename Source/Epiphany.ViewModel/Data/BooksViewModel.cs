
using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.Model.Settings;
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
        private ILazyObservableCollection<IBookItemViewModel> books;
        private IList<BookSortType> filters;
        private BookSortType selectedFilter;

        private IList<BookSortOrder> orderByFilters;
        private BookSortOrder selectedOrderByFilter = BookSortOrder.d;

        private readonly IBookService bookService;

        public BooksViewModel(IBookService bookService)
        {
            if (bookService == null)
            {
                throw new ArgumentNullException(nameof(bookService));
            }

            this.bookService = bookService;
            Filters = Enum.GetValues(typeof(BookSortType)).Cast<BookSortType>().ToList();
            CreateOrderByFilters();

            SelectedFilter = (BookSortType)Enum.Parse(typeof(BookSortType), ApplicationSettings.Instance.SortType);
            SelectedOrderByFilter = (BookSortOrder)Enum.Parse(typeof(BookSortOrder), ApplicationSettings.Instance.SortOrder);
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
                SetProperty(ref this.books, value as ILazyObservableCollection<IBookItemViewModel>);
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
                    ApplicationSettings.Instance.SortType = value.ToString();
                    RaisePropertyChanged(nameof(SelectedOrderByFilter));
                    CreateOrderByFilters();
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

        public IList<BookSortOrder> OrderByFilters
        {
            get
            {
                return this.orderByFilters;
            }
            private set
            {
                SetProperty(ref this.orderByFilters, value);
            }
        }

        public BookSortOrder SelectedOrderByFilter
        {
            get
            {
                return this.selectedOrderByFilter;
            }

            set
            {
                if (SetProperty(ref this.selectedOrderByFilter, value))
                {
                    ApplicationSettings.Instance.SortOrder = value.ToString();
                    CreateBookCollection();
                }
            }
        }

        private void CreateBookCollection()
        {
            if (Parameter != null)
            {
                var collection = this.bookService.GetBooks(Parameter.User.Id, ShelfName, SelectedFilter, SelectedOrderByFilter);
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

        private void CreateOrderByFilters()
        {
            OrderByFilters = null;
            OrderByFilters = Enum.GetValues(typeof(BookSortOrder)).Cast<BookSortOrder>().ToList();
        }

        protected override void Reset()
        {
            base.Reset();
            ShelfName = string.Empty;
            Books = null;
        }
    }
}
