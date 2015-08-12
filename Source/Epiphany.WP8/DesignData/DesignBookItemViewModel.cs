using Epiphany.ViewModel.Items;
using System.Collections.Generic;

namespace Epiphany.View.DesignData
{
    public sealed class DesignBookItemViewModel : IBookItemViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double AverageRating { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<IAuthorItemViewModel> Authors { get; set; }

        public IAuthorItemViewModel MainAuthor { get; set; }
    }
}
