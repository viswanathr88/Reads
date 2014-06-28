using Epiphany.Model;
using System;
using System.ComponentModel;

namespace Epiphany.ViewModel
{
    public interface ICustomBookshelfItemViewModel : INotifyPropertyChanged, IDisposable
    {
        bool IsEnabled
        {
            get;
            set;
        }

        BookshelfModel Bookshelf
        {
            get;
        }
    }
}
