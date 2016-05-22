using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using System.Collections.Generic;

namespace Epiphany.View.DesignData
{
    public class DesignBookViewModel : DesignBaseViewModel, IBookViewModel
    {
        public DesignBookViewModel()
        {
            Id = 50;
            Title = "Test Title";
            AverageRating = 3.6;
            Description = @"lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsumlorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsumlorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsumlorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum";
            ImageUrl = @"https://upload.wikimedia.org/wikipedia/en/3/33/A_Prisoner_of_Birth_Jeffrey_Archer.jpg";

            Authors = new List<IAuthorItemViewModel>();
            DesignAuthorItemViewModel author = new DesignAuthorItemViewModel()
            {
                Id = 51,
                Name = "Test Author",
                ImageUrl = @"https://d.gr-assets.com/authors/1199698411p7/18541.jpg"
            };

            Authors.Add(author);
            ShowDescription = true;


            SimilarBooks = new List<IBookItemViewModel>();
            SimilarBooks.Add(new DesignBookItemViewModel());
            SimilarBooks.Add(new DesignBookItemViewModel());
            SimilarBooks.Add(new DesignBookItemViewModel());
            SimilarBooks.Add(new DesignBookItemViewModel());

            ShowPopularShelves = true;

            PopularShelves = new List<IShelfInformationViewModel>();
            PopularShelves.Add(new DesignShelfInformationViewModel());
            PopularShelves.Add(new DesignShelfInformationViewModel());
            PopularShelves.Add(new DesignShelfInformationViewModel());
            PopularShelves.Add(new DesignShelfInformationViewModel());

            RatingDistribution = new DesignRatingDistributionViewModel();

            Reviews = new List<IReviewItemViewModel>();
            Reviews.Add(new DesignReviewItemViewModel());
            Reviews.Add(new DesignReviewItemViewModel());
            Reviews.Add(new DesignReviewItemViewModel());
            Reviews.Add(new DesignReviewItemViewModel());
            Reviews.Add(new DesignReviewItemViewModel());

        }
        public IList<IAuthorItemViewModel> Authors
        {
            get;
            set;
        }

        public double AverageRating
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public IList<IReviewItemViewModel> Reviews
        {
            get;
            set;
        }

        public int Id
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }

        public IList<IShelfInformationViewModel> PopularShelves
        {
            get;
            set;
        }

        public IRatingDistributionViewModel RatingDistribution
        {
            get;
            set;
        }

        public bool ShowDescription
        {
            get;
            set;
        }

        public bool ShowPopularShelves
        {
            get;
            set;
        }

        public IList<IBookItemViewModel> SimilarBooks
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }
    }
}
