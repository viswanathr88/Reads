using System.Collections.Generic;

namespace Epiphany.ViewModel.Items
{
    public interface IBookItemViewModel : IItemViewModel
    {
        IList<IAuthorItemViewModel> Authors { get; }
        double AverageRating { get; }
        int RatingsCount { get; }
        long Id {get; }
        string ImageUrl { get; }
        IAuthorItemViewModel MainAuthor { get; }
        string Title { get; }
    }
}