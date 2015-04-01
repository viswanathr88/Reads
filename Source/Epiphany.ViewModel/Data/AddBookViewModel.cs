using Epiphany.Collections;
using Epiphany.Commands;
using Epiphany.Model;
using Epiphany.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Epiphany.ViewModels
{
    public class AddBookViewModel : DataViewModel<BookModel>
    {
        private IAsyncCommand<List<Bookshelf>, IAsyncIterable<Bookshelf>> fetchBookshelvesCommand;
        private ObservableCollection<CustomBookshelfItemViewModel> customShelves;
        private IAsyncCommand<AddToShelvesCommandArgs> addToShelvesCommand;
        private AddToShelvesCommandArgs addToShelvesCommandArgs;        
        private IAsyncCommand<Book, int> fetchBookCommand;
        private IAsyncCommand<Book> deleteReviewCommand;
        private IAsyncCommand<string> createShelfCommand;

        private Book book;
        private string title;
        private Client client;
        private string shelfName;
        private bool isToReadSelected;
        private IViewServices viewServices;
        private bool isReadSelected = true;
        private bool isCurrentlyReadingSelected;

        private readonly string currentlyReadingShelf = "currently-reading";
        private readonly string toReadShelf = "to-read";
        private readonly string readShelf = "read";

        public AddBookViewModel(Client client, IViewServices viewServices)
        {
            this.client = client;
            this.viewServices = viewServices;
            
            this.fetchBookCommand = new FetchBookCommand(client.Books);
            this.fetchBookCommand.Executing += OnCommandExecuting;
            this.fetchBookCommand.Executed += OnFetchBookExecuted;

            this.fetchBookshelvesCommand = new FetchBookshelvesCommand(client.Books);
            this.fetchBookshelvesCommand.Executing += OnCommandExecuting;
            this.fetchBookshelvesCommand.Executed += OnFetchBookshelvesExecuted;

            this.addToShelvesCommand = new AddToShelvesCommand(client.Books, client.Self.Id);
            this.addToShelvesCommand.Executing += OnCommandExecuting;
            this.addToShelvesCommand.Executed += OnCloseNeeded;

            this.deleteReviewCommand = new DeleteBookReviewCommand(client.Books, client.Self.Id);
            this.deleteReviewCommand.Executing += OnCommandExecuting;
            this.deleteReviewCommand.Executed += OnCloseNeeded;

            this.createShelfCommand = new AddShelfCommand(client.Books, client.Self.Id);
            this.createShelfCommand.Executing += OnCommandExecuting;
            this.createShelfCommand.Executed += OnCreateShelfExecuted;
        }
        
        public string Title
        {
            get { return this.title; }
            private set
            {
                if (this.title == value) return;
                this.title = value;
                RaisePropertyChanged(() => Title);
            }
        }

        public string ShelfName
        {
            get { return this.shelfName; }
            set
            {
                if (this.shelfName == value) return;
                this.shelfName = value;
                RaisePropertyChanged(() => ShelfName);
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
                RaisePropertyChanged(() => IsReadSelected);
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
                RaisePropertyChanged(() => IsCurrentlyReadingSelected);
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
                RaisePropertyChanged(() => IsToReadSelected);
            }
        }

        public ObservableCollection<CustomBookshelfItemViewModel> CustomShelves
        {
            get { return this.customShelves; }
            private set
            {
                if (this.customShelves == value) return;
                this.customShelves = value;
                RaisePropertyChanged(() => CustomShelves);
            }
        }

        public Book Book
        {
            get { return this.book; }
            private set
            {
                if (this.book == value) return;
                this.book = value;
                RaisePropertyChanged(() => Book);
            }
        }

        public AddToShelvesCommandArgs AddToShelvesArgs
        {
            get { return this.addToShelvesCommandArgs; }
            private set
            {
                if (this.addToShelvesCommandArgs == value) return;
                this.addToShelvesCommandArgs = value;
                RaisePropertyChanged(() => AddToShelvesArgs);
            }
        }

        public IAsyncCommand<AddToShelvesCommandArgs> AddToShelves
        {
            get { return this.addToShelvesCommand; }
        }

        public IAsyncCommand<Book> RemoveBook
        {
            get { return this.deleteReviewCommand; }
        }

        public IAsyncCommand<string> CreateShelf
        {
            get { return this.createShelfCommand; }
        }

        public void Load(int bookId, string bookTitle)
        {
            Title = bookTitle;
            if (this.fetchBookCommand.CanExecute(bookId))
                this.fetchBookCommand.Execute(bookId);
        }

        private void OnCommandExecuting(object sender, Epiphany.Commands.CancelEventArgs e)
        {
            IsLoading = true;
        }

        private void OnFetchBookExecuted(object sender, ExecutedEventArgs e)
        {
            IsLoading = false;
            if (e.State == CommandExecutionState.Success)
            {
                Book = this.fetchBookCommand.Result;
                List<string> shelves = new List<string>();
                if (Book.MyReview != null && Book.MyReview.Shelves != null)
                {
                    shelves = Book.MyReview.Shelves;
                }
                
                AddToShelvesArgs = new AddToShelvesCommandArgs(Book.Id, new DeltaList<string>(shelves));
                IAsyncIterable<Bookshelf> shelvesIterable = client.Books.GetBookshelves(client.Self.Id);
                if (this.fetchBookshelvesCommand.CanExecute(shelvesIterable))
                    this.fetchBookshelvesCommand.Execute(shelvesIterable);
            }
        }

        private void OnFetchBookshelvesExecuted(object sender, ExecutedEventArgs e)
        {
            IsLoading = false;
            if (e.State == CommandExecutionState.Success)
            {
                List<Bookshelf> shelves = this.fetchBookshelvesCommand.Result;
                ProcessShelves(shelves);
                IsLoaded = true;
            }
        }

        private void OnCloseNeeded(object sender, ExecutedEventArgs e)
        {
            IsLoading = false;
            if (e.State == CommandExecutionState.Success)
            {
                this.viewServices.CloseCurrentView();
            }
        }

        private void OnCreateShelfExecuted(object sender, ExecutedEventArgs e)
        {
            IsLoading = false;
            if (e.State == CommandExecutionState.Success)
            {
                ShelfName = string.Empty;
                IAsyncIterable<Bookshelf> shelves = this.client.Books.GetBookshelves(client.Self.Id);
                if (this.fetchBookshelvesCommand.CanExecute(shelves))
                    this.fetchBookshelvesCommand.Execute(shelves);
            }
        }

        private void ProcessShelves(List<Bookshelf> shelves)
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
            foreach (Bookshelf shelf in shelves)
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

            this.deleteReviewCommand.Executing -= OnCommandExecuting;
            this.deleteReviewCommand.Executed -= OnCloseNeeded;

            this.fetchBookCommand.Executing -= OnCommandExecuting;
            this.fetchBookCommand.Executed -= OnFetchBookExecuted;

            this.fetchBookshelvesCommand.Executing -= OnCommandExecuting;
            this.fetchBookshelvesCommand.Executed -= OnFetchBookshelvesExecuted;

            foreach (CustomBookshelfItemViewModel vm in CustomShelves)
                vm.PropertyChanged -= OnBookshelfItemPropertyChanged;
        }

        public override void Load(BookModel param)
        {
            throw new System.NotImplementedException();
        }
    }
}
