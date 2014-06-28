using Epiphany.Model;
using Epiphany.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Epiphany.ViewModel
{
    public interface IAddBookViewModel : INotifyPropertyChanged, IDisposable
    {
        [ViewModelParameter]
        int BookId
        {
            get;
            set;
        }
        [ViewModelParameter]
        string BookTitle
        {
            get;
            set;
        }

        string ShelfName
        {
            get;
            set;
        }

        bool IsReadSelected
        {
            get;
            set;
        }

        bool IsCurrentlyReadingSelected
        {
            get;
            set;
        }

        bool IsToReadSelected
        {
            get;
            set;
        }

        IList<ICustomBookshelfItemViewModel> CustomShelves
        {
            get;
        }

        BookModel Book
        {
            get;
        }

        ICommand<VoidType, BookModel> RemoveBook
        {
            get;
        }

        ICommand<VoidType, string> CreateShelf
        {
            get;
        }
    }
}
