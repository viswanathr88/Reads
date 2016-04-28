using Epiphany.View.Services;
using Epiphany.ViewModel;
using System;

namespace Epiphany.View.DesignData
{
    public sealed class DesignTimeViewModelLocator : IViewModelLocator
    {
        public AboutViewModel About
        {
            get
            {
                return null;
            }
        }

        public AddBookViewModel AddBook
        {
            get
            {
                return null;
            }
        }

        public AuthorViewModel Author
        {
            get
            {
                return null;
            }
        }

        public BookViewModel Book
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public BooksViewModel Books
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public EventsViewModel Events
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public FriendsViewModel Friends
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public HomeViewModel Home
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public LogonViewModel Logon
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ProfileViewModel Profile
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ScanViewModel Scanner
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public SearchViewModel Search
        {
            get
            {
                return null;
            }
        }

        public SettingsViewModel Settings
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
