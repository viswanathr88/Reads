using System.Collections.ObjectModel;
using Epiphany.Model;
using Epiphany.ViewModel.Commands;

namespace Epiphany.ViewModel
{
    public interface IAddBookViewModel : IDataViewModel
    {
        ICommand<AddToShelvesCommandArgs> AddToShelves { get; }
        AddToShelvesCommandArgs AddToShelvesArgs { get; }
        BookModel Book { get; }
        ICommand<string> CreateShelf { get; }
        ObservableCollection<ICustomBookshelfItemViewModel> CustomShelves { get; }
        long Id {get; }
        bool IsCurrentlyReadingSelected { get; set; }
        bool IsReadSelected { get; set; }
        bool IsToReadSelected { get; set; }
        string ShelfName { get; set; }
        string Title { get; }
    }
}