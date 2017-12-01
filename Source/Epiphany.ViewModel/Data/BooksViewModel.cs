
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
        private IUserItemViewModel user;
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

        public ILazyObservableCollection<IBookItemViewModel> Books
        {
            get
            {
                return this.books;
            }
            private set
            {
                SetProperty(ref this.books, value);
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
                return this.user;
            }
            private set
            {
                SetProperty(ref this.user, value);
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
            if (Books != null)
            {
                Books.PropertyChanged -= Books_PropertyChanged;
            }

            if (Parameter != null)
            {
                Books = new LazyObservablePagedCollection<IBookItemViewModel, BookModel>
                    (this.bookService.GetBooks(Parameter.User.Id, ShelfName, SelectedFilter, SelectedOrderByFilter), 
                    (model) => new BookItemViewModel(model));
                Books.PropertyChanged += Books_PropertyChanged;
            }
        }

        private void Books_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Books.IsLoading))
            {
                IsLoading = Books.IsLoading;
                if (!Books.IsLoading)
                {
                    IsLoaded = (Books.Count != 0 || Error != null);
                }

            }
            else if (e.PropertyName == nameof(Books.Error))
            {
                Error = Books.Error;
                IsLoaded = false;
            }
        }

        public override Task LoadAsync(IBookshelfItemViewModel parameter)
        {
            IsLoading = true;
            ShelfName = parameter.Name;
            User = parameter.User;

            CreateBookCollection();

            return Task.FromResult<bool>(true);
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

        public override void Dispose()
        {
            base.Dispose();

            if (Books != null)
            {
                Books.PropertyChanged -= Books_PropertyChanged;
            }
        }
    }
}
