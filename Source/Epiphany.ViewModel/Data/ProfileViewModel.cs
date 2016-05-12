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
        private string username;
        private string imageUrl;
        private string location;
        private string memberSinceString;
        private int friendsCount;
        private int groupsCount;
        private int reviewsCount;
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
        private IList<IAuthorItemViewModel> favoriteAuthors;
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
            FavoriteAuthors = new ObservableCollection<IAuthorItemViewModel>();
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

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                SetProperty(ref this.username, value);
            }
        }

        public string MemberSinceString
        {
            get
            {
                return this.memberSinceString;
            }
            private set
            {
                SetProperty(ref this.memberSinceString, value);
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            private set
            {
                SetProperty(ref this.location, value);
            }
        }

        public int FriendsCount
        {
            get
            {
                return this.friendsCount;
            }
            private set
            {
                SetProperty(ref this.friendsCount, value);
            }
        }

        public int GroupsCount
        {
            get
            {
                return this.groupsCount;
            }
            private set
            {
                SetProperty(ref this.groupsCount, value);
            }
        }

        public int ReviewsCount
        {
            get
            {
                return this.reviewsCount;
            }
            private set
            {
                SetProperty(ref this.reviewsCount, value);
            }
        }

        public IList<IAuthorItemViewModel> FavoriteAuthors
        {
            get
            {
                return this.favoriteAuthors;
            }

            set
            {
                SetProperty(ref this.favoriteAuthors, value);
            }
        }

        public override async Task LoadAsync(UserModel user)
        {
            if (!IsLoaded && this.fetchProfileCommand.CanExecute(user.Id))
            {
                Id = user.Id;
                Name = user.Name;
                ImageUrl = user.ImageUrl;

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
                Name = Model.Name;
                Username = Model.Username;
                ImageUrl = Model.ImageUrl;
                FriendsCount = Model.FriendsCount;
                GroupsCount = Model.GroupsCount;
                ReviewsCount = Model.ReviewsCount;
                Location = Model.Location;
                ConstructMemberSinceString();

                FetchBookshelvesArg = this.bookshelfService.GetBookshelves(Id).GetEnumerator();
                ProfileItems = this.profileItemFactory.GetProfileItems(Model);

                RecentUpdates = new ObservableCollection<IFeedItemViewModel>();
                foreach (FeedItemModel model in Model.RecentUpdates)
                {
                    RecentUpdates.Add(new FeedItemViewModel(model, resourceLoader));
                }

                FavoriteAuthors = new ObservableCollection<IAuthorItemViewModel>();
                foreach (var author in Model.FavoriteAuthors)
                {
                    FavoriteAuthors.Add(new AuthorItemViewModel(author));
                }
                AreUpdatesEmpty = (RecentUpdates.Count == 0);

                IsLoaded = true;
            }
        }

        private void ConstructMemberSinceString()
        {
            if (Model.JoinDate != DateTime.MinValue)
            {
                MemberSinceString = string.Format("{0:MMM yyyy}", Model.JoinDate);
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
