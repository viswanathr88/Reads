using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Epiphany.ViewModel
{
    sealed class RatingDistributionViewModel : ViewModelBase, IRatingDistributionViewModel
    {
        private int total;
        private IList<IRatingDistributionItemViewModel> ratings;

        public RatingDistributionViewModel(string distribution)
        {
            if (string.IsNullOrEmpty(distribution))
            {
                throw new ArgumentNullException(nameof(distribution));
            }

            Ratings = new ObservableCollection<IRatingDistributionItemViewModel>();

            string[] items = distribution.Split('|');

            foreach (var item in items)
            {
                string[] rating = item.Split(':');

                if (rating.Length < 2)
                {
                    // String is not in the expected format
                    continue;
                }

                if (string.Compare(rating[0], "total", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    Total = int.Parse(rating[1]);
                }
                else
                {
                    var ratingItem = new RatingDistributionItemViewModel(rating[0], int.Parse(rating[1]));
                    Ratings.Add(ratingItem);
                }
            }

        }

        public IList<IRatingDistributionItemViewModel> Ratings
        {
            get
            {
                return this.ratings;
            }
            private set
            {
                SetProperty(ref this.ratings, value);
            }
        }

        public int Total
        {
            get
            {
                return this.total;
            }
            private set
            {
                SetProperty(ref this.total, value);
            }
        }
    }
}
