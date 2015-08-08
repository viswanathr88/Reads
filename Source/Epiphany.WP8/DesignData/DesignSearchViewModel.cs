using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;

namespace Epiphany.View.DesignData
{
    public sealed class DesignSearchViewModel : DataViewModel, ISearchViewModel
    {
        public DesignSearchViewModel()
        {
            SearchTerm = "Archer";

            SearchFilters = new ObservableCollection<BookSearchType>();
            SearchFilters.Add(BookSearchType.All);
            SearchFilters.Add(BookSearchType.Title);
            SelectedFilter = SearchFilters[0];

            PopulateSearchResults();
        }

        private void PopulateSearchResults()
        {
            SearchResults = new ObservableCollection<ISearchResultItemViewModel>();

            for (int i = 0; i < 5; i++)
            {
                DesignSearchItemViewModel itemVM = new DesignSearchItemViewModel()
                {
                    Book = new DesignBookItemViewModel()
                    {
                        Id = 50,
                        Title = "Test Book " + i ,
                        AverageRating = 4.0,
                        ImageUrl = @"https://upload.wikimedia.org/wikipedia/en/3/33/A_Prisoner_of_Birth_Jeffrey_Archer.jpg"
                    },
                    Author = new DesignAuthorItemViewModel()
                    {
                        Id = 250,
                        Name = "Test Author " + i
                    }
                };
                SearchResults.Add(itemVM);
            }

            SelectedResult = SearchResults.FirstOrDefault();
            HasResults = SearchResults.Count > 0;
        }

        public string SearchTerm
        {
            get;
            set;
        }

        public BookSearchType SelectedFilter
        {
            get;
            set;
        }

        public SearchQuery Query
        {
            get;
            set;
        }

        public IList<BookSearchType> SearchFilters
        {
            get;
            set;
        }

        public IList<ISearchResultItemViewModel> SearchResults
        {
            get;
            set;
        }

        public ISearchResultItemViewModel SelectedResult
        {
            get;
            set;
        }

        public bool HasResults
        {
            get;
            set;
        }

        public IAsyncCommand<IEnumerable<WorkModel>, SearchQuery> Search
        {
            get;
            set;
        }

        public override Task LoadAsync()
        {
            return Task.FromResult(true);
        }
    }
}
