using Epiphany.ViewModel;
using Windows.ApplicationModel;

namespace Epiphany.View.Services
{
    public sealed class ViewModelLocator : IViewModelLocator
    {
        private readonly IViewModelLocator locatorImpl;

        public ViewModelLocator()
        {
            if (DesignMode.DesignModeEnabled)
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
            get { return this.locatorImpl.Logon; }
        }

        public IHomeViewModel Home
        {
            get { return this.locatorImpl.Home; }
        }

        public IAboutViewModel About
        {
            get { return this.locatorImpl.About; }
        }

        public IAddBookViewModel AddBook
        {
            get { return this.locatorImpl.AddBook; }
        }

        public IProfileViewModel Profile
        {
            get { return this.locatorImpl.Profile; }
        }

        public IBooksViewModel Books
        {
            get { return this.locatorImpl.Books; }
        }

        public IFriendsViewModel Friends
        {
            get { return this.locatorImpl.Friends; }
        }

        public IEventsViewModel Events
        {
            get { return this.locatorImpl.Events; }
        }

        public ISearchViewModel Search
        {
            get { return this.locatorImpl.Search; }
        }

        public IAuthorViewModel Author
        {
            get { return this.locatorImpl.Author; }
        }


        public ISettingsViewModel Settings
        {
            get { return this.locatorImpl.Settings; }
        }

        public IBookViewModel Book
        {
            get { return this.locatorImpl.Book; }
        }

        public IScanViewModel Scanner
        {
            get { return this.locatorImpl.Scanner; }
        }

        public IBookshelvesViewModel Bookshelves
        {
            get
            {
                return this.locatorImpl.Bookshelves;
            }
        }

        public void Dispose()
        {
            locatorImpl.Dispose();
        }
    }
}
