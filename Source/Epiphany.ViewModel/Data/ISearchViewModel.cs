using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using System.Collections.Generic;

namespace Epiphany.ViewModel
{
    /// <summary>
    /// ViewModel interface for Search
    /// </summary>
    public interface ISearchViewModel : IDataViewModel
    {
        /// <summary>
        /// Gets whether the search yielded any results
        /// </summary>
        bool HasResults
        {
            get;
        }
        /// <summary>
        /// Gets whether the app is logged in
        /// </summary>
        bool IsLoggedIn
        {
            get;
        }
        /// <summary>
        /// Gets the list of search filters
        /// </summary>
        IList<BookSearchType> SearchFilters
        {
            get;
        }
        /// <summary>
        /// Gets the list of search results
        /// </summary>
        ILazyObservableCollection<ISearchResultItemViewModel> SearchResults
        {
            get;
        }
        /// <summary>
        /// Gets or sets the search term
        /// </summary>
        string SearchTerm
        {
            get; set;
        }
        /// <summary>
        /// Gets the current selected filter
        /// </summary>
        BookSearchType SelectedFilter
        {
            get; set;
        }
    }
}