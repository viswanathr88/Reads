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
    public class SearchViewModel : DataViewModel<VoidType>
    {
        private IList<BookSearchType> searchFilters;
        private ObservablePagedCollection<SearchResultItemViewModel, WorkModel> searchResults;
        private BookSearchType selectedFilter;
        private bool hasResults = true;
        private string searchTerm;
        private const int itemsCount = 20;

        private readonly IBookService bookService;

        public SearchViewModel() { }

        public SearchViewModel(IBookService bookService)
        {
            this.bookService = bookService;

            SearchFilters = Enum.GetValues(typeof(BookSearchType)).Cast<BookSearchType>().ToList();

            this.selectedFilter = BookSearchType.All;
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
                SetProperty(ref this.selectedFilter, value);

                CreateSearchResultCollection();

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

        public IList<SearchResultItemViewModel> SearchResults
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

        public override async Task LoadAsync(VoidType parameter)
        {
            CreateSearchResultCollection();
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

            this.searchResults = new ObservablePagedCollection<SearchResultItemViewModel, WorkModel>(collection, ConvertToVM);
            this.searchResults.Loading += SearchResults_Loading;
            this.searchResults.Loaded += SearchResults_Loaded;
            RaisePropertyChanged(nameof(SearchResults));

            HasResults = true;
        }

        private void SearchResults_Loaded(object sender, EventArgs e)
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
            return new SearchResultItemViewModel(arg);
        }
    }
}
