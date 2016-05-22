using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public sealed class BookshelvesViewModel : DataViewModel<UserModel>, IBookshelvesViewModel
    {
        private readonly IBookshelfService bookshelfService;
        private readonly ILogonService logonService;

        private ILazyObservableCollection<IBookshelfItemViewModel> shelves;
        private string name;
        private string title;
        private bool canEdit;
        private string newShelfName;
        private readonly ICommand<string> createShelfCommand;
        private readonly ICommand cancelCreateShelfCommand;

        public BookshelvesViewModel(IBookshelfService bookshelfService, ILogonService logonService)
        {
            if (bookshelfService == null)
            {
                throw new ArgumentNullException(nameof(bookshelfService));
            }

            if (logonService == null)
            {
                throw new ArgumentNullException(nameof(logonService));
            }

            this.bookshelfService = bookshelfService;
            this.logonService = logonService;

            this.createShelfCommand = new AddShelfCommand(this.bookshelfService);
            RegisterCommand(this.createShelfCommand, OnShelfAdded);

            this.cancelCreateShelfCommand = new DelegateCommand(() => NewShelfName = string.Empty);
        }

        public IList<IBookshelfItemViewModel> Shelves
        {
            get
            {
                return this.shelves;
            }
            private set
            {
                SetProperty(ref this.shelves, value as ILazyObservableCollection<IBookshelfItemViewModel>);
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

        public bool CanEdit
        {
            get
            {
                return this.canEdit;
            }
            private set
            {
                SetProperty(ref this.canEdit, value);
            }
        }

        public string NewShelfName
        {
            get
            {
                return this.newShelfName;
            }

            set
            {
                SetProperty(ref this.newShelfName, value);
            }
        }

        public ICommand<string> CreateShelf
        {
            get
            {
                return this.createShelfCommand;
            }
        }

        public ICommand CancelCreateShelf
        {
            get
            {
                return this.cancelCreateShelfCommand;
            }
        }

        public override Task LoadAsync(UserModel user)
        {
            Name = user.Name;
            Title = $"{Name}'s Bookshelves";

            if (this.logonService.Session != null &&
                int.Parse(this.logonService.Session.UserId) == user.Id)
            {
                // if this the local user's bookshelves, allow editing
                CanEdit = true;
            }

            CreateCollection();

            return Task.FromResult<bool>(true);
        }

        private void CreateCollection()
        {
            var shelfCollection = this.bookshelfService.GetBookshelves(Parameter.Id);
            Shelves = new ObservablePagedCollection<IBookshelfItemViewModel, BookshelfModel>(shelfCollection, BookshelfModelAdapterFn);
            this.shelves.Loading += (obj, args) => IsLoading = true;
            this.shelves.Loaded += (obj, args) =>
            {
                IsLoading = false;
                IsLoaded = true;
            };
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

        private void OnShelfAdded(ExecutedEventArgs args)
        {
            NewShelfName = string.Empty;
            if (args.State == CommandExecutionState.Success)
            {
                CreateCollection();
            }
        }

        protected override void Reset()
        {
            base.Reset();

            Name = string.Empty;
            Title = string.Empty;
            Shelves = null;
            CanEdit = false;
            NewShelfName = string.Empty;
        }

        public override void Dispose()
        {
            base.Dispose();

            DeregisterCommand(this.createShelfCommand);
        }
    }
}
