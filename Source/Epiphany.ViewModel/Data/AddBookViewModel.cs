using Epiphany.Model;
using Epiphany.Model.Collections;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public class AddBookViewModel : DataViewModel, IAddBookViewModel
    {
        private ICommand<IEnumerable<BookshelfModel>, IAsyncEnumerator<BookshelfModel>> fetchBookshelvesCommand;
        private ObservableCollection<CustomBookshelfItemViewModel> customShelves;
        private ICommand<AddToShelvesCommandArgs> addToShelvesCommand;
        private AddToShelvesCommandArgs addToShelvesCommandArgs;        
        private IAsyncCommand<BookModel, int> fetchBookCommand;
        private ICommand<string> createShelfCommand;

        private readonly ILogonService logonService;
        private readonly IBookshelfService bookshelfService;
        private readonly INavigationService navigationService;

        private int id;
        private BookModel book;
        private string title;
        private string shelfName;
        private bool isToReadSelected;
        private bool isReadSelected = true;
        private bool isCurrentlyReadingSelected;

        private readonly string currentlyReadingShelf = "currently-reading";
        private readonly string toReadShelf = "to-read";
        private readonly string readShelf = "read";

        public AddBookViewModel(ILogonService logonService, 
            IBookService bookService, 
            IBookshelfService bookshelfService, 
            INavigationService navigationService)
        {
            this.logonService = logonService;
            this.bookshelfService = bookshelfService;
            this.navigationService = navigationService;
            
            this.fetchBookCommand = new FetchBookCommand(bookService);
            this.fetchBookCommand.Executing += OnCommandExecuting;
            this.fetchBookCommand.Executed += OnFetchBookExecuted;

            this.fetchBookshelvesCommand = new FetchBookshelvesCommand(bookshelfService);
            this.fetchBookshelvesCommand.Executing += OnCommandExecuting;
            this.fetchBookshelvesCommand.Executed += OnFetchBookshelvesExecuted;

            this.addToShelvesCommand = new AddToShelvesCommand(bookService);
            this.addToShelvesCommand.Executing += OnCommandExecuting;
            this.addToShelvesCommand.Executed += OnCloseNeeded;

            this.createShelfCommand = new AddShelfCommand(bookshelfService);
            this.createShelfCommand.Executing += OnCommandExecuting;
            this.createShelfCommand.Executed += OnCreateShelfExecuted;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                if (this.id == value) return;
                this.id = value;
                RaisePropertyChanged();
            }
        }
        
        public string Title
        {
            get { return this.title; }
            private set
            {
                if (this.title == value) return;
                this.title = value;
                RaisePropertyChanged();
            }
        }

        public string ShelfName
        {
            get { return this.shelfName; }
            set
            {
                if (this.shelfName == value) return;
                this.shelfName = value;
                RaisePropertyChanged();
            }
        }

        public bool IsReadSelected
        {
            get { return this.isReadSelected; }
            set
            {
                if (this.isReadSelected == value) return;
                this.isReadSelected = value;
                if (isReadSelected)
                    AddToShelvesArgs.ChangesList.Add(readShelf);
                else
                    AddToShelvesArgs.ChangesList.Remove(readShelf);
                RaisePropertyChanged();
            }
        }
        public bool IsCurrentlyReadingSelected
        {
            get { return this.isCurrentlyReadingSelected; }
            set
            {
                if (this.isCurrentlyReadingSelected == value) return;
                this.isCurrentlyReadingSelected = value;
                if (isCurrentlyReadingSelected)
                    AddToShelvesArgs.ChangesList.Add(currentlyReadingShelf);
                else
                    AddToShelvesArgs.ChangesList.Remove(currentlyReadingShelf);
                RaisePropertyChanged();
            }
        }
        public bool IsToReadSelected
        {
            get { return this.isToReadSelected; }
            set
            {
                if (this.isToReadSelected == value) return;
                this.isToReadSelected = value;
                if (isToReadSelected)
                    AddToShelvesArgs.ChangesList.Add(toReadShelf);
                else
                    AddToShelvesArgs.ChangesList.Remove(toReadShelf);
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<CustomBookshelfItemViewModel> CustomShelves
        {
            get { return this.customShelves; }
            private set
            {
                if (this.customShelves == value) return;
                this.customShelves = value;
                RaisePropertyChanged();
            }
        }

        public BookModel Book
        {
            get { return this.book; }
            private set
            {
                if (this.book == value) return;
                this.book = value;
                RaisePropertyChanged();
            }
        }

        public AddToShelvesCommandArgs AddToShelvesArgs
        {
            get { return this.addToShelvesCommandArgs; }
            private set
            {
                if (this.addToShelvesCommandArgs == value) return;
                this.addToShelvesCommandArgs = value;
                RaisePropertyChanged();
            }
        }

        public ICommand<AddToShelvesCommandArgs> AddToShelves
        {
            get { return this.addToShelvesCommand; }
        }

        public ICommand<string> CreateShelf
        {
            get { return this.createShelfCommand; }
        }

        public void Load()
        {
        }

        private void OnCommandExecuting(object sender, ViewModel.Commands.CancelEventArgs e)
        {
            IsLoading = true;
        }

        private void OnFetchBookExecuted(object sender, ExecutedEventArgs e)
        {
            IsLoading = false;
            if (e.State == CommandExecutionState.Success)
            {
                Book = this.fetchBookCommand.Result;
                IEnumerable<string> shelves = new List<string>();
                if (Book.UserReview != null && Book.UserReview .Shelves != null)
                {
                    shelves = Book.UserReview.Shelves;
                }
                
                AddToShelvesArgs = new AddToShelvesCommandArgs(Book, new DeltaList<string>(shelves));

                int userId = int.Parse(this.logonService.Session.UserId);
                IAsyncEnumerator<BookshelfModel> enumerator = this.bookshelfService.GetBookshelves(userId).GetEnumerator();

                if (this.fetchBookshelvesCommand.CanExecute(enumerator))
                {
                    this.fetchBookshelvesCommand.Execute(enumerator);
                }
            }
        }

        private void OnFetchBookshelvesExecuted(object sender, ExecutedEventArgs e)
        {
            IsLoading = false;
            if (e.State == CommandExecutionState.Success)
            {
                IEnumerable<BookshelfModel> shelves = this.fetchBookshelvesCommand.Result;
                ProcessShelves(shelves);
                IsLoaded = true;
            }
        }

        private void OnCloseNeeded(object sender, ExecutedEventArgs e)
        {
            IsLoading = false;
            if (e.State == CommandExecutionState.Success)
            {
                // Close the current view
                if (this.navigationService.CanGoBack)
                {
                    this.navigationService.GoBack();
                }
            }
        }

        private void OnCreateShelfExecuted(object sender, ExecutedEventArgs e)
        {
            IsLoading = false;
            if (e.State == CommandExecutionState.Success)
            {
                ShelfName = string.Empty;
                int userId = Converter.ToInt(this.logonService.Session.UserId, -1);
                IAsyncEnumerator<BookshelfModel> iterator = this.bookshelfService.GetBookshelves(userId).GetEnumerator();
                if (this.fetchBookshelvesCommand.CanExecute(iterator))
                {
                    this.fetchBookshelvesCommand.Execute(iterator);
                }
            }
        }

        private void ProcessShelves(IEnumerable<BookshelfModel> shelves)
        {
            // Check standard shelves
            IDictionary<string, int> shelvesForBook = AddToShelvesArgs.ChangesList.OriginalItems;

            if (shelvesForBook.ContainsKey(readShelf))
                IsReadSelected = true;
            else if (shelvesForBook.ContainsKey(currentlyReadingShelf))
                IsCurrentlyReadingSelected = true;
            else if (shelvesForBook.ContainsKey(toReadShelf))
                IsToReadSelected = true;
            else
                IsReadSelected = true;

            // Process custom shelves
            CustomShelves = new ObservableCollection<CustomBookshelfItemViewModel>();
            foreach (BookshelfModel shelf in shelves)
            {                
                if (!IsStandardShelf(shelf.Name))
                {
                    CustomBookshelfItemViewModel category = null;
                    if (shelvesForBook.ContainsKey(shelf.Name))
                        category = new CustomBookshelfItemViewModel(shelf, true);
                    else
                        category = new CustomBookshelfItemViewModel(shelf, false);

                    category.PropertyChanged += OnBookshelfItemPropertyChanged;
                    CustomShelves.Add(category);
                }
            }
        }

        private void OnBookshelfItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsEnabled")
            {
                CustomBookshelfItemViewModel shelfItemVM = sender as CustomBookshelfItemViewModel;
                if (shelfItemVM.IsEnabled)
                    AddToShelvesArgs.ChangesList.Add(shelfItemVM.Bookshelf.Name);
                else
                    AddToShelvesArgs.ChangesList.Remove(shelfItemVM.Bookshelf.Name);
            }
        }

        private bool IsStandardShelf(string shelf)
        {
            return shelf == readShelf || shelf == currentlyReadingShelf || shelf == toReadShelf;
        }

        public override void Dispose()
        {
            base.Dispose();
            this.addToShelvesCommand.Executing -= OnCommandExecuting;
            this.addToShelvesCommand.Executed -= OnCloseNeeded;

            this.createShelfCommand.Executing -= OnCommandExecuting;
            this.createShelfCommand.Executed -= OnCreateShelfExecuted;

            this.fetchBookCommand.Executing -= OnCommandExecuting;
            this.fetchBookCommand.Executed -= OnFetchBookExecuted;

            this.fetchBookshelvesCommand.Executing -= OnCommandExecuting;
            this.fetchBookshelvesCommand.Executed -= OnFetchBookshelvesExecuted;

            foreach (CustomBookshelfItemViewModel vm in CustomShelves)
            {
                vm.PropertyChanged -= OnBookshelfItemPropertyChanged;
            }
        }

        public override async Task LoadAsync()
        {
            if (this.fetchBookCommand.CanExecute(this.Id))
            {
                await this.fetchBookCommand.ExecuteAsync(this.Id);
            }
        }
    }
}
