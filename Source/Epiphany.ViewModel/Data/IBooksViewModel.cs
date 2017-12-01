using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
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

        ILazyObservableCollection<IBookItemViewModel> Books
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