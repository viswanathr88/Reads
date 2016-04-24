using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Items;
using Epiphany.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public class SearchViewModel : DataViewModel<VoidType>
    {
        private IList<BookSearchType> searchFilters;
        private IList<SearchResultItemViewModel> searchResults;
        private BookSearchType selectedFilter;
        private SearchQuery previousQuery;
        private bool hasResults = true;
        private SearchResultItemViewModel selectedResult;
        private SearchQuery query;
        private string searchTerm;
        private const int itemsCount = 20;

        private readonly IAsyncCommand<IEnumerable<WorkModel>, SearchQuery> searchCommand;
        private readonly ICommand<BookItemViewModel> showBookCommand;
        private readonly INavigationService navService;

        public SearchViewModel() { }

        public SearchViewModel(IBookService bookService, INavigationService navService)
        {
            this.navService = navService;

            SearchResults = new ObservableCollection<SearchResultItemViewModel>();
            SearchFilters = Enum.GetValues(typeof(BookSearchType)).Cast<BookSearchType>().ToList();

            this.searchCommand = new SearchCommand(bookService, itemsCount);
            RegisterCommand(this.searchCommand, OnCommandExecuted);

            this.showBookCommand = new ShowBookFromItemCommand(navService);

            this.selectedFilter = BookSearchType.All;
            Query = new SearchQuery(this.searchTerm, this.selectedFilter);
        }

        public string SearchTerm
        {
            get { return this.searchTerm; }
            set
            {
                if (this.searchTerm == value) return;
                this.searchTerm = value;
                Query = new SearchQuery(searchTerm, this.selectedFilter);
            }
        }

        public BookSearchType SelectedFilter
        {
            get { return this.selectedFilter; }
            set
            {
                if (this.selectedFilter == value) return;
                this.selectedFilter = value;
                Query = new SearchQuery(searchTerm, this.selectedFilter);
                if (searchCommand.CanExecute(Query))
                    searchCommand.Execute(Query);
                RaisePropertyChanged(() => SelectedFilter);
            }
        }

        public SearchQuery Query
        {
            get { return this.query; }
            private set
            {
                if (this.query != null && this.query.Equals(value)) return;
                this.query = value;
                RaisePropertyChanged();
            }
        }

        public IList<BookSearchType> SearchFilters
        {
            get { return this.searchFilters; }
            private set
            {
                if (this.searchFilters == value) return;
                this.searchFilters = value;
                RaisePropertyChanged();
            }
        }

        public IList<SearchResultItemViewModel> SearchResults
        {
            get { return this.searchResults; }
            private set
            {
                if (this.searchResults == value) return;
                this.searchResults = value;
                RaisePropertyChanged();
            }
        }

        public SearchResultItemViewModel SelectedResult
        {
            get { return this.selectedResult; }
            set
            {
                if (this.selectedResult == value) return;
                this.selectedResult = value;
                
                if (this.showBookCommand.CanExecute(value.Book))
                {
                    this.showBookCommand.Execute(value.Book);
                }

                this.selectedResult = null;
                RaisePropertyChanged();
            }
        }

        public bool HasResults
        {
            get { return this.hasResults; }
            private set
            {
                if (this.hasResults == value) return;
                this.hasResults = value;
                RaisePropertyChanged();
            }
        }

        public IAsyncCommand<IEnumerable<WorkModel>, SearchQuery> Search
        {
            get { return this.searchCommand; }
        }

        public override async Task LoadAsync(VoidType parameter)
        {
            if (this.searchCommand.CanExecute(Query))
            {
                await this.searchCommand.ExecuteAsync(Query);
            }
        }

        private void OnCommandExecuted(ExecutedEventArgs e)
        {
            IsLoading = false;
            previousQuery = query;
            if (SearchResults.Count != 0)
            {
                HasResults = true;
            }
            if (e.State == CommandExecutionState.Success)
            {
                IEnumerable<WorkModel> results = this.searchCommand.Result;
                foreach (WorkModel work in results)
                {
                    SearchResults.Add(new SearchResultItemViewModel(work.Book, navService));
                }
                if (SearchResults.Count == 0)
                {
                    HasResults = false;
                }
            }
        }

        protected override void OnCmdExecuting(object sender, CancelEventArgs e)
        {
            base.OnCmdExecuting(sender, e);

            HasResults = true;
            if (previousQuery != query)
            {
                SearchResults.Clear();
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            DeregisterCommand(this.searchCommand);
        }
    }
}
