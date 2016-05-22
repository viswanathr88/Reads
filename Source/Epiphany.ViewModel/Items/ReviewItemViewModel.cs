using Epiphany.Model;

namespace Epiphany.ViewModel.Items
{
    public sealed class ReviewItemViewModel : ItemViewModel<ReviewModel>, IReviewItemViewModel
    {
        public ReviewItemViewModel(ReviewModel item) : base(item)
        {
            User = new UserItemViewModel(Item.User);
        }

        public string Body
        {
            get
            {
                return Item.Body;
            }
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
