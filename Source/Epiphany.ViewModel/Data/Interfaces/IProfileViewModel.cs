
using Epiphany.Model;
using Epiphany.Model.Collections;
using Epiphany.ViewModel.Items;
using System.Collections.Generic;
using System.Windows.Input;
namespace Epiphany.ViewModel
{
    public interface IProfileViewModel : IDataViewModel
    {
        int Id { get; }

        string Name { get; }

        ProfileModel Model { get; }

        bool AreShelvesEmpty { get; }

        bool AreUpdatesEmpty { get; }

        bool ShelvesLoaded { get; }

        string ImageUrl { get; }

        BookshelfModel SelectedShelf { get; }

        IList<ProfileItemViewModel> ProfileItems { get; }

        ProfileItemViewModel SelectedProfileItem { get; set; }

        IList<BookshelfModel> Shelves { get; }

        IList<IFeedItemViewModel> RecentUpdates { get; }

        ICommand GoHome { get; }

        IAsyncCommand<ProfileModel, int> FetchProfile { get; }

        IAsyncCommand<IEnumerable<BookshelfModel>, IAsyncEnumerator<BookshelfModel>> FetchBookshelves { get; }

        IAsyncEnumerator<BookshelfModel> FetchBookshelvesArg { get; }
    }
}
