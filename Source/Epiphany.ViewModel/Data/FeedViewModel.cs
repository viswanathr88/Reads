using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.Settings;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public class FeedViewModel : DataViewModel
    {
        //
        // Private Members
        //
        private readonly INavigationService navigationService;
        private FeedOptionsViewModel feedOptionsViewModel;
        private readonly IUserService userService;
        private readonly IAppSettings appSettings;
        private IList<FeedItemViewModel> feed;
        private bool isFilterEnabled;
        private bool isFeedEmpty;
        //
        // Commands
        //
        private readonly ICommand<IEnumerable<FeedItemModel>, VoidType> fetchFeedCommand;
        private readonly ICommand showOptionsCommand;

        public FeedViewModel(IUserService userService, INavigationService navigationService, IAppSettings appSettings)
        {
            if (userService == null || navigationService == null || appSettings == null)
            {
                throw new ArgumentNullException();
            }

            this.userService = userService;
            this.appSettings = appSettings;
            this.navigationService = navigationService;

            this.appSettings.PropertyChanged += OnSettingChanged;

            this.Feed = new ObservableCollection<FeedItemViewModel>();
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

        public IList<FeedItemViewModel> Feed
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

        public FeedOptionsViewModel FeedOptionsViewModel
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

        public ICommand<IEnumerable<FeedItemModel>, VoidType> FetchFeed
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

        public override void Load()
        {
            if (!IsLoaded)
            {
                this.fetchFeedCommand.Execute(VoidType.Empty);
            }
        }

        private void OnFetchFeedExecuted(object sender, ExecutedEventArgs e)
        {
            IsLoading = false;
            if (e.State == CommandExecutionState.Success)
            {
                IEnumerable<FeedItemModel> items = this.FetchFeed.Result;
                Feed = new ObservableCollection<FeedItemViewModel>();
                if (items != null)
                {
                    foreach (FeedItemModel model in items)
                    {
                        //IFeedItemViewModel vm = 
                    }
                }

                if (this.Feed.Count == 0)
                {
                    IsFeedEmpty = true;
                }
                IsLoaded = false;
            }
        }

        private void OnCommandExecuting(object sender, CancelEventArgs e)
        {
            IsLoading = true;
        }

        private void OnSettingChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "UpdateType" || e.PropertyName == "UpdateFilter")
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
