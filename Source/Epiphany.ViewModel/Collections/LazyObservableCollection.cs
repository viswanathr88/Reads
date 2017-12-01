using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Collections
{
    /// <summary>
    /// Class for lazy loading a list. The assumption is the view understands
    /// <see cref="ISupportIncrementalLoading"/> and will initiate a load only when the List UI is
    /// in view. Supports both async and sync versions to obtain the list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    sealed class LazyObservableCollection<TViewModel, TModel> : LazyObservableCollectionBase<TViewModel>
    {
        private readonly Func<IEnumerable<TModel>> sourceFn;
        private readonly Func<Task<IEnumerable<TModel>>> sourceAsyncFn;
        private readonly Func<TModel, TViewModel> adapterFn;
        /// <summary>
        /// Create a new instance of <see cref="LazyObservableCollection{TViewModel, TModel}"/>
        /// </summary>
        /// <param name="sourceFn">Synchronous source function to fetch the list of model items</param>
        /// <param name="adapterFn">Adapter method to convert a model item to a viewmodel item</param>
        public LazyObservableCollection(Func<IEnumerable<TModel>> sourceFn, Func<TModel, TViewModel> adapterFn) :
            this(sourceFn, null, adapterFn)
        {
        }
        /// <summary>
        /// Create a new instance of <see cref="LazyObservableCollection{TViewModel, TModel}"/>
        /// </summary>
        /// <param name="sourceAsyncFn">Asynchronous source function to fetch the list of model items</param>
        /// <param name="adapterFn">Adapter method to convert a model item to a viewmodel item</param>
        public LazyObservableCollection(Func<Task<IEnumerable<TModel>>> sourceAsyncFn, Func<TModel, TViewModel> adapterFn) :
            this(null, sourceAsyncFn, adapterFn)
        {
        }
        /// <summary>
        /// Internal constructor
        /// </summary>
        /// <param name="sourceFn"></param>
        /// <param name="sourceAsyncFn"></param>
        /// <param name="adapterFn"></param>
        private LazyObservableCollection(
            Func<IEnumerable<TModel>> sourceFn, 
            Func<Task<IEnumerable<TModel>>> sourceAsyncFn, 
            Func<TModel, TViewModel> adapterFn)
        {
            if (sourceFn == null && sourceAsyncFn == null)
            {
                throw new ArgumentNullException("There is no source function");
            }

            if (adapterFn == null)
            {
                throw new ArgumentNullException(nameof(adapterFn));
            }

            this.sourceFn = sourceFn;
            this.sourceAsyncFn = sourceAsyncFn;
            this.adapterFn = adapterFn;
        }
        /// <summary>
        /// Load more items asynchronously
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        protected override async Task<IList<TViewModel>> LoadItemsAsync(uint count)
        {
            IEnumerable<TModel> items = null;
            if (sourceFn != null)
            {
                items = sourceFn.Invoke();
                await Task.FromResult(0);
            }
            else if (sourceAsyncFn != null)
            {
                items = await sourceAsyncFn();
            }

            LoadCompleted = true;

            IList<TViewModel> itemsVM = new List<TViewModel>();
            if (items != null)
            {
                foreach (var item in items)
                {
                    itemsVM.Add(this.adapterFn(item));
                }
            }

            return itemsVM;
        }
    }
}
