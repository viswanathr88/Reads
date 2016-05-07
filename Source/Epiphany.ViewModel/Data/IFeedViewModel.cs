using Epiphany.Model;
using Epiphany.ViewModel.Items;
using System.Collections.Generic;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public interface IFeedViewModel : IDataViewModel
    {
        IList<IFeedItemViewModel> Items { get; }
        IFeedOptionsViewModel FeedOptionsViewModel { get; }
        IAsyncCommand<IEnumerable<FeedItemModel>, VoidType> FetchFeed { get; }
        bool IsFeedEmpty { get; }
        bool IsFilterEnabled { get; }
        ICommand ShowOptions { get; }
    }
}