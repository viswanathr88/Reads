using Epiphany.Model.Services;
using Epiphany.ViewModel.Items;
using System.Collections.Generic;

namespace Epiphany.ViewModel
{
    public interface IBooksViewModel : IDataViewModel
    {
        string ShelfName
        {
            get;
        }

        IUserItemViewModel User
        {
            get;
        }

        IList<IBookItemViewModel> Books
        {
            get;
        }

        IList<BookSortType> Filters
        {
            get;
        }

        IList<BookSortOrder> OrderByFilters
        {
            get;
        }

        BookSortType SelectedFilter
        {
            get;
            set;
        }

        BookSortOrder SelectedOrderByFilter
        {
            get;
            set;
        }
    }
}