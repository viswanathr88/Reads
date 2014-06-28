using System;
using System.Threading.Tasks;

namespace Epiphany.Model.Collections
{
    internal class PagedCollectionEnumerator<T> : IAsyncEnumerator<T> where T : IEntity
    {
        private readonly IPagedCollection<T> collection;
        private int currentIndex = -1;

        public PagedCollectionEnumerator(IPagedCollection<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection", "collection cannot be null");

            this.collection = collection;
        }

        public T Current
        {
            get
            {
                return collection[currentIndex];
            }
        }

        public async Task<bool> MoveNext()
        {
            currentIndex++;

            if (currentIndex < collection.Count)
                return true;
            else
            {
                return await collection.LoadPage();
            }
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
