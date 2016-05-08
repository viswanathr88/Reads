using Epiphany.ViewModel.Items;
using System.Collections.Generic;

namespace Epiphany.ViewModel
{
    public interface IBookshelvesViewModel : IDataViewModel
    {
        IList<IBookItemViewModel> CurrentlyReadingList { get; }
        IList<IBookshelfItemViewModel> Shelves { get; }

        bool IsCurrentlyReadingListLoading { get; }
        bool IsBookshelvesLoading { get; }
    }
}