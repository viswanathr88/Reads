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
        private void RaiseLoaded() => Loaded?.Invoke(this, new LoadedEventArgs(null));
        public event EventHandler<EventArgs> Loading;
        private void RaiseLoading() => Loading?.Invoke(this, EventArgs.Empty);


        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            throw new NotImplementedException();
        }
    }
}
