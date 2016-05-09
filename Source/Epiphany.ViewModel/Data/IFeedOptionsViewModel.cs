using Epiphany.Model.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public interface IFeedOptionsViewModel : INotifyPropertyChanged
    {
        IList<ItemViewModel<FeedUpdateFilter>> UpdateFilters { get; }
        IList<ItemViewModel<FeedUpdateType>> UpdateTypes { get; }
        FeedUpdateFilter CurrentUpdateFilter { get; }
        FeedUpdateType CurrentUpdateType { get; }
        string OptionsSummary { get; }
        bool OptionsChanged { get; }
        ICommand Refresh { get; }
        ICommand Save { get; }
        ICommand Cancel { get; }
    }
}