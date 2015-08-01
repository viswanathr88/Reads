using Epiphany.Model;
using Epiphany.ViewModel.Commands;
using System.Collections.ObjectModel;
namespace Epiphany.ViewModel
{
    public interface IAddBookViewModel : IDataViewModel
    {
        /// <summary>
        /// Add the book to selected shelves
        /// </summary>
        ICommand<AddToShelvesCommandArgs> AddToShelves { get; }
        /// <summary>
        /// Parameters for Add to shelves command
        /// </summary>
        AddToShelvesCommandArgs AddToShelvesArgs { get; }
        /// <summary>
        /// Gets the book that is being added
        /// </summary>
        BookModel Book { get; }
        /// <summary>
        /// Create a new shelf
        /// </summary>
        ICommand<string> CreateShelf { get; }
        /// <summary>
        /// Gets the custom shelves
        /// </summary>
        ObservableCollection<CustomBookshelfItemViewModel> CustomShelves { get; }
        /// <summary>
        /// Gets the ID of the book
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Returns true if the currently reading shelf is selected
        /// </summary>
        bool IsCurrentlyReadingSelected { get; set; }
        /// <summary>
        /// Returns true if the read shelf is selected
        /// </summary>
        bool IsReadSelected { get; set; }
        /// <summary>
        /// Returns true if the to-read shelf is selected
        /// </summary>
        bool IsToReadSelected { get; set; }
        /// <summary>
        /// Gets the name of the shelf that is being created
        /// </summary>
        string ShelfName { get; set; }
        /// <summary>
        /// Gets the title
        /// </summary>
        string Title { get; }
    }
}
