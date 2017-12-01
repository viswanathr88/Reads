using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Windows.Input;

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
            Shelves = new List<IBookshelfItemViewModel>();
            Shelves.Add(new DesignBookshelfItemViewModel() { Name = "Temp Shelf" });
            Shelves.Add(new DesignBookshelfItemViewModel() { Name = "Temp Shelf 2" });
            Shelves.Add(new DesignBookshelfItemViewModel() { Name = "Temp Shelf 3" });
            Shelves.Add(new DesignBookshelfItemViewModel() { Name = "Temp Shelf 4" });
            Shelves.Add(new DesignBookshelfItemViewModel() { Name = "Temp Shelf 5" });
            Shelves.Add(new DesignBookshelfItemViewModel() { Name = "Temp Shelf 6" });

            CommentText = "lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum";

            IsLoggedIn = true;
        }

        public IBookItemViewModel Book
        {
            get;
            set;
        }

        public string CommentText
        {
            get;
            set;
        }

        public bool IsLoggedIn
        {
            get;
            set;
        }

        public ICommand PostComment
        {
            get
            {
                return null;
            }
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
