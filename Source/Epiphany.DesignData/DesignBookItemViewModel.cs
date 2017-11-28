using Epiphany.ViewModel.Items;
using System.Collections.Generic;
using System.Linq;

namespace Epiphany.View.DesignData
{
    public sealed class DesignBookItemViewModel : DesignBaseItemViewModel, IBookItemViewModel
    {
        public DesignBookItemViewModel()
        {
            Title = "Test Book";
            ImageUrl = "";
            AverageRating = 3.75;
            RatingsCount = 5000;
            Authors = new List<IAuthorItemViewModel>();
            Authors.Add(new DesignAuthorItemViewModel());
            MainAuthor = Authors.First();
            RatingsCount = 560;
        }

        public long Id { get; set; }

        public string Title { get; set; }

        public double AverageRating { get; set; }

        public string ImageUrl { get; set; }

        public IList<IAuthorItemViewModel> Authors { get; set; }

        public IAuthorItemViewModel MainAuthor { get; set; }

        public int RatingsCount
        {
            get;
            set;
        }
    }
}
