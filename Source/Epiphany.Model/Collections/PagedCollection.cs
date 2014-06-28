using Epiphany.Model.Adapter;
using Epiphany.Model.DataSources;
using Epiphany.Xml;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.Model.Collections
{
    internal class PagedCollection<T, TSource, TSourceCollection> : IPagedCollection<T> where TSourceCollection : IPartialCollection<TSource> where T : IEntity
    {
        private readonly IPagedDataSource<TSourceCollection> source;
        private readonly IAdapter<T, TSource> adapter;
        private readonly List<T> items = new List<T>();
        private readonly int pageSize = 20;
        private bool isLoaded;
        private int page = 0;
        private int size = 0;

        public PagedCollection(IPagedDataSource<TSourceCollection> source, IAdapter<T, TSource> adapter, int pageSize)
        {
            if (source == null || adapter == null)
            {
                throw new ArgumentNullException();
            }

            this.source = source;
            this.adapter = adapter;
            this.pageSize = pageSize;
        }

        public PagedCollection(IPagedDataSource<TSourceCollection> source, IAdapter<T, TSource> adapter, IEnumerable<TSource> initialList)
        {
            this.source = source;
            this.adapter = adapter;
            if (initialList != null)
            {
                foreach (TSource item in initialList)
                {
                    this.items.Add(adapter.Convert(item));
                }
                this.page++;
                this.pageSize = this.items.Count;
            }
        }

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }
            private set
            {
                if (this.size == value) return;
                this.size = value;
            }
        }

        public int PageSize
        {
            get
            {
                return this.pageSize;
            }
        }

        public int CurrentPage
        {
            get
            {
                return page;
            }
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new ArgumentOutOfRangeException("index");

                return items[index];
            }
        }

        public async Task<bool> LoadPage()
        {
            //
            // We have loaded all pages. return false
            //
            if (isLoaded)
            {
                return false;
            }

            //
            // Get the next page from data source
            //
            page++;
            TSourceCollection collection = await this.source.GetAsync(page, pageSize);
            if (collection == null)
            {
                isLoaded = true;
                return false;
            }
            //
            // Get the size of the collection
            //
            Size = Converter.ToInt(collection.Total, 0);
            //
            // Add the new items to the internal list
            //
            int count = 0;
            if (collection.Items != null)
            {
                foreach (TSource item in collection.Items)
                {
                    this.Items.Add(this.adapter.Convert(item));
                    count++;
                }
            }

            //
            // If items count is zero, then we have reached the end of the collection,
            // so set isLoaded to true and return false. If count is less than page size,
            // then we have fetched the last page, so set isLoaded to true and return true
            // else we have more items to load, just return true
            //

            bool result = false;
            if (count == 0)
            {
                isLoaded = true;
                result = false;
            }
            else if (count < PageSize)
            {
                isLoaded = true;
                result = true;
            }
            else
            {
                result = true;
            }
            return result;
        }

        public void Clear()
        {
            //
            // Checked if we have already cleared, so that
            // the reset event is not raised again
            //
            if (Items.Count == 0 && page == 0
                && isLoaded == false)
                return;

            items.Clear();
            page = 0;
            isLoaded = false;
            RaiseReset();
        }

        public IAsyncEnumerator<T> GetEnumerator()
        {
            return new PagedCollectionEnumerator<T>(this);
        }

        public event EventHandler<EventArgs> Reset;

        private void RaiseReset()
        {
            if (Reset != null)
            {
                Reset(this, EventArgs.Empty);
            }
        }
    }
}
