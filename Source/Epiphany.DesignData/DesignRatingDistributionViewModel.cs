using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epiphany.View.DesignData
{
    public sealed class DesignRatingDistributionViewModel : ViewModelBase, IRatingDistributionViewModel
    {
        public DesignRatingDistributionViewModel()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            Ratings = new List<IRatingDistributionItemViewModel>()
            {
                new DesignRatingDistributionItemViewModel()
                {
                    Header = "5",
                    Value = random.Next(5000)
                },
                new DesignRatingDistributionItemViewModel()
                {
                    Header = "4",
                    Value = random.Next(5000)
                },
                new DesignRatingDistributionItemViewModel()
                {
                    Header = "3",
                    Value = random.Next(5000)
                },
                new DesignRatingDistributionItemViewModel()
                {
                    Header = "2",
                    Value = random.Next(5000)
                },
                new DesignRatingDistributionItemViewModel()
                {
                    Header = "1",
                    Value = random.Next(5000)
                },
            };

            Total = Ratings.Sum(item => item.Value);
        }


        public IList<IRatingDistributionItemViewModel> Ratings
        {
            get;
            set;
        }

        public int Total
        {
            get;
            set;
        }
    }
}
