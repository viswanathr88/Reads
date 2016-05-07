using System.Collections.Generic;

namespace Epiphany.ViewModel.Items
{
    public interface IBookItemViewModel
    {
        IEnumerable<IAuthorItemViewModel> Authors { get; }
        double AverageRating { get; }
        int Id { get; }
        string ImageUrl { get; }
        IAuthorItemViewModel MainAuthor { get; }
        string Title { get; }
    }
}