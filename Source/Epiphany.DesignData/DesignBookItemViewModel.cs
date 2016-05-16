using Epiphany.ViewModel.Items;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Epiphany.View.DesignData
{
    public sealed class DesignBookItemViewModel : IBookItemViewModel
    {
        public DesignBookItemViewModel()
        {
            Title = "Test Book";
            AverageRating = 3.75;
            Authors = new List<IAuthorItemViewModel>();
            Authors.Add(new DesignAuthorItemViewModel());
            MainAuthor = Authors.First();
            RatingsCount = 560;
        }

        public int Id { get; set; }

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
