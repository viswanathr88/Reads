using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Items;
using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public sealed class ReviewViewModel : DataViewModel<ReviewParameter>, IReviewViewModel
    {
        private readonly IReviewService reviewService;
        private IBookItemViewModel book;
        private int rating;
        private string reviewText;
        private DateTime reviewTime;
        private ReviewModel review;

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
         
        public DateTime ReviewTime
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
                ReviewText = this.review.Body;
                Book = new BookItemViewModel(this.review.Book);
                ReviewTime = this.review.LastUpdatedDate;
            }
        }
    }
}
