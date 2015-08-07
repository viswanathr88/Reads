using Epiphany.ViewModel.Services;
using System;
using System.Collections.Generic;

namespace Epiphany.ViewModel.Collections
{
    public class AlphabetKeyedList<T> : IEnumerable<KeyedList<string, T>>
    {
        private readonly IResourceLoader resourceLoader;
        private readonly Func<T, string> keySelector;
        private readonly IList<KeyedList<string, T>> groups;
        const string globeGroupKey = "\uD83C\uDF10";

        public AlphabetKeyedList(Func<T, string> keySelector, IResourceLoader resourceLoader)
        {
            this.resourceLoader = resourceLoader;
            this.keySelector = keySelector;
            groups = CreateDefaultGroups(resourceLoader);
        }

        public AlphabetKeyedList(IEnumerable<T> items, Func<T, string> keySelector, IResourceLoader resourceLoader)
        {
            this.resourceLoader = resourceLoader;
            this.keySelector = keySelector;
            groups = CreateDefaultGroups(resourceLoader);

            foreach (T item in items)
            {
                Add(item);
            }
        }

        public IEnumerator<KeyedList<string, T>> GetEnumerator()
        {
            return this.groups.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.groups.GetEnumerator();
        }

        public void Add(T item)
        {
            int index = this.resourceLoader.GetLocaleGroupIndex(keySelector(item));
            if (index >= 0 && index < groups.Count)
                groups[index].Add(item);
        }

        private IList<KeyedList<string, T>> CreateDefaultGroups(IResourceLoader resourceLoader)
        {
            List<KeyedList<string, T>> groups = new List<KeyedList<string, T>>();
            IEnumerable<string> groupHeaders = resourceLoader.GetLocaleGroupHeaders();

            foreach (string key in groupHeaders)
            {
                if (key == "...")
                    groups.Add(new KeyedList<string, T>(globeGroupKey));
                else
                    groups.Add(new KeyedList<string, T>(key));
            }

            return groups;
        }
    }
}
