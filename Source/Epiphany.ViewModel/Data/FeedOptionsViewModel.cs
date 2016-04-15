using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System;
using System.Windows.Input;
using System.Threading.Tasks;
using Epiphany.Model.Settings;

namespace Epiphany.ViewModel
{
    public sealed class FeedOptionsViewModel : DataViewModel<VoidType>
    {
        private FeedOptions feedOptions;
        private FeedUpdateFilter updateFilter;
        private FeedUpdateType updateType;

        private readonly ICommand<FeedOptions> saveFeedOptionsCommand;
        private readonly ICommand goBackCommand;

        public FeedOptionsViewModel(INavigationService navigationService)
        {
            if (navigationService == null)
            {
                throw new ArgumentNullException();
            }

            this.saveFeedOptionsCommand = new SaveFeedOptionsCommand(navigationService);
            this.goBackCommand = new GoBackCommand(navigationService);
        }

        public FeedUpdateType CurrentUpdateType
        {
            get
            {
                return this.updateType;
            }
            set
            {
                if (this.updateType != value)
                {
                    this.updateType = value;
                    CreateFeedOptions();
                    RaisePropertyChanged(() => CurrentUpdateType);
                }
            }
        }

        public FeedUpdateFilter CurrentUpdateFilter
        {
            get
            {
                return this.updateFilter;
            }
            set
            {
                if (this.updateFilter != value)
                {
                    this.updateFilter = value;
                    CreateFeedOptions();
                    RaisePropertyChanged(() => CurrentUpdateFilter);
                }
            }
        }

        public FeedOptions FeedOptions
        {
            get
            {
                return this.feedOptions;
            }
            private set
            {
                if (this.feedOptions != value)
                {
                    this.feedOptions = value;
                    RaisePropertyChanged(() => FeedOptions);
                }
            }
        }

        public ICommand<FeedOptions> SaveOptions
        {
            get
            {
                return this.saveFeedOptionsCommand;
            }
        }

        public ICommand Cancel
        {
            get
            {
                return this.goBackCommand;
            }
        }

        private void CreateFeedOptions()
        {
            FeedOptions = new FeedOptions(CurrentUpdateType, CurrentUpdateFilter);
        }

        public override Task LoadAsync(VoidType parameter)
        {
            CurrentUpdateType = ApplicationSettings.Instance.UpdateType;
            CurrentUpdateFilter = ApplicationSettings.Instance.UpdateFilter;
            CreateFeedOptions();
            IsLoaded = true;
            return Task.FromResult<bool>(true);
        }
    }
}
