using Epiphany.ViewModel.Collections;
using System;
using System.Collections.ObjectModel;
using Windows.Foundation;
using Windows.UI.Xaml.Data;

namespace Epiphany.View.DesignData
{
    class DesignLazyObservableCollection<T> : ObservableCollection<T>, ILazyObservableCollection<T>
    {
        public bool HasMoreItems
        {
            get;
            set;
        }

        public bool IsLoading
        {
            get;
            set;
        }

        public Exception Error
        {
            get;
            set;
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            throw new NotImplementedException();
        }
    }
}
