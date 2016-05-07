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
        int Id { get; set; }
        string ImageUrl { get; }
        ProfileModel Model { get; }
        string Name { get; set; }
        IList<IProfileItemViewModel> ProfileItems { get; set; }
        IList<IFeedItemViewModel> RecentUpdates { get; }
        IProfileItemViewModel SelectedProfileItem { get; set; }
        BookshelfModel SelectedShelf { get; set; }
        IList<BookshelfModel> Shelves { get; }
        bool ShelvesLoaded { get; }
    }
}