
using Epiphany.Model;
using Epiphany.Model.Services;
using System.Collections.Generic;
namespace Epiphany.ViewModel
{
    public interface ISearchViewModel : IDataViewModel
    {
        string SearchTerm { get; set; }

        BookSearchType SelectedFilter { get;set; }

        SearchQuery Query { get; }

        IList<BookSearchType> SearchFilters { get; }

        IList<SearchResultItemViewModel> SearchResults { get; }

        SearchResultItemViewModel SelectedResult { get; set; }

        bool HasResults { get; }

        IAsyncCommand<IEnumerable<WorkModel>, SearchQuery> Search { get; }
    }
}
