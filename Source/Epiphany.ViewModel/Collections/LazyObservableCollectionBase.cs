using Epiphany.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Epiphany.ViewModel.Collections
{
    /// <summary>
    /// Base class for lazy loading a list from a service. The assumption is the view understands
    /// <see cref="ISupportIncrementalLoading"/> and will initiate a load only when the List UI is
    /// in view
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class LazyObservableCollectionBase<T> : ObservableCollection<T>, ILazyObservableCollection<T>
    {
        private Exception error;
        private bool hasMoreItems = true;
        private bool loadCompleted;
        private bool isLoading;
        /// <summary>
        /// Gets the latest error during load
        /// </summary>
        public Exception Error
        {
            get
            {
                return this.error;
            }
            private set
            {
                if (this.error != value)
                {
                    this.error = value;
                    RaisePropertyChanged(nameof(Error));
                }
            }
        }
        /// <summary>
        /// Gets whether the list has more items to load.
        /// </summary>
        public bool HasMoreItems
        {
            get
            {
                return this.hasMoreItems;
            }
            private set
            {
                if (this.hasMoreItems != value)
                {
                    this.hasMoreItems = value;
                    RaisePropertyChanged(nameof(HasMoreItems));
                }
            }
        }
        /// <summary>
        /// Gets whether the list is loading. Can be used by UI directly to indicate progress
        /// </summary>
        public bool IsLoading
        {
            get
            {
                return this.isLoading;
            }
            private set
            {
                if (this.isLoading != value)
                {
                    this.isLoading = value;
                    RaisePropertyChanged(nameof(IsLoading));
                }
            }
        }
        /// <summary>
        /// Callback to load more items async
        /// </summary>
        /// <param name="count">Requested number of items</param>
        /// <returns></returns>
        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            Logger.LogDebug($"{GetType()} - Requesting to load {count} items");
            CoreDispatcher dispatcher = Window.Current.Dispatcher;
            IsLoading = true;
            int loadedCount = 0;

            return Task.Run(async () =>
            {
                Exception err = null;
                IList<T> items = null;
                try
                {
                    items = await LoadItemsAsync(count);
                    loadedCount = items.Count;
                }
                catch (Exception ex)
                {
                    err = ex;
                    Logger.LogException(ex);
                }

                await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        if (items != null)
                        {
                            foreach (var item in items)
                            {
                                if (item != null)
                                {
                                    Add(item);
                                }
                            }
                        }

                        HasMoreItems = !LoadCompleted;
                        IsLoading = false;
                        Error = err;
                    });

                Logger.LogDebug($"{GetType()} - Actually loaded {loadedCount} items");
                return new LoadMoreItemsResult() { Count = Convert.ToUInt32(loadedCount) };

            }).AsAsyncOperation<LoadMoreItemsResult>();
        }
        /// <summary>
        /// Derived classes must set this property to indicate whether more items
        /// need to be loaded
        /// </summary>
        protected bool LoadCompleted
        {
            get
            {
                return this.loadCompleted;
            }
            set
            {
                if (this.loadCompleted != value)
                {
                    this.loadCompleted = value;
                }
            }
        }
        /// <summary>
        /// Abstract method for derived classes to load items
        /// </summary>
        /// <returns></returns>
        protected abstract Task<IList<T>> LoadItemsAsync(uint count);
        /// <summary>
        /// Method for derived methods to raise property changed
        /// </summary>
        /// <param name="propertyName"></param>
        protected void RaisePropertyChanged(string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
