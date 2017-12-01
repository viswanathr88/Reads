using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    /// <summary>
    /// ViewModel interface for literary events
    /// </summary>
    public interface IEventsViewModel : IDataViewModel<VoidType>
    {
        /// <summary>
        /// Gets the literary events
        /// </summary>
        ILazyObservableCollection<IEventItemViewModel> Events { get; }
        /// <summary>
        /// Command to refresh the list of events
        /// </summary>
        ICommand Refresh { get; }
    }
}