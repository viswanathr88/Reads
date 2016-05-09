using Epiphany.Logging;
using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Items;
using Epiphany.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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

        public FeedViewModel(IUserService userService, INavigationService navigationService, IResourceLoader resourceLoader)
        {
            this.userService = userService;
            this.navigationService = navigationService;
            this.resourceLoader = resourceLoader;

            this.Items = new ObservableCollection<IFeedItemViewModel>();
            this.fetchFeedItemsCommand = new FetchFeedCommand(userService);
            RegisterCommand(this.fetchFeedItemsCommand, OnFetchFeedExecuted);

            this.feedOptionsViewModel = new FeedOptionsViewModel(resourceLoader);
            this.feedOptionsViewModel.PropertyChanged += FeedOptions_PropertyChanged;
        }

        private async void FeedOptions_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this.feedOptionsViewModel.OptionsChanged))
            {
                if (this.feedOptionsViewModel.OptionsChanged)
                {
                    IsLoaded = false;
                    await LoadAsync(null);
                }
            }
        }

        public bool IsFeedEmpty
        {
            get { return isFeedEmpty; }
            private set
            {
                SetProperty(ref this.isFeedEmpty, value);
            }
        }

        public IList<IFeedItemViewModel> Items
        {
            get { return items; }
            private set
            {
                SetProperty(ref this.items, value);
            }
        }

        public bool IsFilterEnabled
        {
            get { return isFilterEnabled; }
            private set
            {
                SetProperty(ref this.isFilterEnabled, value);
            }
        }

        public IFeedOptionsViewModel FeedOptions
        {
            get
            {
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
                        IEnumerable<FeedItemModel> modelItems = await this.userService.GetFriendUpdatesAsync(FeedOptions.CurrentUpdateType, FeedOptions.CurrentUpdateFilter);
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

                IsFeedEmpty = Items.Count <= 0 ? true : false;
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
    }
}
