
using Epiphany.Model;
using System.Collections.Generic;
using System.Windows.Input;
namespace Epiphany.ViewModel
{
    public interface IEventsViewModel : IDataViewModel
    {
        /// <summary>
        /// Gets the list of events
        /// </summary>
        IList<LiteraryEventModel> Events { get; }
        /// <summary>
        /// Fetches the list of events
        /// </summary>
        IAsyncCommand<IEnumerable<LiteraryEventModel>, VoidType> FetchEvents { get; }
        /// <summary>
        /// Refreshes the list of events
        /// </summary>
        ICommand Refresh { get; }
        /// <summary>
        /// Selected event
        /// </summary>
        LiteraryEventModel SelectedEvent { get; set; }
    }
}
