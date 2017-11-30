using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Items;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public sealed class ReviewViewModel : DataViewModel<ReviewParameter>, IReviewViewModel
    {
        private readonly IReviewService reviewService;
        private IBookItemViewModel book;
        private int rating;
        private string reviewText;
        private string reviewTime;
        private ReviewModel review;
        private IUserItemViewModel user;
        private IList<IBookshelfItemViewModel> shelves;
        private string commentText;
        private ICommand postComment;

        public ReviewViewModel(IReviewService reviewService)
        {
            if (reviewService == null)
            {
                throw new ArgumentNullException(nameof(reviewService));
            }

            this.reviewService = reviewService;
        }

        public IBookItemViewModel Book
        {
            get
            {
                return this.book;
            }
            private set
            {
                SetProperty(ref this.book, value);
            }
        }

        public int Rating
        {
            get
            {
                return this.rating;
            }
            private set
            {
                SetProperty(ref this.rating, value);
            }
        }

        public string ReviewText
        {
            get
            {
                return this.reviewText;
            }
            private set
            {
                SetProperty(ref this.reviewText, value);
            }
        }
         
        public string ReviewTime
        {
            get
            {
                return this.reviewTime;
            }
            private set
            {
                SetProperty(ref this.reviewTime, value);
            }
        }

        public IUserItemViewModel User
        {
            get
            {
                return this.user;
            }
            private set
            {
                SetProperty(ref this.user, value);
            }
        }

        public IList<IBookshelfItemViewModel> Shelves
        {
            get
            {
                return this.shelves;
            }
            private set
            {
                SetProperty(ref this.shelves, value);
            }
        }

        public string CommentText
        {
            get
            {
                return this.commentText;
            }

            set
            {
                SetProperty(ref this.commentText, value);
            }
        }

        public ICommand PostComment
        {
            get
            {
                return this.postComment;
            }
        }

        public async override Task LoadAsync(ReviewParameter param)
        {
            IsLoading = true;

            if (param.FeedItemModel == null && param.ReviewModel == null)
            {
                throw new ArgumentNullException(nameof(param));
            }

            long id = param.ReviewModel != null ? param.ReviewModel.Id : param.FeedItemModel.Id;
            this.review = param.ReviewModel;
            UpdateProperties();

            // Fetch the review and update
            this.review = await Task.Run(async() => await this.reviewService.GetReviewAsync(id));
            UpdateProperties();

            IsLoading = false;
            IsLoaded = true;
        }

        private void UpdateProperties()
        {
            if (this.review != null)
            {
                Rating = this.review.Rating;
                ReviewText = this.review.Body?.Trim();
                if (this.review.Book != null)
                {
                    Book = new BookItemViewModel(this.review.Book);
                }
                ReviewTime = this.review.LastUpdatedDate.ToString("MMM dd yyyy");
                User = new UserItemViewModel(this.review.User);
                Shelves = new ObservableCollection<IBookshelfItemViewModel>();

                if (this.review.Shelves != null)
                {
                    foreach (var shelf in this.review.Shelves)
                    {
                        Shelves.Add(new BookshelfItemViewModel(this.review.User, new BookshelfModel(50) { Name = shelf }));
                    }
                }
            }
        }
    }
}
