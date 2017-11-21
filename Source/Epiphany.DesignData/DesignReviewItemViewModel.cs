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
            Book = new DesignBookItemViewModel()
            {
                Id = 50,
                Title = "Test Book",
                ImageUrl = @"https://upload.wikimedia.org/wikipedia/en/3/33/A_Prisoner_of_Birth_Jeffrey_Archer.jpg",
                AverageRating = 4.0,
                MainAuthor = new DesignAuthorItemViewModel()
                {
                    Name = "TestAuthor"
                }
            };
        }

        public string Body
        {
            get;
            set;
        }

        public IBookItemViewModel Book
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
