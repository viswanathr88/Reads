using Epiphany.ViewModel;
using Epiphany.ViewModel.Services;
using System;

namespace Epiphany.View.Services
{
    public interface IViewModelLocator : IDisposable
    {
        IHomeViewModel Home { get; }

        ILogonViewModel Logon { get; }

        IAddBookViewModel AddBook { get; }

        IAboutViewModel About { get; }

        IProfileViewModel Profile { get; }

        IBooksViewModel Books { get; }

        IFriendsViewModel Friends { get; }

        IEventsViewModel Events { get; }

        ISearchViewModel Search { get; }

        IAuthorViewModel Author { get; }

        IBookViewModel Book { get; }

        IScanViewModel Scanner { get; }

        //BookshelvesViewModel Bookshelves { get; }

        ISettingsViewModel Settings { get; }
    }
}
