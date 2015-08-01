using System;
using System.Collections;
using System.Collections.Generic;

namespace Epiphany.ViewModel.Collections
{
    public class DeltaList<T> : IEnumerable<DeltaListItem<T>> where T : IEquatable<T>, IComparable<T>
    {
        private readonly IDictionary<T, int> originalItems;
        private readonly IDictionary<T, DeltaListItem<T>> deltaItems;

        public DeltaList(IEnumerable<T> originalItems)
        {
            if (originalItems == null)
                throw new ArgumentNullException("originalItems", "original items cannot be null");

            this.originalItems = new Dictionary<T, int>();
            this.deltaItems = new Dictionary<T, DeltaListItem<T>>();

            int k = 0;
            foreach (T item in originalItems)
            {
                this.originalItems[item] = k++;
            }
        }

        public IDictionary<T, int> OriginalItems
        {
            get { return this.originalItems; }
        }

        public void Add(T item)
        {
            if (!this.originalItems.ContainsKey(item))
            {
                this.deltaItems[item] = new DeltaListItem<T>(DeltaListOperation.Added, item);
            }
            else
            {
                if (this.deltaItems.ContainsKey(item))
                    this.deltaItems.Remove(item);
            }
        }

        public void Remove(T item)
        {
            if (this.originalItems.ContainsKey(item))
            {
                this.deltaItems[item] = new DeltaListItem<T>(DeltaListOperation.Removed, item);
            }
            else
            {
                if (this.deltaItems.ContainsKey(item))
                    this.deltaItems.Remove(item);
            }
        }

        public int Count
        {
            get { return this.deltaItems.Count; }
        }

        public IEnumerator<DeltaListItem<T>> GetEnumerator()
        {
            return this.deltaItems.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.deltaItems.Values.GetEnumerator();
        }
    }
}
