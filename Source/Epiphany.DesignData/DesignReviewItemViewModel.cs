using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using System;

namespace Epiphany.View.DesignData
{
    public sealed class DesignReviewItemViewModel : DesignBaseItemViewModel, IReviewItemViewModel
    {
        private Random random = new Random(Guid.NewGuid().GetHashCode());
        public DesignReviewItemViewModel()
        {
            Body = "lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum";
            Rating = random.Next(5);
            User = new DesignUserItemViewModel()
            {
                Name = $"Test User {random.Next(200)}"
            };
        }

        public string Body
        {
            get;
            set;
        }

        public int Rating
        {
            get;
            set;
        }

        public IUserItemViewModel User
        {
            get;
            set;
        }
    }
}
