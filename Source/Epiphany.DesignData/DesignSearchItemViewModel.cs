using Epiphany.Model;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;

namespace Epiphany.View.DesignData
{
    public sealed class DesignSearchItemViewModel : ISearchResultItemViewModel
    {
        public IBookItemViewModel Book { get; set; }

        public IAuthorItemViewModel Author { get; set; }

        public IAsyncCommand<BookModel> AddToReadingList
        {
            get;
        }

        public double AverageRating
        {
            get;
            set;
        }

        public int RatingsCount
        {
            get;
            set;
        }

        public IAsyncCommand<BookModel> RemoveFromReadingList
        {
            get;
        }

        public bool Reviewed
        {
            get;
            set;
        }
    }
}
