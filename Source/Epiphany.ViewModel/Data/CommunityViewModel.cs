using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using Epiphany.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public sealed class CommunityViewModel : DataViewModel<VoidType>, ICommunityViewModel
    {
        private bool isEmpty;
        private ICommand refreshCommand;
        private ILazyObservableCollection<IReviewItemViewModel> items;

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

            this.refreshCommand = new DelegateCommand(() => CreateCollection());
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

        public ILazyObservableCollection<IReviewItemViewModel> Items
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

        public ICommand Refresh
        {
            get
            {
                return this.refreshCommand;
            }
        }

        public override Task LoadAsync(VoidType parameter)
        {
            CreateCollection();
            return Task.FromResult(0);
        }

        private void CreateCollection()
        {
            Items = new AsyncLazyObservableCollection<IReviewItemViewModel, ReviewModel>(
                async () => await this.reviewService.GetRecentReviewsAsync(),
                (model) => new ReviewItemViewModel(model));
            Items.Loading += (sender, args) => IsLoading = true;
            Items.Loaded += (sender, args) =>
            {
                Error = args.Error;
                IsLoading = false;
                IsLoaded = true;
            };
        }
    }
}
