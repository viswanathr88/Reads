using Epiphany.Logging;
using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.Model.Settings;
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
    sealed class FeedViewModel : DataViewModel<VoidType>, IFeedViewModel
    {
        //
        // Private Members
        //
        private readonly INavigationService navigationService;
        private IFeedOptionsViewModel feedOptionsViewModel;
        private readonly IUserService userService;
        private readonly IResourceLoader resourceLoader;
        private IList<IFeedItemViewModel> feed;
        private bool isFilterEnabled;
        private bool isFeedEmpty;
        //
        // Commands
        //
        private readonly IAsyncCommand<IEnumerable<FeedItemModel>, VoidType> fetchFeedCommand;
        private readonly ICommand showOptionsCommand;

        public FeedViewModel(IUserService userService, INavigationService navigationService, IResourceLoader resourceLoader)
        {
            if (userService == null || navigationService == null || resourceLoader == null)
            {
                throw new ArgumentNullException("services");
            }

            this.userService = userService;
            this.navigationService = navigationService;
            this.resourceLoader = resourceLoader;

            ApplicationSettings.Instance.SettingChanged += OnSettingChanged;

            this.Feed = new ObservableCollection<IFeedItemViewModel>();
            this.fetchFeedCommand = new FetchFeedCommand(userService);
            RegisterCommand(this.fetchFeedCommand, OnFetchFeedExecuted);

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
                    this.feedOptionsViewModel = new FeedOptionsViewModel(this.navigationService);
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

        public override async Task LoadAsync(VoidType parameter)
        {
            if (!IsLoaded)
            {
                IsLoading = true;
                IEnumerable<IFeedItemViewModel> items = null;
                try
                {
                    items = await Task.Run(async ()=>
                    {
                        IEnumerable<FeedItemModel> modelItems = await this.userService.GetFriendUpdatesAsync(FeedUpdateType.all, FeedUpdateFilter.friends);
                        IList<IFeedItemViewModel> vmItems = new List<IFeedItemViewModel>();
                        foreach (var modelItem in modelItems)
                        {
                            vmItems.Add(new FeedItemViewModel(modelItem, this.navigationService, this.resourceLoader));
                        }
                        return vmItems;
                    });
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex.ToString());
                }

                if (items != null)
                {
                    Feed = new ObservableCollection<IFeedItemViewModel>(items);
                }

                IsFeedEmpty = Feed.Count > 0 ? true : false;
                IsLoaded = true;
                IsLoading = false;
            }

            /*if (this.fetchFeedCommand.CanExecute(parameter))
            {
                await this.fetchFeedCommand.ExecuteAsync(parameter);
            }*/
        }

        private void OnFetchFeedExecuted(ExecutedEventArgs e)
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

        private void OnSettingChanged(object sender, SettingChangedEventArgs e)
        {
            if (e.SettingName == nameof(ApplicationSettings.Instance.UpdateType) || 
                e.SettingName == nameof(ApplicationSettings.Instance.UpdateFilter))
            {
                IsFilterEnabled = ComputeIsFilterEnabled();
            }
        }

        private bool ComputeIsFilterEnabled()
        {
            return !(ApplicationSettings.Instance.UpdateFilter == FeedUpdateFilter.friends &&
                ApplicationSettings.Instance.UpdateType == FeedUpdateType.all);
        }
    }
}
