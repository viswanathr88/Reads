using Epiphany.Model;
using Epiphany.ViewModel.Items;
using System.Collections.Generic;
using Windows.UI.Xaml;

namespace Epiphany.ViewModel
{
    public interface IProfileViewModel : IDataViewModel
    {
        int Id { get; }
        string ImageUrl { get; }
        string Name { get; }
        string Username { get; }
        string MemberSinceString { get; }
        string Location { get; }
        int FriendsCount { get; }
        int GroupsCount { get; }
        int ReviewsCount { get; }
        int ShelvesCount { get; }
        bool AreUpdatesEmpty { get; }
        bool HasFavoriteAuthors { get; }
        Visibility ProfileActionsVisibility { get; }
        Visibility FollowUserVisibility { get; }
        Visibility FollowingUserVisibility { get; }
        Visibility RequestPendingVisibility { get; }

        IList<IAuthorItemViewModel> FavoriteAuthors { get; set; }
        IList<IFeedItemViewModel> RecentUpdates { get; }
        IAsyncCommand<ProfileModel> SendFriendRequest { get; }
        IAsyncCommand<ProfileModel> ToggleFollowReviews { get; }
    }
}