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
    public sealed class FeedViewModel : DataViewModel<VoidType>, IFeedViewModel
    {
        //
        // Private Members
        //
        private readonly INavigationService navigationService;
        private IFeedOptionsViewModel feedOptionsViewModel;
        private readonly IUserService userService;
        private readonly IResourceLoader resourceLoader;
        private IList<IFeedItemViewModel> items;
        private bool isFilterEnabled;
        private bool isFeedEmpty;
        //
        // Commands
        //
        private readonly IAsyncCommand<IEnumerable<FeedItemModel>, VoidType> fetchFeedItemsCommand;
        private readonly ICommand showOptionsCommand;

        public FeedViewModel(IUserService userService, INavigationService navigationService, IResourceLoader resourceLoader)
        {
            this.userService = userService;
            this.navigationService = navigationService;
            this.resourceLoader = resourceLoader;

            ApplicationSettings.Instance.SettingChanged += OnSettingChanged;

            this.Items = new ObservableCollection<IFeedItemViewModel>();
            this.fetchFeedItemsCommand = new FetchFeedCommand(userService);
            RegisterCommand(this.fetchFeedItemsCommand, OnFetchFeedExecuted);

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

        public IList<IFeedItemViewModel> Items
        {
            get { return items; }
            private set
            {
                if (items != value)
                {
                    items = value;
                    RaisePropertyChanged(() => Items);
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
                return this.fetchFeedItemsCommand;
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
                IEnumerable<FeedItemViewModel> items = null;
                try
                {
                    items = await Task.Run(async ()=>
                    {
                        IEnumerable<FeedItemModel> modelItems = await this.userService.GetFriendUpdatesAsync(FeedUpdateType.all, FeedUpdateFilter.friends);
                        IList<FeedItemViewModel> vmItems = new List<FeedItemViewModel>();
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
                    Items = new ObservableCollection<IFeedItemViewModel>(items);
                }

                IsFeedEmpty = Items.Count > 0 ? true : false;
                IsLoaded = true;
                IsLoading = false;
            }
        }

        private void OnFetchFeedExecuted(ExecutedEventArgs e)
        {
            if (e.State == CommandExecutionState.Success)
            {
                IEnumerable<FeedItemModel> items = this.FetchFeed.Result;
                Items = new ObservableCollection<IFeedItemViewModel>();
                if (items != null)
                {
                    foreach (FeedItemModel model in items)
                    {
                        Items.Add(new FeedItemViewModel(model, this.navigationService, this.resourceLoader)); 
                    }
                }

                if (this.Items.Count == 0)
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
