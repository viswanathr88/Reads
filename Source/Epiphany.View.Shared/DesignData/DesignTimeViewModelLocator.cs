using Epiphany.View.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epiphany.ViewModel;

namespace Epiphany.View.DesignData
{
    public sealed class DesignTimeViewModelLocator : IViewModelLocator
    {
        public AboutViewModel About
        {
            get
            {
                return new AboutViewModel();
            }
        }

        public AddBookViewModel AddBook
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public AuthorViewModel Author
        {
            get
            {
                throw new NotImplementedException();
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
                var vm = new LogonViewModel();
                vm.SetValue(nameof(LogonViewModel.IsLoginCompleted), true);
                return vm;
            }
        }

        public ProfileViewModel Profile
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
                throw new NotImplementedException();
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
