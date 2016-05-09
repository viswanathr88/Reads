using Epiphany.Model.Services;
using Epiphany.ViewModel;
using System.Collections.Generic;
using System.Windows.Input;
using System;

namespace Epiphany.View.DesignData
{
    public class DesignFeedOptionsViewModel : ViewModelBase, IFeedOptionsViewModel
    {
        public DesignFeedOptionsViewModel()
        {
            OptionsSummary = "showing updates for books from friends";
        }

        public ICommand Cancel
        {
            get;
            set;
        }

        public FeedUpdateFilter CurrentUpdateFilter
        {
            get;
            set;
        }

        public FeedUpdateType CurrentUpdateType
        {
            get;
            set;
        }

        public bool OptionsChanged
        {
            get;
            set;
        }

        public string OptionsSummary
        {
            get;
            set;
        }

        public ICommand Refresh
        {
            get;
            set;
        }

        public ICommand Save
        {
            get;
            set;
        }

        public IList<ItemViewModel<FeedUpdateFilter>> UpdateFilters
        {
            get;
            set;
        }

        public IList<ItemViewModel<FeedUpdateType>> UpdateTypes
        {
            get;
            set;
        }
    }
}
