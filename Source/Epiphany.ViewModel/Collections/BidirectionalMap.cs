using System;
using System.Net;
using System.Collections.Generic;
using System.Collections;

namespace Epiphany.ViewModel.Collections
{
    public class BidirectionalMap<T1,T2>
    {
        private Dictionary<T1, T2> m_ForwardMap;
        private Dictionary<T2, T1> m_ReverseMap;

        public BidirectionalMap()
        {
            m_ForwardMap = new Dictionary<T1, T2>();
            m_ReverseMap = new Dictionary<T2, T1>();
        }

        public void Add(T1 key, T2 value)
        {
            m_ForwardMap.Add(key, value);
            m_ReverseMap.Add(value, key);
        }

        public void Clear()
        {
            m_ForwardMap.Clear();
            m_ReverseMap.Clear();
        }

        public bool Contains(T1 key)
        {
            if (m_ForwardMap.ContainsKey(key))
                return true;
            else
                return false;
        }

        public bool Contains(T2 key)
        {
            if (m_ReverseMap.ContainsKey(key))
                return true;
            else
                return false;
        }

        public bool IsFixedSize
        {
            get { return false; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Remove(T1 key)
        {
            m_ForwardMap.Remove(key);
        }

        public void Remove(T2 key)
        {
            m_ReverseMap.Remove(key);
        }

        public T2 this[T1 key]
        {
            get
            {
                return m_ForwardMap[key];
            }
            set
            {
                m_ForwardMap[key] = value;
            }
        }

        public T1 this[T2 key]
        {
            get
            {
                return m_ReverseMap[key];
            }
            set
            {
                m_ReverseMap[key] = value;
            }
        }

        public int Count
        {
            get { return m_ForwardMap.Count; }
        }

        public List<T1> GetKeys()
        {
            return new List<T1>(this.m_ForwardMap.Keys);
        }

        public List<T2> GetValues()
        {
            return new List<T2>(this.m_ReverseMap.Keys);
        }
    }
}
