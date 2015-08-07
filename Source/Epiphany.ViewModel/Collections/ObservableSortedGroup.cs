using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Epiphany.ViewModel.Collections
{
    public sealed class ObservableSortedGroup<T> : IGroup<string, T>, INotifyCollectionChanged, IDisposable
    {
        private List<T> list = new List<T>();
        private string key;

        public ObservableSortedGroup(string key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public ObservableSortedGroup(string key)
        {
            Key = key;
        }

        public string Key
        {
            get { return this.key; }
            private set
            {
                if (this.key == value) return;
                this.key = value;
            }
        }

        public void Insert(int index, T item)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        public int IndexOf(T item)
        {
            int index = this.list.BinarySearch(item);
            if (index < 0)
            {
                return -1;
            }

            return index;
        }

        public T this[int index]
        {
            get
            {
                return this.list[index];
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public void Add(T item)
        {
            int index = this.list.BinarySearch(item);
            if (index < 0)
            {
                index = -(index + 1);
            }

            InsertInternal(index, item);
        }

        public void Clear()
        {
            this.list.Clear();

            NotifyCollectionChangedEventArgs args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
            RaiseCollectionChanged(args);
        }

        public bool Contains(T item)
        {
            return this.list.BinarySearch(item) >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return this.list.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            int index = this.list.BinarySearch(item);
            if (index < 0)
            {
                return false;
            }
            else
            {
                RemoveAtInternal(index);
                return true;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public void Dispose()
        {

        }

        private void RaiseCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (this.CollectionChanged != null)
            {
                this.CollectionChanged(this, e);
            }
        }

        private void InsertInternal(int index, T item)
        {
            this.list.Insert(index, item);

            NotifyCollectionChangedEventArgs args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index);
            RaiseCollectionChanged(args);
        }

        private void RemoveAtInternal(int index)
        {
            T item = this.list[index];
            this.list.RemoveAt(index);

            NotifyCollectionChangedEventArgs args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index);
            RaiseCollectionChanged(args);
        }
    }
}
