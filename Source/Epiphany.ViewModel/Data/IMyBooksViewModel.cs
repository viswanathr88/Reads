using System.Collections.Generic;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;

namespace Epiphany.ViewModel
{
    public interface IMyBooksViewModel
    {
        IList<IObservablePagedCollection<IBookItemViewModel>> GroupedItems { get; }
    }
}