
using System.Collections.Generic;
namespace Epiphany.ViewModel.Items
{
    public interface IBookItemViewModel
    {
        int Id { get; }

        string Title { get; }

        string ImageUrl { get; }

        double AverageRating { get; }

        IEnumerable<IAuthorItemViewModel> Authors { get; }
    }
}
