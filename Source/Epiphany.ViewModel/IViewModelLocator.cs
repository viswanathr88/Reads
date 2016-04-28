﻿using Epiphany.ViewModel;
using Epiphany.ViewModel.Services;
using System;

namespace Epiphany.View.Services
{
    public interface IViewModelLocator : IDisposable
    {
        HomeViewModel Home { get; }

        LogonViewModel Logon { get; }

        AddBookViewModel AddBook { get; }

        AppResources About { get; }

        ProfileViewModel Profile { get; }

        BooksViewModel Books { get; }

        FriendsViewModel Friends { get; }

        EventsViewModel Events { get; }

        SearchViewModel Search { get; }

        AuthorViewModel Author { get; }

        BookViewModel Book { get; }

        ScanViewModel Scanner { get; }

        //BookshelvesViewModel Bookshelves { get; }

        SettingsViewModel Settings { get; }
    }
}
