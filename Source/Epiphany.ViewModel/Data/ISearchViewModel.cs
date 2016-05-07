using System.Collections.Generic;
using System.Threading.Tasks;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Items;

namespace Epiphany.ViewModel
{
    public interface ISearchViewModel : IDataViewModel
    {
        bool HasResults { get; }
        bool IsLoggedIn { get; }
        IList<BookSearchType> SearchFilters { get; }
        IList<ISearchResultItemViewModel> SearchResults { get; }
        string SearchTerm { get; set; }
        BookSearchType SelectedFilter { get; set; }
    }
}