using Epiphany.Model;
using Epiphany.Model.Collections;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Items;
using Epiphany.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public sealed class AuthorViewModel : DataViewModel<AuthorModel>, IAuthorViewModel
    {
        private readonly AuthorAttributeViewModelFactory authorAttributeVMFactory;
        private IBookItemViewModel selectedBook;
        private bool bookLoadingStarted;
        private AuthorModel author;
        private string imageUrl;
        private string name;
        private int id;

        // collections
        private IAsyncEnumerator<BookModel> bookEnumerator;
        private IList<IBookItemViewModel> books;
        private IList<IAuthorAttributeViewModel> attributes;

        // commands
        private readonly IAsyncCommand<IEnumerable<BookModel>, IAsyncEnumerator<BookModel>> fetchBooksCommand;
        private readonly IAsyncCommand<AuthorModel, int> fetchAuthorCommand;
        private readonly ICommand goHomeCommand;

        private readonly IBookService bookService;
        private readonly INavigationService navService;

        public AuthorViewModel(IAuthorService authorService, IBookService bookService, INavigationService navService)
        {
            if (authorService == null || bookService == null || navService == null)
            {
                throw new ArgumentNullException("services");
            }

            this.bookService = bookService;
            this.navService = navService;

            Books = new ObservableCollection<IBookItemViewModel>();
            this.authorAttributeVMFactory = new AuthorAttributeViewModelFactory();

            this.fetchAuthorCommand = new FetchAuthorCommand(authorService);
            RegisterCommand(this.fetchAuthorCommand, OnFetchAuthorExecuted);

            this.fetchBooksCommand = new EnumeratorCommand<BookModel>(20);
            RegisterCommand(this.fetchBooksCommand, OnFetchBooksExecuted);
            
            this.goHomeCommand = new GoHomeCommand(navService);
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (this.id == value) return;
                this.id = value;
                RaisePropertyChanged();
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name == value) return;
                this.name = value;
                RaisePropertyChanged();
            }
        }

        public bool BookLoadingStarted
        {
            get { return this.bookLoadingStarted; }
            private set
            {
                if (this.bookLoadingStarted == value) return;
                this.bookLoadingStarted = value;
                RaisePropertyChanged();
            }
        }

        public string ImageUrl
        {
            get { return this.imageUrl; }
            private set
            {
                if (this.imageUrl == value) return;
                this.imageUrl = value;
                RaisePropertyChanged();
            }
        }

        public AuthorModel Author
        {
            get { return this.author; }
            private set
            {
                if (this.author == value) return;
                this.author = value;
                RaisePropertyChanged();
            }
        }

        public IBookItemViewModel SelectedBook
        {
            get { return this.selectedBook; }
            set
            {
                if (this.selectedBook == value) return;
                this.selectedBook = value;

                this.navService.CreateFor<BookViewModel>()
                    .AddParam<int>((x) => (x.Id), value.Id)
                    .AddParam<string>((x) => x.Name, value.Title)
                    .Navigate();
                this.selectedBook = null;

                RaisePropertyChanged();
            }
        }

        public IList<IBookItemViewModel> Books
        {
            get { return this.books; }
            private set
            {
                if (this.books == value) return;
                this.books = value;
                RaisePropertyChanged();
            }
        }

        public IAsyncEnumerator<BookModel> BookEnumerator
        {
            get { return this.bookEnumerator; }
            private set
            {
                if (this.bookEnumerator == value) return;
                this.bookEnumerator = value;
                RaisePropertyChanged();
            }
        }

        public IList<IAuthorAttributeViewModel> Attributes
        {
            get { return this.attributes; }
            private set
            {
                if (this.attributes == value) return;
                this.attributes = value;
                RaisePropertyChanged();
            }
        }

        public IAsyncCommand<IAsyncEnumerator<BookModel>> FetchBooks
        {
            get { return this.fetchBooksCommand; }
        }

        public ICommand<AuthorModel> PinAuthor
        {
            get { return null; }
        }

        public ICommand GoHome
        {
            get { return this.goHomeCommand; }
        }

        public override async Task LoadAsync(AuthorModel author)
        {
            if (this.fetchAuthorCommand.CanExecute(author.Id))
            {
                await this.fetchAuthorCommand.ExecuteAsync(author.Id);
            }
        }

        private void OnFetchAuthorExecuted(ExecutedEventArgs e)
        {
            if (e.State == CommandExecutionState.Success)
            {
                Author = this.fetchAuthorCommand.Result;
                Attributes = this.authorAttributeVMFactory.GetAuthorAttributeItems(Author);
                ImageUrl = this.fetchAuthorCommand.Result.ImageUrl;
                BookEnumerator = this.bookService.GetBooks(Author).GetEnumerator();
                IsLoaded = true;
            }

            IsLoading = false;
        }

        private void OnFetchBooksExecuted(ExecutedEventArgs e)
        {
            if (e.State == CommandExecutionState.Success)
            {
                foreach (BookModel book in this.fetchBooksCommand.Result)
                {
                    Books.Add(new BookItemViewModel(book));
                }

                BookLoadingStarted = (Books.Count > 0);
            }

            IsLoading = false;
        }

        public override void Dispose()
        {
            base.Dispose();

            DeregisterCommand(this.fetchAuthorCommand);
            DeregisterCommand(this.fetchBooksCommand);
        }
    }
}
