using Epiphany.Model;
using Epiphany.Model.Collections;
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
    public sealed class ProfileViewModel : DataViewModel<UserModel>, IProfileViewModel
    {
        private int id;
        private string name;
        private string imageUrl;
        private ProfileModel profileModel;
        private readonly ProfileItemViewModelFactory profileItemFactory;

        private readonly IBookshelfService bookshelfService;
        private readonly INavigationService navService;
        private readonly IDeviceServices deviceServices;
        private readonly IResourceLoader resourceLoader;

        private readonly IAsyncCommand<ProfileModel, int> fetchProfileCommand;
        private readonly IAsyncCommand<IEnumerable<BookshelfModel>, IAsyncEnumerator<BookshelfModel>> fetchBookshelvesCommand;
        private IAsyncEnumerator<BookshelfModel> enumerator;
        private readonly ICommand goHomeCommand;
        private bool areShelvesEmpty;
        private bool areUpdatesEmpty;
        private bool shelvesLoaded;

        private IList<BookshelfModel> shelves;
        private IList<IProfileItemViewModel> profileItems;
        private IList<IFeedItemViewModel> recentUpdates;
        private BookshelfModel selectedShelf;
        private IProfileItemViewModel selectedProfileItem;

        public ProfileViewModel(IUserService userService, IBookshelfService bookshelfService, 
            INavigationService navService, IDeviceServices deviceServices, IResourceLoader resourceLoader)
        {
            if (userService == null || navService == null || bookshelfService == null || resourceLoader == null)
            {
                throw new ArgumentNullException("services");
            }

            this.bookshelfService = bookshelfService;
            this.navService = navService;
            this.deviceServices = deviceServices;
            this.resourceLoader = resourceLoader;
            this.profileItemFactory = new ProfileItemViewModelFactory();

            this.fetchProfileCommand = new FetchProfileCommand(userService);
            RegisterCommand(this.fetchProfileCommand, OnProfileFetched);

            this.fetchBookshelvesCommand = new EnumeratorCommand<BookshelfModel>(20);
            RegisterCommand(fetchBookshelvesCommand, OnBookshelvesFetched);

            this.goHomeCommand = new GoHomeCommand(navService);

            Shelves = new ObservableCollection<BookshelfModel>();
            ProfileItems = new ObservableCollection<IProfileItemViewModel>();
            RecentUpdates = new ObservableCollection<IFeedItemViewModel>();
        }

        public int Id
        {
            get { return this.id;  }
            set
            {
                if (this.id == value) return;
                this.id = value;
                RaisePropertyChanged();
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name == value) return;
                this.name = value.Trim();
                RaisePropertyChanged();
            }
        }

        public ProfileModel Model
        {
            get { return this.profileModel; }
            private set
            {
                if (this.profileModel == value) return;
                this.profileModel = value;
                RaisePropertyChanged();
            }
        }

        public bool AreShelvesEmpty
        {
            get { return this.areShelvesEmpty; }
            private set
            {
                if (this.areShelvesEmpty == value) return;
                this.areShelvesEmpty = value;
                RaisePropertyChanged();
            }
        }

        public bool AreUpdatesEmpty
        {
            get
            {
                return this.areUpdatesEmpty;
            }
            private set
            {
                if (this.areUpdatesEmpty == value) return;
                this.areUpdatesEmpty = value;
                RaisePropertyChanged();
            }
        }

        public bool ShelvesLoaded
        {
            get { return this.shelvesLoaded; }
            private set
            {
                if (this.shelvesLoaded == value) return;
                this.shelvesLoaded = value;
                RaisePropertyChanged();
            }
        }

        public string ImageUrl
        {
            get { return this.imageUrl; }
            private set
            {
                if (this.imageUrl == value) return;
                this.imageUrl = value;
                RaisePropertyChanged();
            }
        }

        public IList<BookshelfModel> Shelves
        {
            get { return this.shelves; }
            private set
            {
                if (this.shelves == value) return;
                this.shelves = value;
                RaisePropertyChanged();
            }
        }

        public BookshelfModel SelectedShelf
        {
            get { return this.selectedShelf; }
            set
            {
                if (this.selectedShelf == value) return;
                this.selectedShelf = value;

                this.navService.CreateFor<BooksViewModel>()
                    .AddParam<int>((x) => x.UserId, Id)
                    .AddParam<string>((x) => x.UserName, Name)
                    .AddParam<string>((x) => x.ShelfName, this.selectedShelf.Name)
                    .Navigate();

                this.selectedShelf = null;
                RaisePropertyChanged();
            }
        }

        public IProfileItemViewModel SelectedProfileItem
        {
            get { return this.selectedProfileItem; }
            set
            {
                if (this.selectedProfileItem == value) return;
                this.selectedProfileItem = value;

                switch (this.selectedProfileItem.Type)
                {
                    case ProfileItemType.Friends:
                        {
                            this.navService.CreateFor<FriendsViewModel>()
                                .AddParam<int>((x) => x.Id, Id)
                                .AddParam<string>((x) => x.Name, Name)
                                .Navigate();
                            break;
                        }

                    case ProfileItemType.Groups:
                        {
                            /*this.navService.CreateFor<GroupsViewModel>()
                                .AddParam<int>((x) => x.Id, Id)
                                .AddParam<string>((x) => x.Name, Name)
                                .Navigate();*/
                            break;
                        }

                    case ProfileItemType.ViewInGoodreads:
                        {
                            this.deviceServices.LaunchUrl(this.selectedProfileItem.Value);
                            break;
                        }
                    default:
                        break;
                }
                this.selectedProfileItem = null;
                RaisePropertyChanged(() => SelectedProfileItem);
            }
        }

        public IList<IProfileItemViewModel> ProfileItems
        {
            get { return this.profileItems; }
            set
            {
                if (this.profileItems == value) return;
                this.profileItems = value;
                RaisePropertyChanged();
            }
        }

        public IList<IFeedItemViewModel> RecentUpdates
        {
            get { return this.recentUpdates; }
            private set
            {
                if (this.recentUpdates == value) return;
                this.recentUpdates = value;
                RaisePropertyChanged();
            }
        }

        public ICommand GoHome
        {
            get { return this.goHomeCommand; }
        }

        public IAsyncCommand<ProfileModel, int> FetchProfile
        {
            get { return this.fetchProfileCommand; }
        }

        public IAsyncCommand<IEnumerable<BookshelfModel>, IAsyncEnumerator<BookshelfModel>> FetchBookshelves
        {
            get { return this.fetchBookshelvesCommand; }
        }

        public IAsyncEnumerator<BookshelfModel> FetchBookshelvesArg
        {
            get { return this.enumerator; }
            private set
            {
                if (this.enumerator == value) return;
                this.enumerator = value;
                RaisePropertyChanged();
            }
        }

        public override async Task LoadAsync(UserModel user)
        {
            if (!IsLoaded && this.fetchProfileCommand.CanExecute(user.Id))
            {
                await this.fetchProfileCommand.ExecuteAsync(user.Id);
            }
        }

        private void OnCommandExecuting(object sender, CancelEventArgs e)
        {
            IsLoading = true;
        }

        private void OnProfileFetched(ExecutedEventArgs e)
        {
            IsLoading = false;
            if (e.State == CommandExecutionState.Success)
            {
                Model = this.fetchProfileCommand.Result;
                ImageUrl = Model.ImageUrl;
                FetchBookshelvesArg = this.bookshelfService.GetBookshelves(Id).GetEnumerator();
                ProfileItems = this.profileItemFactory.GetProfileItems(Model);

                RecentUpdates = new ObservableCollection<IFeedItemViewModel>();
                foreach (FeedItemModel model in Model.RecentUpdates)
                {
                    RecentUpdates.Add(new FeedItemViewModel(model, navService, resourceLoader));
                }
                AreUpdatesEmpty = (RecentUpdates.Count == 0);

                IsLoaded = true;
            }
        }
        private void OnBookshelvesFetched(ExecutedEventArgs e)
        {
            IsLoading = false;
            if (e.State == CommandExecutionState.Success)
            {
                foreach (BookshelfModel shelf in this.fetchBookshelvesCommand.Result)
                {
                    Shelves.Add(shelf);
                }
                AreShelvesEmpty = (Shelves.Count == 0);
                ShelvesLoaded = true;
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            DeregisterCommand(this.fetchProfileCommand);
            DeregisterCommand(this.fetchBookshelvesCommand);
        }
    }
}
