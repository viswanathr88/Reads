using Epiphany.Model;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using System.Collections.Generic;
using Windows.UI.Xaml;

namespace Epiphany.View.DesignData
{
    public sealed class DesignProfileViewModel : DesignBaseViewModel, IProfileViewModel
    {
        public DesignProfileViewModel()
        {
            IsLoggedIn = true;
            Id = 50;
            Name = "Test User";
            Username = "viswanathr";
            MemberSinceString = "Jan 2010";
            Location = "Chennai, 20, India";
            AreUpdatesEmpty = true;
            IsLoading = false;
            IsLoaded = true;
            FriendsCount = 25;
            GroupsCount = 50;
            ReviewsCount = 75;
            ShelvesCount = 10;
            ImageUrl = "http://www.viscofoods.com/wp-content/themes/456market/assets/img/placeholder.png";

            HasFavoriteAuthors = true;
            FavoriteAuthors = new List<IAuthorItemViewModel>();
            FavoriteAuthors.Add(new DesignAuthorItemViewModel()
            {
                Id = 50,
                Name = "Jeffrey Archer"
            });
            FavoriteAuthors.Add(new DesignAuthorItemViewModel()
            {
                Id = 51,
                Name = "Sidney Sheldon"
            });
            FavoriteAuthors.Add(new DesignAuthorItemViewModel()
            {
                Id = 52,
                Name = "George R. R. Martin"
            });

            RequestPendingVisibility = Visibility.Collapsed;
            ProfileActionsVisibility = Visibility.Visible;
            FollowingUserVisibility = Visibility.Collapsed;
            FollowUserVisibility = Visibility.Visible;
        }
        public long Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public bool AreUpdatesEmpty
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }

        public IList<IFeedItemViewModel> RecentUpdates
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public string MemberSinceString
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }

        public int FriendsCount
        {
            get;
            set;
        }

        public int GroupsCount
        {
            get;
            set;
        }

        public int ReviewsCount
        {
            get;
            set;
        }

        public IList<IAuthorItemViewModel> FavoriteAuthors
        {
            get;
            set;
        }

        public int ShelvesCount
        {
            get;
            set;
        }

        public bool HasFavoriteAuthors
        {
            get;
            set;
        }

        public IAsyncCommand<ProfileModel> SendFriendRequest
        {
            get;
            set;
        }

        public IAsyncCommand<ProfileModel> ToggleFollowReviews
        {
            get;
            set;
        }

        public Visibility ProfileActionsVisibility
        {
            get;
            set;
        }

        public Visibility FollowUserVisibility
        {
            get;
            set;
        }

        public Visibility FollowingUserVisibility
        {
            get;
            set;
        }

        public Visibility RequestPendingVisibility
        {
            get;
            set;
        }

        public bool IsLoggedIn
        {
            get;
            set;
        }
    }
}
