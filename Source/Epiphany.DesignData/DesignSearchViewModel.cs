using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Epiphany.View.DesignData
{
    public sealed class DesignSearchViewModel : DesignBaseViewModel, ISearchViewModel
    {
        private Random random = new Random();

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
            SearchResults = new DesignLazyObservableCollection<ISearchResultItemViewModel>();

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
                    },
                    AverageRating = random.NextDouble() * 5,
                    RatingsCount = random.Next(50, 1000000),
                    Reviewed = (random.NextDouble()> 0.5)
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

        public ILazyObservableCollection<ISearchResultItemViewModel> SearchResults
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

        public bool IsLoggedIn
        {
            get
            {
                return false;
            }
        }
    }
}
