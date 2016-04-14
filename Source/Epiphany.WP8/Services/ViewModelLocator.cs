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
                //this.locatorImpl = new DesignTimeViewModelLocator();
            }
            else
            {
                // Use the RuntimeViewModelLocator
                this.locatorImpl = new RuntimeViewModelLocator();
            }

        }

        public LogonViewModel Logon
        {
            get
            {
                return this.locatorImpl.Logon;
            }
        }

        public HomeViewModel Home
        {
            get
            {
                return this.locatorImpl.Home;
            }
        }

        public AboutViewModel About
        {
            get
            {
                return this.locatorImpl.About;
            }
        }

        public AddBookViewModel AddBook
        {
            get
            {
                return this.locatorImpl.AddBook;
            }
        }

        public ProfileViewModel Profile
        {
            get
            {
                return this.locatorImpl.Profile;
            }
        }

        public BooksViewModel Books
        {
            get
            {
                return this.locatorImpl.Books;
            }
        }

        public FriendsViewModel Friends
        {
            get { return this.locatorImpl.Friends; }
        }

        public EventsViewModel Events
        {
            get { return this.locatorImpl.Events; }
        }

        public SearchViewModel Search
        {
            get { return this.locatorImpl.Search; }
        }


        public AuthorViewModel Author
        {
            get { return this.locatorImpl.Author; }
        }


        public SettingsViewModel Settings
        {
            get { return this.locatorImpl.Settings; }
        }

        public BookViewModel Book
        {
            get { return this.locatorImpl.Book; }
        }

        public void Dispose()
        {
            locatorImpl.Dispose();
        }
    }
}
