using System;
using System.Collections.Generic;

namespace Epiphany.ViewModel.Collections
{
    class SortedList<T> : ICollection<T>
    {
        private readonly List<T> list;
        private readonly IComparer<T> comparer;

        public SortedList(IComparer<T> comparer)
        {
            this.list = new List<T>();
            this.comparer = comparer;
        }

        public void Add(T item)
        {
            int index = list.BinarySearch(item);
            if (index < 0)
                index = -(index + 1);
            list.Insert(index, item);
        }

        public void Clear()
        {
            this.list.Clear();
        }

        public bool Contains(T item)
        {
            return (this.list.BinarySearch(item) >= 0);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.list.Count; }
        }

        public int IndexOf(T item)
        {
            int index = this.list.BinarySearch(item);
            if (index < 0)
                return -1;
            else
            {
                while (index > 0 && (this.comparer.Compare(this.list[index - 1], item) == 0))
                {
                    index--;
                }
                return index;
            }
        }

        public T this[int index]
        {
            get
            {
                return this.list[index];
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            int index = this.list.BinarySearch(item);
            if (index >= 0)
            {
                this.list.RemoveAt(index);
                return true;
            }
            else
                return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }
    }
}
