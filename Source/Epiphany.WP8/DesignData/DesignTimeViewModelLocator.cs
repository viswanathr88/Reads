using Epiphany.View.DesignData;
using Epiphany.View.Services;
using Epiphany.ViewModel;
using System;

namespace Epiphany.View.Services
{
    sealed class DesignTimeViewModelLocator : IViewModelLocator
    {
        public IHomeViewModel Home
        {
            get { throw new NotImplementedException(); }
        }

        public ILogonViewModel Logon
        {
            get
            {
                return new DesignLogonViewModel();
            }
        }

        public IAboutViewModel About
        {
            get { return null; }
        }

        public IProfileViewModel Profile
        {
            get { return new DesignProfileViewModel(); }
        }

        public IAddBookViewModel AddBook
        {
            get
            {
                return new DesignAddBookViewModel();
            }
        }

        public IBooksViewModel Books
        {
            get { throw new NotImplementedException(); }
        }


        public IFriendsViewModel Friends
        {
            get { return new DesignFriendsViewModel(); }
        }

        public IEventsViewModel Events
        {
            get { return new DesignEventsViewModel(); }
        }

        public ISearchViewModel Search
        {
            get { return new DesignSearchViewModel(); }
        }

        public IAuthorViewModel Author
        {
            get { return new DesignAuthorViewModel(); }
        }

        public void Dispose()
        {

        }


        public IBookshelvesViewModel Bookshelves
        {
            get { return new DesignBookshelvesViewModel(); }
        }


        public ISettingsViewModel Settings
        {
            get { throw new NotImplementedException(); }
        }
    }
}
