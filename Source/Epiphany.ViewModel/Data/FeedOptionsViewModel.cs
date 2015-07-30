using Epiphany.Model.Services;
using Epiphany.Settings;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public class FeedOptionsViewModel : DataViewModel<VoidType>
    {
        private readonly IAppSettings appSettings;
        private FeedOptions feedOptions;
        private FeedUpdateFilter updateFilter;
        private FeedUpdateType updateType;

        private readonly ICommand<VoidType, FeedOptions> saveFeedOptionsCommand;
        private readonly ICommand<VoidType, VoidType> goBackCommand;

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

        public ICommand<VoidType, FeedOptions> SaveOptions
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

        public override void Load(VoidType param)
        {
            Load();
        }

        public override void Load()
        {
            if (!IsLoaded)
            {
                CurrentUpdateType = appSettings.UpdateType;
                CurrentUpdateFilter = appSettings.UpdateFilter;
                CreateFeedOptions();
                IsLoaded = true;
            }
        }

        private void CreateFeedOptions()
        {
            FeedOptions = new FeedOptions(CurrentUpdateType, CurrentUpdateFilter);
        }
    }
}
