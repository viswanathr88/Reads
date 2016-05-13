using Epiphany.ViewModel.Items;
using System.Collections.Generic;

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
        IList<IAuthorItemViewModel> FavoriteAuthors { get; set; }
        IList<IFeedItemViewModel> RecentUpdates { get; }
    }
}