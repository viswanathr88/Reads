using System.Collections.Generic;
using System.Windows.Input;
using Epiphany.Model;
using Epiphany.Model.Collections;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Items;

namespace Epiphany.ViewModel
{
    public interface IAuthorViewModel : IDataViewModel
    {
        IList<IAuthorAttributeViewModel> Attributes { get; }
        AuthorModel Author { get; }
        IAsyncEnumerator<BookModel> BookEnumerator { get; }
        bool BookLoadingStarted { get; }
        IList<IBookItemViewModel> Books { get; }
        IAsyncCommand<IAsyncEnumerator<BookModel>> FetchBooks { get; }
        ICommand GoHome { get; }
        int Id { get; set; }
        string ImageUrl { get; }
        string Name { get; set; }
        ICommand<AuthorModel> PinAuthor { get; }
        IBookItemViewModel SelectedBook { get; set; }
    }
}