using Epiphany.ViewModel.Items;
using System.Collections.Generic;

namespace Epiphany.ViewModel
{
    public interface IBookViewModel : IDataViewModel
    {
        IList<IAuthorItemViewModel> Authors { get; }
        IList<IBookItemViewModel> SimilarBooks { get; }
        IList<IShelfInformationViewModel> PopularShelves { get; }
        IRatingDistributionViewModel RatingDistribution { get; }
        IList<IReviewItemViewModel> Reviews { get; }

        double AverageRating { get; }
        int RatingsCount { get; }
        string Description { get; }
        string ImageUrl { get; }
        string Title { get; }
        bool ShowDescription { get; }
        bool ShowPopularShelves { get; }

    }
}