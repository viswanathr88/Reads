using System;
using Epiphany.Model;

namespace Epiphany.ViewModel.Items
{
    public sealed class ReviewItemViewModel : ItemViewModel<ReviewModel>, IReviewItemViewModel
    {
        public ReviewItemViewModel(ReviewModel item) : base(item)
        {
            User = new UserItemViewModel(Item.User);

            if (Item.Book != null)
            {
                Book = new BookItemViewModel(Item.Book);
            }
        }

        public string Body
        {
            get
            {
                return Item.Body;
            }
        }

        public IBookItemViewModel Book
        {
            get;
            private set;
        }

        public int Rating
        {
            get
            {
                return Item.Rating;
            }
        }

        public IUserItemViewModel User
        {
            get;
            set;
        }
    }
}
