using Epiphany.Model;
using System.Linq;

namespace Epiphany.ViewModel.Items
{
    public sealed class SearchResultItemViewModel : ItemViewModel<WorkModel>
    {
        private BookItemViewModel book;
        private AuthorItemViewModel author;

        public SearchResultItemViewModel(WorkModel work)
            : base(work)
        {
            Book = new BookItemViewModel(work.Book);
            Author = new AuthorItemViewModel(work.Book.Authors.FirstOrDefault());
        }

        public BookItemViewModel Book
        {
            get { return this.book; }
            private set
            {
                if (this.book == value) return;
                this.book = value;
                RaisePropertyChanged();
            }
        }

        public AuthorItemViewModel Author
        {
            get { return this.author; }
            private set
            {
                if (this.author == value) return;
                this.author = value;
                RaisePropertyChanged();
            }
        }

        public double AverageRating
        {
            get
            {
                return Item.AverageRating;
            }
        }

        public int RatingsCount
        {
            get
            {
                return Item.RatingsCount;
            }
        }

        public bool Reviewed
        {
            get
            {
                return (Item.Book != null && Item.Book.UserReview != null);
            }
        }
    }
}
