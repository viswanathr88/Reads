using Epiphany.Model;
using Epiphany.Model.Authentication;
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
        private ILazyObservableCollection<ISearchResultItemViewModel> searchResults;
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
            get
            {
                return this.searchTerm;
            }
            set
            {
                SetProperty(ref this.searchTerm, value);
            }
        }

        public BookSearchType SelectedFilter
        {
            get
            {
                return this.selectedFilter;
            }
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
            get
            {
                return this.searchFilters;
            }
            private set
            {
                SetProperty(ref this.searchFilters, value);
            }
        }

        public ILazyObservableCollection<ISearchResultItemViewModel> SearchResults
        {
            get
            {
                return this.searchResults;
            }
            private set
            {
                SetProperty(ref this.searchResults, value);
            }
        }

        public bool HasResults
        {
            get
            {
                return this.hasResults;
            }
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
            if (SearchResults != null)
            {
                SearchResults.PropertyChanged -= SearchResults_PropertyChanged;
            }

            // Create the collection
            SearchResults = new LazyObservablePagedCollection<ISearchResultItemViewModel, WorkModel>
                (collection, (model) => new SearchResultItemViewModel(this.bookService, model));
            SearchResults.PropertyChanged += SearchResults_PropertyChanged;

            HasResults = true;
        }

        private void SearchResults_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SearchResults.IsLoading))
            {
                IsLoading = SearchResults.IsLoading;
                if (!SearchResults.IsLoading)
                {
                    HasResults = (SearchResults.Count != 0);
                    IsLoaded = (HasResults || Error != null);
                }
                
            }
            else if (e.PropertyName == nameof(SearchResults.Error))
            {
                Error = SearchResults.Error;
                IsLoaded = false;
            }
        }

        private void LogonService_SessionChanged(object sender, SessionChangedEventArgs e)
        {
            IsLoggedIn = (e.Session != null);
        }

        protected override void Reset()
        {
            base.Reset();

            SearchTerm = string.Empty;
            SearchResults = null;
        }

        public override void Dispose()
        {
            base.Dispose();

            if (SearchResults != null)
            {
                SearchResults.PropertyChanged -= SearchResults_PropertyChanged;
            }

            this.logonService.SessionChanged -= LogonService_SessionChanged;
        }
    }
}
