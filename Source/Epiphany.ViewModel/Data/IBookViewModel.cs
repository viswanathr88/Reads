using System.Collections.Generic;

namespace Epiphany.ViewModel
{
    public interface IBookViewModel : IDataViewModel
    {
        IList<IAuthorViewModel> Authors { get; }
        double AverageRating { get; }
        string Description { get; }
        int Id { get; set; }
        string ImageUrl { get; }
        string Name { get; set; }
    }
}