using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    sealed class FeedOptionsViewModel : DataViewModel<VoidType>, IFeedOptionsViewModel
    {
        private readonly IAppSettings appSettings;
        private FeedOptions feedOptions;
        private FeedUpdateFilter updateFilter;
        private FeedUpdateType updateType;

        private readonly ICommand<FeedOptions> saveFeedOptionsCommand;
        private readonly ICommand goBackCommand;

        public FeedOptionsViewModel(IAppSettings appSettings, INavigationService navigationService)
        {
            if (appSettings == null || navigationService == null)
            {
                throw new ArgumentNullException();
            }

            this.appSettings = appSettings;
            this.saveFeedOptionsCommand = new SaveFeedOptionsCommand(appSettings, navigationService);
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

        public override async Task LoadAsync(VoidType parameter)
        {
            CurrentUpdateType = appSettings.UpdateType;
            CurrentUpdateFilter = appSettings.UpdateFilter;
            CreateFeedOptions();
            IsLoaded = true;
        }
    }
}
