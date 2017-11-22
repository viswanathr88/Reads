using System.Collections.Generic;
using System.Windows.Input;
using Epiphany.Model;
using Epiphany.ViewModel.Items;

namespace Epiphany.ViewModel
{
    /// <summary>
    /// ViewModel interface for literary events
    /// </summary>
    public interface IEventsViewModel : IDataViewModel
    {
        /// <summary>
        /// Gets the literary events
        /// </summary>
        IList<IEventItemViewModel> Events { get; }
        /// <summary>
        /// Command to fetch literary events
        /// </summary>
        IAsyncCommand<IEnumerable<LiteraryEventModel>, VoidType> FetchEvents { get; }
        /// <summary>
        /// Command to refresh the list of events
        /// </summary>
        ICommand Refresh { get; }
        /// <summary>
        /// Gets or sets the current selected event
        /// </summary>
        IEventItemViewModel SelectedEvent { get; set; }
    }
}