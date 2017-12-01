using Epiphany.Logging;
using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using Epiphany.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public sealed class AuthorViewModel : DataViewModel<AuthorModel>, IAuthorViewModel
    {
        private readonly AuthorAttributeViewModelFactory authorAttributeVMFactory;
        private string imageUrl;
        private string name;
        private string description;
        private int followersCount;
        private double averageRating;
        private int ratingsCount;
        private string hometown;

        // collections
        private ILazyObservableCollection<IBookItemViewModel> books;
        private IList<IAuthorAttributeViewModel> attributes;

        private readonly IAuthorService authorService;
        private readonly IBookService bookService;
        private readonly INavigationService navService;

        public AuthorViewModel(IAuthorService authorService, IBookService bookService, INavigationService navService)
        {
            if (authorService == null || bookService == null || navService == null)
            {
                throw new ArgumentNullException("services");
            }

            this.bookService = bookService;
            this.navService = navService;
            this.authorService = authorService;

            this.authorAttributeVMFactory = new AuthorAttributeViewModelFactory();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                SetProperty(ref this.name, value);
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

        public ILazyObservableCollection<IBookItemViewModel> Books
        {
            get
            {
                return this.books;
            }
            private set
            {
                SetProperty(ref this.books, value);
            }
        }

        public IList<IAuthorAttributeViewModel> Attributes
        {
            get
            {
                return this.attributes;
            }
            private set
            {
                SetProperty(ref this.attributes, value);
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
            }

        }

        public int FollowersCount
        {
            get
            {
                return this.followersCount;
            }
            private set
            {
                SetProperty(ref this.followersCount, value);
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

        public int RatingsCount
        {
            get
            {
                return this.ratingsCount;
            }
            private set
            {
                SetProperty(ref this.ratingsCount, value);
            }
        }

        public string Hometown
        {
            get
            {
                return this.hometown;
            }
            private set
            {
                SetProperty(ref this.hometown, value);
            }
        }

        public override async Task LoadAsync(AuthorModel author)
        {
            IsLoading = true;

            // Set available properties
            UpdateProperties(author);

            try
            {
                Parameter = await this.authorService.GetAuthorAsync(author.Id);
                Attributes = this.authorAttributeVMFactory.GetAuthorAttributeItems(Parameter);
                UpdateProperties(Parameter);
                Books = new LazyObservablePagedCollection<IBookItemViewModel, BookModel>(
                    this.bookService.GetBooks(Parameter), (model) => new BookItemViewModel(model));
                Books.PropertyChanged += Books_PropertyChanged;
                IsLoaded = true;
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void Books_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Books.IsLoading))
            {
                if (!Books.IsLoading)
                {
                    IsLoaded = (Books.Count != 0 || Error != null);
                }
            }
            else if (e.PropertyName == nameof(Books.Error))
            {
                Error = Books.Error;
                IsLoaded = false;
            }
        }

        private void UpdateProperties(AuthorModel author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            Name = author.Name;
            ImageUrl = author.ImageUrl;

            // Extract description
            StringBuilder builder = new StringBuilder();
            builder.AppendWithoutTags(author.About);
            Description = builder.ToString();

            FollowersCount = (author.FansCount != 0) ? author.FansCount : FollowersCount;
            Hometown = (!string.IsNullOrEmpty(author.Hometown)) ? author.Hometown : Hometown;
            AverageRating = (author.AverageRating != 0) ? author.AverageRating : AverageRating;
            RatingsCount = (author.RatingsCount != 0) ? author.RatingsCount : RatingsCount;
        }

        public override void Dispose()
        {
            base.Dispose();

            if (Books != null)
            {
                Books.PropertyChanged -= Books_PropertyChanged;
            }
        }
    }
}
