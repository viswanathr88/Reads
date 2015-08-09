
using Epiphany.Model;
using Epiphany.Model.Collections;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Items;
using System.Collections.Generic;
using System.Windows.Input;
namespace Epiphany.ViewModel
{
    public interface IAuthorViewModel : IDataViewModel
    {
        int Id { get; set; }

        string Name { get; set; }

        bool BookLoadingStarted { get; }

        AuthorModel Author { get; }

        string ImageUrl { get; }

        IBookItemViewModel SelectedBook { get; set; }

        IList<IBookItemViewModel> Books { get; }

        IList<IAuthorAttributeViewModel> Attributes { get; }

        IAsyncCommand<IAsyncEnumerator<BookModel>> FetchBooks { get; }

        IAsyncEnumerator<BookModel> BookEnumerator { get; }

        ICommand<AuthorModel> PinAuthor { get; }

        ICommand GoHome { get; }
    }
}
