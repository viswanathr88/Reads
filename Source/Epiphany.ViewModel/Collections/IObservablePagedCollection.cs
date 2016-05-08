using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Data;

namespace Epiphany.ViewModel.Collections
{
    public interface IObservablePagedCollection<T> : IList<T>,  ISupportIncrementalLoading
    {
        event EventHandler<EventArgs> Loading;

        event EventHandler<EventArgs> Loaded;
    }
}
