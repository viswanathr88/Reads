using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public sealed class BookshelvesViewModel : DataViewModel<UserModel>, IBookshelvesViewModel
    {
        private readonly IBookshelfService bookshelfService;

        private IObservablePagedCollection<IBookshelfItemViewModel> shelves;
        private string name;
        private string title;

        public BookshelvesViewModel(IBookshelfService bookshelfService)
        {
            if (bookshelfService == null)
            {
                throw new ArgumentNullException(nameof(bookshelfService));
            }

            this.bookshelfService = bookshelfService;
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

        public string Title
        {
            get
            {
                return this.title;
            }
            private set
            {
                SetProperty(ref this.title, value);
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                SetProperty(ref this.name, value);
            }
        }

        public override Task LoadAsync(UserModel user)
        {
            Name = user.Name;
            Title = $"{Name}'s Bookshelves";

            var shelfCollection = this.bookshelfService.GetBookshelves(user.Id);
            Shelves = new ObservablePagedCollection<IBookshelfItemViewModel, BookshelfModel>(shelfCollection, BookshelfModelAdapterFn);
            this.shelves.Loading += (obj, args) => IsLoading = true;
            this.shelves.Loaded += (obj, args) => IsLoading = false;

            return Task.FromResult<bool>(true);
        }

        private IBookItemViewModel BookModelAdapterFn(BookModel model)
        {
            return new BookItemViewModel(model);
        }

        private IBookshelfItemViewModel BookshelfModelAdapterFn(BookshelfModel model)
        {
            IBookshelfItemViewModel item = null;
            if (model != null)
            {
                item = new BookshelfItemViewModel(Parameter, model);
            }

            return item;
        }

        protected override void Reset()
        {
            base.Reset();

            Name = string.Empty;
            Title = string.Empty;
            Shelves = null;
        }
    }
}
