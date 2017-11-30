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
    public class SearchViewModel : DataViewModel<string>, ISearchViewModel
    {
        private IList<BookSearchType> searchFilters;
        private ObservablePagedCollection<ISearchResultItemViewModel, WorkModel> searchResults;
        private BookSearchType selectedFilter;
        private bool hasResults = true;
        private bool isLoggedIn = false;
        private string searchTerm;

        private readonly IBookService bookService;
        private readonly ILogonService logonService;

        public SearchViewModel(IBookService bookService, ILogonService logonService)
        {
            this.bookService = bookService;
            this.logonService = logonService;
            this.logonService.SessionChanged += LogonService_SessionChanged;

            IsLoggedIn = (logonService.Session != null);
            SearchFilters = Enum.GetValues(typeof(BookSearchType)).Cast<BookSearchType>().ToList();
            this.selectedFilter = BookSearchType.All;
        }

        private void LogonService_SessionChanged(object sender, Model.Authentication.SessionChangedEventArgs e)
        {
            IsLoggedIn = (e.Session != null);
        }

        public bool IsLoggedIn
        {
            get
            {
                return this.isLoggedIn;
            }
            private set
            {
                SetProperty(ref this.isLoggedIn, value);
            }
        }

        public string SearchTerm
        {
            get { return this.searchTerm; }
            set
            {
                SetProperty(ref this.searchTerm, value);
            }
        }

        public BookSearchType SelectedFilter
        {
            get { return this.selectedFilter; }
            set
            {
                if (SetProperty(ref this.selectedFilter, value))
                {
                    CreateSearchResultCollection();
                }
            }
        }

        public IList<BookSearchType> SearchFilters
        {
            get { return this.searchFilters; }
            private set
            {
                SetProperty(ref this.searchFilters, value);
            }
        }

        public IList<ISearchResultItemViewModel> SearchResults
        {
            get { return this.searchResults; }
        }

        public bool HasResults
        {
            get { return this.hasResults; }
            private set
            {
                SetProperty(ref this.hasResults, value);
            }
        }

        public override async Task LoadAsync(string parameter)
        {
            SearchTerm = parameter;
            CreateSearchResultCollection();
            await Task.FromResult(0);
        }

        private void CreateSearchResultCollection()
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                var collection = this.bookService.Find(SelectedFilter, SearchTerm);
                CreateObservableCollection(collection);
            }
        }

        private void CreateObservableCollection(Model.Collections.IPagedCollection<WorkModel> collection)
        {
            if (this.searchResults != null)
            {
                this.searchResults.Loading -= SearchResults_Loading;
                this.searchResults.Loaded -= SearchResults_Loaded;
                this.searchResults = null;
                RaisePropertyChanged(nameof(SearchResults));
            }

            this.searchResults = new ObservablePagedCollection<ISearchResultItemViewModel, WorkModel>(collection, ConvertToVM);
            this.searchResults.Loading += SearchResults_Loading;
            this.searchResults.Loaded += SearchResults_Loaded;
            RaisePropertyChanged(nameof(SearchResults));

            HasResults = true;
        }

        private void SearchResults_Loaded(object sender, LoadedEventArgs e)
        {
            IsLoading = false;
            IsLoaded = true;
            if (SearchResults.Count == 0)
            {
                HasResults = false;
            }
        }

        private void SearchResults_Loading(object sender, EventArgs e)
        {
            IsLoading = true;
        }

        private SearchResultItemViewModel ConvertToVM(WorkModel arg)
        {
            return new SearchResultItemViewModel(this.bookService, arg);
        }

        protected override void Reset()
        {
            base.Reset();

            SearchTerm = string.Empty;
            this.searchResults = null;
            RaisePropertyChanged(nameof(SearchResults));
        }

        public override void Dispose()
        {
            base.Dispose();

            this.logonService.SessionChanged -= LogonService_SessionChanged;
        }
    }
}
