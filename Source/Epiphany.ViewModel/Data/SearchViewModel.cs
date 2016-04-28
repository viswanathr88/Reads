using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
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
        private bool hasResults = true;
        private SearchResultItemViewModel selectedResult;
        private string searchTerm;
        private const int itemsCount = 20;

        private readonly ICommand<BookItemViewModel> showBookCommand;
        private readonly INavigationService navService;
        private readonly IBookService bookService;

        public SearchViewModel(IBookService bookService, INavigationService navService)
        {
            this.navService = navService;
            this.bookService = bookService;

            SearchResults = new ObservableCollection<SearchResultItemViewModel>();
            SearchFilters = Enum.GetValues(typeof(BookSearchType)).Cast<BookSearchType>().ToList();

            this.showBookCommand = new ShowBookFromItemCommand(navService);
            this.selectedFilter = BookSearchType.All;
        }

        public string SearchTerm
        {
            get { return this.searchTerm; }
            set
            {
                if (this.searchTerm == value) return;
                this.searchTerm = value;
                RaisePropertyChanged();
            }
        }

        public BookSearchType SelectedFilter
        {
            get { return this.selectedFilter; }
            set
            {
                if (this.selectedFilter == value) return;
                this.selectedFilter = value;
                CreateSearchResultCollection();
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

        public override async Task LoadAsync(VoidType parameter)
        {
            CreateSearchResultCollection();
        }

        private void CreateSearchResultCollection()
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                var collection = this.bookService.Find(SelectedFilter, SearchTerm);
                SearchResults = new ObservablePagedCollection<SearchResultItemViewModel, WorkModel>
                    (collection, ConvertToVM);
            }
        }

        private SearchResultItemViewModel ConvertToVM(WorkModel arg)
        {
            return new SearchResultItemViewModel(arg.Book, this.navService);
        }
    }
}
