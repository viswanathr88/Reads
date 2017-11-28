using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;

namespace Epiphany.View.DesignData
{
    sealed class DesignReviewViewModel : DesignBaseViewModel<ReviewParameter>, IReviewViewModel
    {
        public DesignReviewViewModel()
        {
            User = new DesignUserItemViewModel();
            Book = new DesignBookItemViewModel();
            Rating = 3;
            ReviewTime = DateTime.Now.AddDays(-20).AddMonths(-1).ToString("MMM dd yyyy");
            ReviewText = "lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum";
        }

        public IBookItemViewModel Book
        {
            get;
            set;
        }

        public int Rating
        {
            get;
            set;
        }

        public string ReviewText
        {
            get;
            set;
        }

        public string ReviewTime
        {
            get;
            set;
        }

        public IList<IBookshelfItemViewModel> Shelves
        {
            get;
            set;
        }

        public IUserItemViewModel User
        {
            get;
            set;
        }
    }
}
