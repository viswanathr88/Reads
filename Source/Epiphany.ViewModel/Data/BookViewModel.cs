using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI;

namespace Epiphany.ViewModel
{
    public sealed class BookViewModel : DataViewModel<BookModel>, IBookViewModel
    {
        private double averageRating;
        private string description;
        private string title;
        private string imageUrl;
        private BookModel model;
        private ObservableCollection<IAuthorItemViewModel> authors;
        private IList<IBookItemViewModel> similarBooks;
        private IList<IShelfInformationViewModel> popularShelves;
        private IList<IReviewItemViewModel> reviews;
        private IRatingDistributionViewModel ratingDistribution;

        private readonly IBookService bookService;
        private readonly IReviewService reviewService;

        public BookViewModel(IBookService bookService, IReviewService reviewService)
        {
            if (bookService == null)
            {
                throw new ArgumentNullException(nameof(bookService));
            }

            if (reviewService == null)
            {
                throw new ArgumentNullException(nameof(reviewService));
            }

            this.bookService = bookService;
            this.reviewService = reviewService;
        }

        public IList<IAuthorItemViewModel> Authors
        {
            get
            {
                return authors;
            }
            private set
            {
                SetProperty(ref this.authors, value as ObservableCollection<IAuthorItemViewModel>);
            }
        }

        public double AverageRating
        {
            get
            {
                return this.averageRating;
            }
            private set
            {
                SetProperty(ref this.averageRating, value);
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            private set
            {
                SetProperty(ref this.description, value);
                RaisePropertyChanged(nameof(ShowDescription));
            }
        }

        public string ImageUrl
        {
            get
            {
                return this.imageUrl;
            }
            private set
            {
                SetProperty(ref this.imageUrl, value);
            }
        }

        public IList<IBookItemViewModel> SimilarBooks
        {
            get
            {
                return this.similarBooks;
            }
            private set
            {
                SetProperty(ref this.similarBooks, value);
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            private set
            {
                SetProperty(ref this.title, value);
            }
        }

        public BookModel Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                SetProperty(ref this.model, value);
            }
        }

        public bool ShowDescription
        {
            get
            {
                return !string.IsNullOrEmpty(Description);
            }
        }

        public IList<IShelfInformationViewModel> PopularShelves
        {
            get
            {
                return this.popularShelves;
            }
            private set
            {
                if (SetProperty(ref this.popularShelves, value))
                {
                    RaisePropertyChanged(nameof(ShowPopularShelves));
                }
            }
        }

        public IRatingDistributionViewModel RatingDistribution
        {
            get
            {
                return this.ratingDistribution;
            }
            private set
            {
                SetProperty(ref this.ratingDistribution, value);
            }
        }

        public bool ShowPopularShelves
        {
            get
            {
                return PopularShelves != null && PopularShelves.Count > 0;
            }
        }

        public IList<IReviewItemViewModel> Reviews
        {
            get
            {
                return this.reviews;
            }
            private set
            {
                SetProperty(ref this.reviews, value);
            }
        }

        public async override Task LoadAsync(BookModel parameter)
        {
            IsLoading = true;

            Title = parameter.Title;
            ImageUrl = parameter.ImageUrl;
            Authors = new ObservableCollection<IAuthorItemViewModel>();
            Authors.Add(new AuthorItemViewModel(parameter.Authors.First()));
            AverageRating = parameter.AverageRating;
            Description = parameter.Description;

            Model = await Task.Run(() => this.bookService.GetBook(parameter.Id));

            AverageRating = Math.Round(Model.AverageRating, 1, MidpointRounding.AwayFromZero);
            Description = Model.Description;
            SimilarBooks = new LazyObservableCollection<IBookItemViewModel, BookModel>(
                () => Model.SimilarBooks,
                (model) => new BookItemViewModel(model));
            PopularShelves = new ObservableCollection<IShelfInformationViewModel>();
            Random random = new Random(Guid.NewGuid().GetHashCode());
            foreach (var shelf in Model.PopularShelves)
            {
                PopularShelves.Add(new ShelfInformationViewModel(shelf)
                {
                    Color = Color.FromArgb(255, (byte)random.Next(255), (byte)random.Next(255), (byte)random.Next(255))
                });
            }
            RaisePropertyChanged(nameof(ShowPopularShelves));

            if (!string.IsNullOrEmpty(Model.RatingDistribution))
            {
                RatingDistribution = new RatingDistributionViewModel(Model.RatingDistribution);
            }

            var reviews = new ObservablePagedCollection<IReviewItemViewModel, ReviewModel>(
                this.reviewService.GetReviews(Model),
                model => new ReviewItemViewModel(model));
            reviews.Loading += (sender, arg) => IsLoading = true;
            reviews.Loaded += (sender, arg) => IsLoading = false;

            if (Model.FriendReviews != null)
            {
                foreach (var review in Model.FriendReviews)
                {
                    if (review.Rating > 0)
                    {
                        reviews.Add(new ReviewItemViewModel(review));
                    }
                }
            }

            Reviews = reviews;


            IsLoading = false;
            IsLoaded = true;
        }

        protected override void Reset()
        {
            base.Reset();

            Title = string.Empty;
            ImageUrl = string.Empty;
            Authors = new ObservableCollection<IAuthorItemViewModel>();
            AverageRating = -1;
            Description = string.Empty;
            Model = null;
            SimilarBooks = null;
            PopularShelves = null;
            RatingDistribution = null;
            Reviews = null;
        }
    }
}
