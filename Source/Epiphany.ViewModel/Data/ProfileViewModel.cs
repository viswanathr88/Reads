using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Items;
using Epiphany.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Epiphany.ViewModel
{
    public sealed class ProfileViewModel : DataViewModel<UserModel>, IProfileViewModel
    {
        private long id;
        private string name;
        private string username;
        private string imageUrl;
        private string location;
        private string memberSinceString;
        private int friendsCount;
        private int groupsCount;
        private int reviewsCount;
        private int shelvesCount;
        private bool areUpdatesEmpty;
        private bool hasFavoriteAuthors;
        private ProfileModel profileModel;

        private Visibility profileActionsVisibility = Visibility.Collapsed;
        private Visibility followReviewsVisibility = Visibility.Collapsed;
        private Visibility followingReviewsVisibility = Visibility.Collapsed;
        private Visibility requestPendingVisibility = Visibility.Collapsed;

        private readonly IResourceLoader resourceLoader;
        private readonly IUserService userService;
        private readonly ILogonService logonService;
        private readonly INavigationService navService;
        private readonly IDeviceServices deviceServices;

        private IList<IFeedItemViewModel> recentUpdates;
        private IList<IAuthorItemViewModel> favoriteAuthors;

        private readonly IAsyncCommand<ProfileModel> sendFriendRequestCommand;
        private readonly IAsyncCommand<ProfileModel> followUserCommand;

        public ProfileViewModel(IUserService userService, IResourceLoader resourceLoader, ILogonService logonService,
            INavigationService navService, IDeviceServices deviceServices)
        {
            if (userService == null)
            {
                throw new ArgumentNullException(nameof(userService));
            }
            if (resourceLoader == null)
            {
                throw new ArgumentNullException(nameof(resourceLoader));
            }

            this.resourceLoader = resourceLoader;
            this.userService = userService;
            this.logonService = logonService;
            this.navService = navService;
            this.deviceServices = deviceServices;

            RecentUpdates = new ObservableCollection<IFeedItemViewModel>();
            FavoriteAuthors = new ObservableCollection<IAuthorItemViewModel>();

            this.sendFriendRequestCommand = new SendFriendRequestCommand(userService);
            this.sendFriendRequestCommand.Executed += OnProfileActionCompleted;

            this.followUserCommand = new ToggleFollowUserCommand(userService);
            this.followUserCommand.Executed += OnProfileActionCompleted;
        }

        public long Id
        {
            get { return this.id;  }
            private set
            {
                SetProperty(ref this.id, value);
            }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                SetProperty(ref this.name, value);
            }
        }

        public ProfileModel Model
        {
            get { return this.profileModel; }
            private set
            {
                SetProperty(ref this.profileModel, value);
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
                SetProperty(ref this.areUpdatesEmpty, value);
            }
        }

        public string ImageUrl
        {
            get { return this.imageUrl; }
            private set
            {
                SetProperty(ref this.imageUrl, value);
            }
        }

        public IList<IFeedItemViewModel> RecentUpdates
        {
            get { return this.recentUpdates; }
            private set
            {
                SetProperty(ref this.recentUpdates, value);
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

        public int ShelvesCount
        {
            get
            {
                return this.shelvesCount;
            }
            private set
            {
                SetProperty(ref this.shelvesCount, value);
            }
        }

        public bool HasFavoriteAuthors
        {
            get
            {
                return this.hasFavoriteAuthors;
            }
            private set
            {
                SetProperty(ref this.hasFavoriteAuthors, value);
            }
        }

        public Visibility ProfileActionsVisibility
        {
            get
            {
                return this.profileActionsVisibility;
            }
            private set
            {
                SetProperty(ref this.profileActionsVisibility, value);
            }
        }

        public Visibility FollowUserVisibility
        {
            get
            {
                return this.followReviewsVisibility;
            }
            private set
            {
                SetProperty(ref this.followReviewsVisibility, value);
            }
        }

        public Visibility FollowingUserVisibility
        {
            get
            {
                return this.followingReviewsVisibility;
            }
            private set
            {
                SetProperty(ref this.followingReviewsVisibility, value);
            }
        }

        public Visibility RequestPendingVisibility
        {
            get
            {
                return this.requestPendingVisibility;
            }
            private set
            {
                SetProperty(ref this.requestPendingVisibility, value);
            }
        }

        public IAsyncCommand<ProfileModel> SendFriendRequest
        {
            get
            {
                return this.sendFriendRequestCommand;
            }
        }

        public IAsyncCommand<ProfileModel> ToggleFollowReviews
        {
            get
            {
                return this.followUserCommand;
            }
        }

        public override async Task LoadAsync(UserModel user)
        {
            IsLoading = true;
            Id = user.Id;
            Name = user.Name;
            ImageUrl = user.ImageUrl;

            Model = await Task.Run(async () => await this.userService.GetProfileAsync(Id));
            Name = Model.Name;
            Username = Model.Username;
            ImageUrl = Model.ImageUrl;
            FriendsCount = Model.FriendsCount;
            GroupsCount = Model.GroupsCount;
            ReviewsCount = Model.ReviewsCount;
            ShelvesCount = Model.ShelvesCount;
            Location = !string.IsNullOrEmpty(Model.Location) ? Model.Location : "Unknown";
            ConstructMemberSinceString();

            int id = -1;
            if (this.logonService.Session != null && int.TryParse(this.logonService.Session.UserId, out id)
                && id == Parameter.Id)
            {
                ProfileActionsVisibility = Visibility.Collapsed;
                RequestPendingVisibility = Visibility.Collapsed;
                FollowingUserVisibility = Visibility.Collapsed;
                FollowingUserVisibility = Visibility.Collapsed;
            }
            else if (Model.IsPendingFriendRequest)
            {
                ProfileActionsVisibility = Visibility.Collapsed;
                RequestPendingVisibility = Visibility.Visible;
                FollowingUserVisibility = Visibility.Collapsed;
                FollowingUserVisibility = Visibility.Collapsed;
            }
            else
            {
                ProfileActionsVisibility = Model.IsFriend ? Visibility.Collapsed : Visibility.Visible;
                FollowUserVisibility = Model.IsFollowing ? Visibility.Collapsed : Visibility.Visible;
                FollowingUserVisibility = Model.IsFollowing ? Visibility.Visible : Visibility.Collapsed;
            }

            RecentUpdates = new ObservableCollection<IFeedItemViewModel>();
            foreach (FeedItemModel model in Model.RecentUpdates)
            {
                RecentUpdates.Add(new FeedItemViewModel(model, resourceLoader, this.navService, this.deviceServices));
            }

            FavoriteAuthors = new ObservableCollection<IAuthorItemViewModel>();
            foreach (var author in Model.FavoriteAuthors)
            {
                FavoriteAuthors.Add(new AuthorItemViewModel(author));
            }
            AreUpdatesEmpty = (RecentUpdates.Count == 0);
            HasFavoriteAuthors = (FavoriteAuthors.Count != 0);
            IsLoading = false;
            IsLoaded = true;
        }

        protected override void Reset()
        {
            base.Reset();

            Id = -1;
            Name = string.Empty;
            ImageUrl = string.Empty;
            Model = null;
            FriendsCount = 0;
            GroupsCount = 0;
            ReviewsCount = 0;
            ShelvesCount = 0;
            Location = string.Empty;
            MemberSinceString = string.Empty;
            RecentUpdates = null;
            FavoriteAuthors = null;
            AreUpdatesEmpty = false;
            HasFavoriteAuthors = false;
            RequestPendingVisibility = Visibility.Collapsed;
            ProfileActionsVisibility = Visibility.Collapsed;
            FollowingUserVisibility = Visibility.Collapsed;
            FollowUserVisibility = Visibility.Collapsed;
        }

        private async void OnProfileActionCompleted(object sender, ExecutedEventArgs e)
        {
            if (e.State == CommandExecutionState.Success)
            {
                // Reload the profile
                Reset();
                await LoadAsync(Parameter);
            }
        }

        private void ConstructMemberSinceString()
        {
            if (Model.JoinDate != DateTime.MinValue)
            {
                MemberSinceString = string.Format("{0:MMM yyyy}", Model.JoinDate);
            }
        }
    }
}
