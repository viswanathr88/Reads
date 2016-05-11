using System.Collections.Generic;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;

namespace Epiphany.ViewModel
{
    public interface IMyBooksViewModel : IDataViewModel
    {
        IList<IBookItemViewModel> CurrentlyReadingBooks { get; }
        IList<IBookItemViewModel> ReadingChallengeBooks { get; }
        IList<IBookItemViewModel> OwnedBooks { get; }

        bool IsCurrentlyReadingBooksLoading { get; }
        bool IsReadingChallengeBooksLoading { get; }
        bool IsOwnedBooksLoading { get; }
    }
}