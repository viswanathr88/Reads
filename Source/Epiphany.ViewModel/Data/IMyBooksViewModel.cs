using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;

namespace Epiphany.ViewModel
{
    public interface IMyBooksViewModel : IDataViewModel
    {
        ILazyObservableCollection<IBookItemViewModel> CurrentlyReadingBooks
        {
            get;
        }
        ILazyObservableCollection<IBookItemViewModel> ReadingChallengeBooks
        {
            get;
        }
        ILazyObservableCollection<IBookItemViewModel> OwnedBooks
        {
            get;
        }
    }
}