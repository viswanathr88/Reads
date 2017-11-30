using Epiphany.ViewModel.Collections;
using System;
using System.Collections.ObjectModel;
using Windows.Foundation;
using Windows.UI.Xaml.Data;

namespace Epiphany.View.DesignData
{
    class DesignLazyObservableCollection<T> : ObservableCollection<T>, ILazyObservableCollection<T>
    {
        public void AddItem(T item)
        {
            Add(item);
        }

        public bool HasMoreItems
        {
            get;
            set;
        }

        public event EventHandler<LoadedEventArgs> Loaded;
        public event EventHandler<EventArgs> Loading;

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            throw new NotImplementedException();
        }
    }
}
