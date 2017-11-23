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
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public sealed class FeedViewModel : DataViewModel<VoidType>, IFeedViewModel
    {
        private IFeedOptionsViewModel feedOptionsViewModel;
        private readonly IUserService userService;
        private readonly IResourceLoader resourceLoader;
        private readonly INavigationService navService;
        private readonly IDeviceServices deviceServices;
        private IList<IFeedItemViewModel> items;
        private bool isFilterEnabled;
        private bool isFeedEmpty;
        
        public FeedViewModel(IUserService userService, IResourceLoader resourceLoader, INavigationService navService, IDeviceServices deviceServices)
        {
            this.userService = userService;
            this.resourceLoader = resourceLoader;
            this.navService = navService;
            this.deviceServices = deviceServices;

            this.Items = new ObservableCollection<IFeedItemViewModel>();

            this.feedOptionsViewModel = new FeedOptionsViewModel(resourceLoader);
            this.feedOptionsViewModel.PropertyChanged += FeedOptions_PropertyChanged;

            Refresh = new DelegateCommand(async () => await RefreshFeed());
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

        public ICommand Refresh
        {
            get;
            private set;
        }

        public override async Task LoadAsync(VoidType parameter)
        {
            if (!IsLoaded)
            {
                await RefreshFeed();
                IsLoaded = true;

            }
        }

        private async Task RefreshFeed()
        {
            IsLoading = true;

            IEnumerable<FeedItemViewModel> items = null;
            try
            {
                items = await Task.Run(async () =>
                {
                    IEnumerable<FeedItemModel> modelItems = await this.userService.GetFriendUpdatesAsync(FeedOptions.CurrentUpdateType, FeedOptions.CurrentUpdateFilter);
                    IList<FeedItemViewModel> vmItems = new List<FeedItemViewModel>();
                    foreach (var modelItem in modelItems)
                    {
                        vmItems.Add(new FeedItemViewModel(modelItem, this.resourceLoader, this.navService, this.deviceServices));
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
            IsLoading = false;
        }

        protected override void Reset()
        {
            // Do nothing here
        }
    }
}
