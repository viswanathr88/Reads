
using Epiphany.Model;
using Epiphany.Model.Collections;
using Epiphany.ViewModel.Items;
using System.Collections.Generic;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public interface IBookshelvesViewModel : IDataViewModel
    {
        int Id { get; set; }

        string Name { get; }

        IList<IBookshelfItemViewModel> Bookshelves { get; }

        IAsyncEnumerator<BookshelfModel> BookshelfEnumerator { get; }

        IBookshelfItemViewModel SelectedBookshelf { get; }

        IAsyncCommand<IEnumerable<BookshelfModel>, IAsyncEnumerator<BookshelfModel>> FetchMyShelves { get; }

        ICommand ShowAddShelf { get; }

        ICommand GoHome { get; }
    }
}
