using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Items;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public interface IBookshelvesViewModel : IDataViewModel
    {
        /// <summary>
        /// Gets the title
        /// </summary>
        string Title { get; }
        /// <summary>
        /// Gets the name of the user
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Gets whether shelves can be edited
        /// </summary>
        bool CanEdit { get; }
        /// <summary>
        /// Gets the list of bookshelves
        /// </summary>
        ILazyObservableCollection<IBookshelfItemViewModel> Shelves { get; }
        /// <summary>
        /// Gets or sets the new shelf name
        /// </summary>
        string NewShelfName { get; set; }
        /// <summary>
        /// Create a new shelf
        /// </summary>
        ICommand<string> CreateShelf { get; } 
        /// <summary>
        /// Cancel creating a new shelf
        /// </summary>
        ICommand CancelCreateShelf { get; }
    }
}