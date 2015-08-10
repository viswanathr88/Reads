using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Items;
using Epiphany.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    sealed class FeedViewModel : DataViewModel, IFeedViewModel
    {
        //
        // Private Members
        //
        private readonly INavigationService navigationService;
        private IFeedOptionsViewModel feedOptionsViewModel;
        private readonly IUserService userService;
        private readonly IAppSettings appSettings;
        private readonly IResourceLoader resourceLoader;
        private IList<IFeedItemViewModel> feed;
        private bool isFilterEnabled;
        private bool isFeedEmpty;
        //
        // Commands
        //
        private readonly IAsyncCommand<IEnumerable<FeedItemModel>, VoidType> fetchFeedCommand;
        private readonly ICommand showOptionsCommand;

        public FeedViewModel(IUserService userService, INavigationService navigationService, 
            IAppSettings appSettings, IResourceLoader resourceLoader)
        {
            if (userService == null || navigationService == null || appSettings == null || resourceLoader == null)
            {
                throw new ArgumentNullException("services");
            }

            this.userService = userService;
            this.appSettings = appSettings;
            this.navigationService = navigationService;
            this.resourceLoader = resourceLoader;

            this.appSettings.SettingChanged += OnSettingChanged;

            this.Feed = new ObservableCollection<IFeedItemViewModel>();
            this.fetchFeedCommand = new FetchFeedCommand(userService);
            this.fetchFeedCommand.Executing += OnCommandExecuting;
            this.fetchFeedCommand.Executed += OnFetchFeedExecuted;

            this.showOptionsCommand = new ShowOptionsCommand(navigationService);

            IsFilterEnabled = ComputeIsFilterEnabled();
        }

        public bool IsFeedEmpty
        {
            get { return isFeedEmpty; }
            private set
            {
                if (isFeedEmpty != value)
                {
                    isFeedEmpty = value;
                    RaisePropertyChanged(() => IsFeedEmpty);
                }
            }
        }

        public IList<IFeedItemViewModel> Feed
        {
            get { return feed; }
            private set
            {
                if (feed != value)
                {
                    feed = value;
                    RaisePropertyChanged(() => Feed);
                }
            }
        }

        public bool IsFilterEnabled
        {
            get { return isFilterEnabled; }
            private set
            {
                if (isFilterEnabled != value)
                {
                    isFilterEnabled = value;
                    RaisePropertyChanged(() => IsFilterEnabled);
                }
            }
        }

        public IFeedOptionsViewModel FeedOptionsViewModel
        {
            get
            {
                if (this.feedOptionsViewModel == null)
                {
                    this.feedOptionsViewModel = new FeedOptionsViewModel(this.appSettings, this.navigationService);
                }

                return this.feedOptionsViewModel;
            }
        }

        public IAsyncCommand<IEnumerable<FeedItemModel>, VoidType> FetchFeed
        {
            get
            {
                return this.fetchFeedCommand;
            }
        }

        public ICommand ShowOptions
        {
            get
            {
                return this.showOptionsCommand;
            }
        }

        public override async Task LoadAsync()
        {
            if (this.fetchFeedCommand.CanExecute(VoidType.Empty))
            {
                await this.fetchFeedCommand.ExecuteAsync(VoidType.Empty);
            }
        }

        private void OnFetchFeedExecuted(object sender, ExecutedEventArgs e)
        {
            if (e.State == CommandExecutionState.Success)
            {
                IEnumerable<FeedItemModel> items = this.FetchFeed.Result;
                Feed = new ObservableCollection<IFeedItemViewModel>();
                if (items != null)
                {
                    foreach (FeedItemModel model in items)
                    {
                        Feed.Add(new FeedItemViewModel(model, this.navigationService, this.resourceLoader)); 
                    }
                }

                if (this.Feed.Count == 0)
                {
                    IsFeedEmpty = true;
                }
                IsLoaded = true;
            }

            IsLoading = false;
        }

        private void OnCommandExecuting(object sender, CancelEventArgs e)
        {
            IsLoading = true;
        }

        private void OnSettingChanged(object sender, SettingsChangedEventArgs e)
        {
            if (e.SettingName == "UpdateType" || e.SettingName == "UpdateFilter")
            {
                IsFilterEnabled = ComputeIsFilterEnabled();
            }
        }

        private bool ComputeIsFilterEnabled()
        {
            return !(this.appSettings.UpdateFilter == FeedUpdateFilter.friends &&
                this.appSettings.UpdateType == FeedUpdateType.all);
        }
    }
}
