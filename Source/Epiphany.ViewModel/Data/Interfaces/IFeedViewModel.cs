using Epiphany.Model;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Items;
using System.Collections.Generic;
using System.Windows.Input;
namespace Epiphany.ViewModel
{
    public interface IFeedViewModel : IDataViewModel
    {
        /// <summary>
        /// Gets the Feed items
        /// </summary>
        IList<IFeedItemViewModel> Feed { get; }
        /// <summary>
        /// Gets the feed options
        /// </summary>
        IFeedOptionsViewModel FeedOptionsViewModel { get; }
        /// <summary>
        /// Fetch the feed items
        /// </summary>
        IAsyncCommand<IEnumerable<FeedItemModel>, VoidType> FetchFeed { get; }
        /// <summary>
        /// Returns true if there are no feed items
        /// </summary>
        bool IsFeedEmpty { get; }
        /// <summary>
        /// Returns true if some filter is enabled
        /// </summary>
        bool IsFilterEnabled { get; }
        /// <summary>
        /// Shows the feed options
        /// </summary>
        ICommand ShowOptions { get; }
    }
}
