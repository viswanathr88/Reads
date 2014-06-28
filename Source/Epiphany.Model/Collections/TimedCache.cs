using System;
using System.Collections;
using System.Collections.Generic;

namespace Epiphany.Model.Collections
{
    public class TimedCache<T1,T2> : IDictionary<T1, T2>
    {
        Dictionary<T1, T2> cache = new Dictionary<T1,T2>();
        Dictionary<T1, DateTime> accessTimes = new Dictionary<T1,DateTime>();
        private int minutes;

        public TimedCache(int minutes)
        {
            this.minutes = minutes;
        }

        public void Add(T1 key, T2 value)
        {
            cache[key] = value;
            accessTimes[key] = DateTime.Now;
        }

        public bool ContainsKey(T1 key)
        {
            if (!cache.ContainsKey(key))
                return false;
            else
            {
                DateTime time = accessTimes[key];
                if ((DateTime.Now - time).TotalMinutes > minutes)
                {
                    Remove(key);
                    return false;
                }
                else
                    return true;
            }
        }

        public ICollection<T1> Keys
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(T1 key)
        {
            accessTimes.Remove(key);
            return cache.Remove(key);
        }

        public bool TryGetValue(T1 key, out T2 value)
        {
            throw new NotImplementedException();
        }

        public ICollection<T2> Values
        {
            get { throw new NotImplementedException(); }
        }

        public T2 this[T1 key]
        {
            get
            {
                return cache[key];
            }
            set
            {
                Add(key, value);
            }
        }

        public void Add(KeyValuePair<T1, T2> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            cache.Clear();
            accessTimes.Clear();
        }

        public bool Contains(KeyValuePair<T1, T2> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<T1, T2>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return cache.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<T1, T2> item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<T1, T2>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
