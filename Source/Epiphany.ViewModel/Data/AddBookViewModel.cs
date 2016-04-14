using Epiphany.Model;
using Epiphany.Model.Collections;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    /// <summary>
    /// ViewModel for adding a book to shelf
    /// </summary>
    public class AddBookViewModel : DataViewModel<BookModel>
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

        /// <summary>
        /// Create an instance of AddBookViewModel
        /// </summary>
        /// <param name="logonService">logon service</param>
        /// <param name="bookService">book service</param>
        /// <param name="bookshelfService">bookshelf service</param>
        /// <param name="navigationService">navigation service</param>
        public AddBookViewModel(ILogonService logonService, 
            IBookService bookService, 
            IBookshelfService bookshelfService, 
            INavigationService navigationService)
        {
            if (logonService == null || 
                bookService == null || 
                bookshelfService == null || 
                navigationService == null)
            {
                throw new ArgumentNullException("service");
            }

            this.logonService = logonService;
            this.bookshelfService = bookshelfService;
            this.navigationService = navigationService;
            
            this.fetchBookCommand = new FetchBookCommand(bookService);
            RegisterCommand(this.fetchBookCommand, OnFetchBookExecuted);

            this.fetchBookshelvesCommand = new EnumeratorCommand<BookshelfModel>(10);
            RegisterCommand(this.fetchBookshelvesCommand, OnFetchBookshelvesExecuted);

            this.addToShelvesCommand = new AddToShelvesCommand(bookService);
            RegisterCommand(this.addToShelvesCommand, OnCloseNeeded);

            this.createShelfCommand = new AddShelfCommand(bookshelfService);
            RegisterCommand(this.createShelfCommand, OnCreateShelfExecuted);
        }
        /// <summary>
        /// Gets the id of the book
        /// </summary>
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
        /// <summary>
        /// Gets the title of the book
        /// </summary>
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
        /// <summary>
        /// Gets the name of the shelf
        /// </summary>
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
        /// <summary>
        /// Gets whether the read shelf is selected
        /// </summary>
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
        /// <summary>
        /// Gets whether the currently reading shelf is selected
        /// </summary>
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
        /// <summary>
        /// Gets whether the to-read shelf is selected
        /// </summary>
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
        /// <summary>
        /// Gets the collection of custom shelves
        /// </summary>
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
        /// <summary>
        /// Gets the model
        /// </summary>
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
        /// <summary>
        /// Gets the args for AddToShelves command
        /// </summary>
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
        /// <summary>
        /// Gets the add to shelves command
        /// </summary>
        public ICommand<AddToShelvesCommandArgs> AddToShelves
        {
            get { return this.addToShelvesCommand; }
        }
        /// <summary>
        /// Gets the create shelf command
        /// </summary>
        public ICommand<string> CreateShelf
        {
            get { return this.createShelfCommand; }
        }
        /// <summary>
        /// Load the VM
        /// </summary>
        /// <param name="book">model</param>
        /// <returns></returns>
        public override async Task LoadAsync(BookModel book)
        {
            if (this.fetchBookCommand.CanExecute(book.Id))
            {
                await this.fetchBookCommand.ExecuteAsync(book.Id);
            }
        }

        private void OnCommandExecuting(object sender, ViewModel.Commands.CancelEventArgs e)
        {
            IsLoading = true;
        }

        private void OnFetchBookExecuted(ExecutedEventArgs e)
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

        private void OnFetchBookshelvesExecuted(ExecutedEventArgs e)
        {
            IsLoading = false;
            if (e.State == CommandExecutionState.Success)
            {
                IEnumerable<BookshelfModel> shelves = this.fetchBookshelvesCommand.Result;
                ProcessShelves(shelves);
                IsLoaded = true;
            }
        }

        private void OnCloseNeeded(ExecutedEventArgs e)
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

        private void OnCreateShelfExecuted(ExecutedEventArgs e)
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
            DeregisterCommand(this.addToShelvesCommand);
            DeregisterCommand(this.createShelfCommand);
            DeregisterCommand(fetchBookCommand);
            DeregisterCommand(fetchBookshelvesCommand);

            foreach (CustomBookshelfItemViewModel vm in CustomShelves)
            {
                vm.PropertyChanged -= OnBookshelfItemPropertyChanged;
            }
        }
    }
}
