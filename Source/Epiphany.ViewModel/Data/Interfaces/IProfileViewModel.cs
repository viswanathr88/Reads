
using Epiphany.Model;
using Epiphany.Model.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace Epiphany.ViewModel
{
    public interface IProfileViewModel : IDataViewModel
    {
        int Id
        {
            get;
        }

        string Name
        {
            get;
        }

        ProfileModel Model
        {
            get;
        }

        bool AreShelvesEmpty
        {
            get;
        }

        bool AreUpdatesEmpty
        {
            get;
        }

        ICommand GoHome
        {
            get;
        }

        IAsyncCommand<ProfileModel, int> FetchProfile
        {
            get;
        }

        IAsyncCommand<IEnumerable<BookshelfModel>, IAsyncEnumerator<BookshelfModel>> FetchBookshelves
        {
            get;
        }

        IAsyncEnumerator<BookshelfModel> FetchBookshelvesArg
        {
            get;
        }

        ObservableCollection<BookshelfModel> Shelves
        {
            get;
        }
    }
}
