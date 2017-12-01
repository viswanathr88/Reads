using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using Epiphany.ViewModel.Services;
using System;
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
            if (Items != null)
            {
                Items.PropertyChanged -= Items_PropertyChanged;
            }

            Items = new LazyObservableCollection<IReviewItemViewModel, ReviewModel>(
                async () => await this.reviewService.GetRecentReviewsAsync(),
                (model) => new ReviewItemViewModel(model));
            Items.PropertyChanged += Items_PropertyChanged;
        }

        private void Items_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Items.IsLoading))
            {
                IsLoading = Items.IsLoading;
                if (!Items.IsLoading)
                {
                    IsLoaded = (Items.Count != 0 || Error != null);
                }

            }
            else if (e.PropertyName == nameof(Items.Error))
            {
                Error = Items.Error;
                IsLoaded = false;
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            if (Items != null)
            {
                Items.PropertyChanged -= Items_PropertyChanged;
            }
        }
    }
}
