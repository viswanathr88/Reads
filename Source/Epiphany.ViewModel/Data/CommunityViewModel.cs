using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using Epiphany.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public sealed class CommunityViewModel : DataViewModel<VoidType>, ICommunityViewModel
    {
        private bool isEmpty;
        private IList<IReviewItemViewModel> items;

        private readonly IUserService userService;
        private readonly IReviewService reviewService;
        private readonly IResourceLoader resourceLoader;

        public CommunityViewModel(IUserService userService, IReviewService reviewService, IResourceLoader resourceLoader)
        {
            if (userService == null)
            {
                throw new ArgumentNullException(nameof(userService));
            }

            if (reviewService == null)
            {
                throw new ArgumentNullException(nameof(reviewService));
            }

            if (resourceLoader == null)
            {
                throw new ArgumentNullException(nameof(resourceLoader));
            }

            this.userService = userService;
            this.reviewService = reviewService;
            this.resourceLoader = resourceLoader;
        }

        public bool IsEmpty
        {
            get
            {
                return this.isEmpty;
            }
            private set
            {
                SetProperty(ref this.isEmpty, value);
            }
        }

        public IList<IReviewItemViewModel> Items
        {
            get
            {
                return this.items;
            }
            private set
            {
                SetProperty(ref this.items, value);
            }
        }

        public override async Task LoadAsync(VoidType parameter)
        {
            IsLoading = true;

            var reviews = await this.reviewService.GetRecentReviewsAsync();
            Items = new LazyObservableCollection<IReviewItemViewModel, ReviewModel>(
            () => reviews,
            (model) => new ReviewItemViewModel(model));

            IsLoading = false;
            IsLoaded = true;
        }
    }
}
