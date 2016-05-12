using System.Collections.Generic;
using System.Windows.Input;
using Epiphany.Model;
using Epiphany.Model.Collections;
using Epiphany.ViewModel.Items;

namespace Epiphany.ViewModel
{
    public interface IProfileViewModel : IDataViewModel
    {
        bool AreShelvesEmpty { get; }
        bool AreUpdatesEmpty { get; }
        IAsyncCommand<IEnumerable<BookshelfModel>, IAsyncEnumerator<BookshelfModel>> FetchBookshelves { get; }
        IAsyncEnumerator<BookshelfModel> FetchBookshelvesArg { get; }
        IAsyncCommand<ProfileModel, int> FetchProfile { get; }
        ICommand GoHome { get; }
        ProfileModel Model { get; }
        int Id { get; set; }
        string ImageUrl { get; }
        string Name { get; }
        string Username { get; }
        string MemberSinceString { get; }
        string Location { get; }
        int FriendsCount { get; }
        int GroupsCount { get; }
        int ReviewsCount { get; }
        IList<IAuthorItemViewModel> FavoriteAuthors { get; set; }
        IList<IProfileItemViewModel> ProfileItems { get; set; }
        IList<IFeedItemViewModel> RecentUpdates { get; }
        BookshelfModel SelectedShelf { get; set; }
        IList<BookshelfModel> Shelves { get; }
        bool ShelvesLoaded { get; }
    }
}