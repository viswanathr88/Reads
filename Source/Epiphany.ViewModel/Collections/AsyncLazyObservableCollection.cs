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
    sealed class AsyncLazyObservableCollection<TViewModel, TModel> : ObservableCollection<TViewModel>, ILazyObservableCollection<TViewModel>
    {
        private readonly Func<Task<IEnumerable<TModel>>> asyncFnDelegate;
        private readonly Func<TModel, TViewModel> adapterMethod;
        private bool hasMoreItems = true;

        public AsyncLazyObservableCollection(Func<Task<IEnumerable<TModel>>> asyncFnDelegate,
            Func<TModel, TViewModel> adapterFn)
        {
            if (asyncFnDelegate == null)
            {
                throw new ArgumentNullException(nameof(asyncFnDelegate));
            }

            if (adapterFn == null)
            {
                throw new ArgumentNullException(nameof(adapterFn));
            }

            this.asyncFnDelegate = asyncFnDelegate;
            this.adapterMethod = adapterFn;
        }

        public bool HasMoreItems
        {
            get
            {
                return this.hasMoreItems;
            }
            private set
            {
                this.hasMoreItems = value;
            }
        }

        public event EventHandler<LoadedEventArgs> Loaded;
        private void RaiseLoaded(Exception error) => Loaded?.Invoke(this, new LoadedEventArgs(error));

        public event EventHandler<EventArgs> Loading;
        private void RaiseLoading() => Loading?.Invoke(this, EventArgs.Empty);


        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            CoreDispatcher dispatcher = Window.Current.Dispatcher;

            RaiseLoading();

            return Task.Run(async () =>
            {
                IEnumerable<TModel> collectionSource = await this.asyncFnDelegate.Invoke();
                HasMoreItems = false;
                int loadedCount = 0;

                await dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    () =>
                    {
                        foreach (TModel model in collectionSource)
                        {
                            var item = adapterMethod(model);
                            if (item != null)
                            {
                                Add(item);
                                loadedCount++;
                            }
                        }

                        RaiseLoaded(null);
                    });

                return new LoadMoreItemsResult() { Count = Convert.ToUInt32(loadedCount) };

            }).AsAsyncOperation<LoadMoreItemsResult>();
            
        }
    }
}
