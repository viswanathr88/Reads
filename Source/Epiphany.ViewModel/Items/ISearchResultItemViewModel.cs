using Epiphany.Model;

namespace Epiphany.ViewModel.Items
{
    public interface ISearchResultItemViewModel
    {
        IAsyncCommand<BookModel> AddToReadingList { get; }
        IAuthorItemViewModel Author { get; }
        double AverageRating { get; }
        IBookItemViewModel Book { get; }
        int RatingsCount { get; }
        IAsyncCommand<BookModel> RemoveFromReadingList { get; }
        bool Reviewed { get; }
    }
}