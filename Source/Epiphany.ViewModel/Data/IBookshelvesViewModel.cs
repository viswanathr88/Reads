using Epiphany.ViewModel.Items;
using System.Collections.Generic;

namespace Epiphany.ViewModel
{
    public interface IBookshelvesViewModel : IDataViewModel
    {
        string Title { get; }
        string Name { get; }
        IList<IBookshelfItemViewModel> Shelves { get; }
    }
}