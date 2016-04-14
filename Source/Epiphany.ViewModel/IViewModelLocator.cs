using Epiphany.ViewModel;
using System;

namespace Epiphany.View.Services
{
    public interface IViewModelLocator : IDisposable
    {
        HomeViewModel Home { get; }

        LogonViewModel Logon { get; }

        AddBookViewModel AddBook { get; }

        AboutViewModel About { get; }

        ProfileViewModel Profile { get; }

        BooksViewModel Books { get; }

        FriendsViewModel Friends { get; }

        EventsViewModel Events { get; }

        SearchViewModel Search { get; }

        AuthorViewModel Author { get; }

        BookViewModel Book { get; }

        //BookshelvesViewModel Bookshelves { get; }

        SettingsViewModel Settings { get; }
    }
}
