using Epiphany.Model.Services;
using Epiphany.Model.Settings;
using Epiphany.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public sealed class FeedOptionsViewModel : ViewModelBase, IFeedOptionsViewModel
    {
        private IList<ItemViewModel<FeedUpdateFilter>> updateFilters;
        private IList<ItemViewModel<FeedUpdateType>> updateTypes;
        private string optionsSummary;
        private bool optionsChanged;
        private ICommand refreshCommand;
        private ICommand saveCommand;
        private ICommand cancelCommand;

        private readonly IResourceLoader resourceLoader;
        private readonly string optionsSummaryStringKey = "FeedOptionsSummaryText";

        public FeedOptionsViewModel(IResourceLoader resourceLoader)
        {
            if (resourceLoader == null)
            {
                throw new ArgumentNullException(nameof(resourceLoader));
            }

            this.resourceLoader = resourceLoader;
            this.refreshCommand = new DelegateCommand(PopulateOptionsList);
            this.saveCommand = new DelegateCommand(SaveOptions);
            this.cancelCommand = new DelegateCommand(CancelOptions);
            PopulateOptionsList();
        }

        public IList<ItemViewModel<FeedUpdateFilter>> UpdateFilters
        {
            get
            {
                return this.updateFilters;
            }
            private set
            {
                SetProperty(ref this.updateFilters, value);
            }
        }

        public IList<ItemViewModel<FeedUpdateType>> UpdateTypes
        {
            get
            {
                return this.updateTypes;
            }
            private set
            {
                SetProperty(ref this.updateTypes, value);
            }
        }

        public ICommand Save
        {
            get
            {
                return this.saveCommand;
            }
        }

        public ICommand Cancel
        {
            get
            {
                return this.cancelCommand;
            }
        }

        public ICommand Refresh
        {
            get
            {
                return refreshCommand;
            }
        }

        public string OptionsSummary
        {
            get
            {
                return this.optionsSummary;
            }
            private set
            {
                SetProperty(ref this.optionsSummary, value);
            }
        }

        public bool OptionsChanged
        {
            get
            {
                return this.optionsChanged;
            }
            private set
            {
                SetProperty(ref this.optionsChanged, value);
            }
        }

        public FeedUpdateFilter CurrentUpdateFilter
        {
            get
            {
                FeedUpdateFilter defaultFilter = FeedUpdateFilter.friends;
                string filter = ApplicationSettings.Instance.UpdateFilter;
                Enum.TryParse<FeedUpdateFilter>(filter, out defaultFilter);
                return defaultFilter;
            }
        }

        public FeedUpdateType CurrentUpdateType
        {
            get
            {
                FeedUpdateType defaultType = FeedUpdateType.all;
                string type = ApplicationSettings.Instance.UpdateType;
                Enum.TryParse<FeedUpdateType>(type, out defaultType);
                return defaultType;
            }
        }

        private void PopulateOptionsList()
        {
            UpdateFilters = new ObservableCollection<ItemViewModel<FeedUpdateFilter>>();
            FeedUpdateFilter currentFilter = CurrentUpdateFilter;
            foreach (var item in Enum.GetValues(typeof(FeedUpdateFilter)).Cast<FeedUpdateFilter>())
            {
                UpdateFilters.Add(new ItemViewModel<FeedUpdateFilter>(item)
                {
                    IsSelected = (item == currentFilter)
                });
            }

            UpdateTypes = new ObservableCollection<ItemViewModel<FeedUpdateType>>();
            FeedUpdateType currentType = CurrentUpdateType;
            foreach (var item in Enum.GetValues(typeof(FeedUpdateType)).Cast<FeedUpdateType>())
            {
                UpdateTypes.Add(new ItemViewModel<FeedUpdateType>(item)
                {
                    IsSelected = (item == currentType)
                });
            }

            OptionsSummary = string.Format(this.resourceLoader.GetString(optionsSummaryStringKey), 
                this.resourceLoader.GetString(currentType), 
                this.resourceLoader.GetString(currentFilter));
        }

        private void SaveOptions()
        {
            var currentFilter = (from filter in UpdateFilters
                                 where filter.IsSelected == true
                                 select filter.Item).First();

            var currentType = (from type in UpdateTypes
                               where type.IsSelected == true
                               select type.Item).First();

            ApplicationSettings.Instance.UpdateFilter = currentFilter.ToString();
            ApplicationSettings.Instance.UpdateType = currentType.ToString();

            OptionsChanged = true;
        }

        private void CancelOptions()
        {
            OptionsChanged = false;
            PopulateOptionsList();
        }
    }
}
