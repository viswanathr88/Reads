using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using System.Windows.Input;
namespace Epiphany.ViewModel
{
    public interface IFeedOptionsViewModel : IDataViewModel
    {
        /// <summary>
        /// Close the options and do not save preferences
        /// </summary>
        ICommand Cancel { get; }
        /// <summary>
        /// Get or set the current filter
        /// </summary>
        FeedUpdateFilter CurrentUpdateFilter { get; set; }
        /// <summary>
        /// Gets or sets the current readStatus type
        /// </summary>
        FeedUpdateType CurrentUpdateType { get; set; }
        /// <summary>
        /// Gets the feed options
        /// </summary>
        FeedOptions FeedOptions { get; }
        /// <summary>
        /// Saves the options
        /// </summary>
        ICommand<FeedOptions> SaveOptions { get; }
    }
}
