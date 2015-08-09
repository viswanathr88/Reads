using Epiphany.ViewModel;

namespace Epiphany.View.Services
{
    public sealed class ViewModelLocator : IViewModelLocator
    {
        private readonly IViewModelLocator locatorImpl;

        public ViewModelLocator()
        {
            if (System.ComponentModel.DesignerProperties.IsInDesignTool)
            {
                // Use the DesignViewModelLocator for blendability
                this.locatorImpl = new DesignTimeViewModelLocator();
            }
            else
            {
                // Use the RuntimeViewModelLocator
                this.locatorImpl = new RuntimeViewModelLocator();
            }

        }

        public ILogonViewModel Logon
        {
            get
            {
                return this.locatorImpl.Logon;
            }
        }

        public IHomeViewModel Home
        {
            get
            {
                return this.locatorImpl.Home;
            }
        }

        public IAboutViewModel About
        {
            get
            {
                return this.locatorImpl.About;
            }
        }

        public IAddBookViewModel AddBook
        {
            get
            {
                return this.locatorImpl.AddBook;
            }
        }

        public IProfileViewModel Profile
        {
            get
            {
                return this.locatorImpl.Profile;
            }
        }

        public IBooksViewModel Books
        {
            get
            {
                return this.locatorImpl.Books;
            }
        }

        public IFriendsViewModel Friends
        {
            get { return this.locatorImpl.Friends; }
        }

        public IEventsViewModel Events
        {
            get { return this.locatorImpl.Events; }
        }

        public void Dispose()
        {
            locatorImpl.Dispose();
        }


        public ISearchViewModel Search
        {
            get { return this.locatorImpl.Search; }
        }


        public IAuthorViewModel Author
        {
            get { return this.locatorImpl.Author; }
        }


        public IBookshelvesViewModel Bookshelves
        {
            get { return this.locatorImpl.Bookshelves; }
        }


        public ISettingsViewModel Settings
        {
            get { return this.locatorImpl.Settings; }
        }
    }
}
