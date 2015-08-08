
using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Items;
using System.Collections.Generic;
namespace Epiphany.ViewModel
{
    public interface ISearchViewModel : IDataViewModel
    {
        string SearchTerm { get; set; }

        BookSearchType SelectedFilter { get;set; }

        SearchQuery Query { get; }

        IList<BookSearchType> SearchFilters { get; }

        IList<ISearchResultItemViewModel> SearchResults { get; }

        ISearchResultItemViewModel SelectedResult { get; set; }

        bool HasResults { get; }

        IAsyncCommand<IEnumerable<WorkModel>, SearchQuery> Search { get; }
    }
}
