using Epiphany.Logging;
using Epiphany.Model.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Epiphany.ViewModel.Collections
{
    public sealed class ObservablePagedCollection<TViewModel, TModel> : ObservableCollection<TViewModel>, 
        IGroup<string, TViewModel>, ILazyObservableCollection<TViewModel>, INotifyPropertyChanged
    {
        private readonly IPagedCollection<TModel> pagedCollection;
        private readonly IAsyncEnumerator<TModel> enumerator;
        private readonly Func<TModel, TViewModel> adapterMethod;
        private bool hasMoreItems = true;
        private bool isLoading = false;

        public event EventHandler<EventArgs> Loading;
        private void RaiseLoading() => Loading?.Invoke(this, EventArgs.Empty);

        public event EventHandler<LoadedEventArgs> Loaded;
        private void RaiseLoaded(Exception error) => Loaded?.Invoke(this, new LoadedEventArgs(error));

        public ObservablePagedCollection(IPagedCollection<TModel> pagedCollection,
            Func<TModel, TViewModel> adapterMethod)
        {
            if (pagedCollection == null)
            {
                throw new ArgumentNullException(nameof(pagedCollection));
            }

            this.pagedCollection = pagedCollection;
            this.enumerator = this.pagedCollection.GetEnumerator();
            this.adapterMethod = adapterMethod;
        }

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
                }
            }
        }

        public string Key
        {
            get;
            set;
        }

        public Exception Error
        {
            get;
            private set;
        }

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
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsLoading)));
                }
            }
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            CoreDispatcher dispatcher = Window.Current.Dispatcher;
            Logger.LogDebug($"{GetType()} - Count = {count}");

            RaiseLoading();
            IsLoading = true;

            return Task.Run(async () =>
            {
                bool fMoveNext = false;
                int loadedCount = 0;
                IList<TModel> items = new List<TModel>();

                while (loadedCount < Math.Max(count, pagedCollection.Count - this.Count) && 
                (fMoveNext = await this.enumerator.MoveNext()) == true)
                {
                    items.Add(enumerator.Current);
                    loadedCount++;
                }

                HasMoreItems = (fMoveNext != false);

                await dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    () =>
                    {
                        foreach (TModel model in items)
                        {
                            var item = this.adapterMethod.Invoke(model);
                            if (item != null)
                            {
                                Add(item);
                            }
                        }
                        IsLoading = false;
                        RaiseLoaded(pagedCollection.Error);
                    });

                Logger.LogDebug($"{GetType()} - Loaded Count = {loadedCount}");
                return new LoadMoreItemsResult() { Count = Convert.ToUInt32(loadedCount) };
            }).AsAsyncOperation<LoadMoreItemsResult>();
        }
    }
}
