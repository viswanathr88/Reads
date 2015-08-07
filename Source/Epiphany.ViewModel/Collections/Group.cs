using System.Collections.Generic;

namespace Epiphany.ViewModel.Collections
{
    public class Group<T> : List<T>, IGroup<string, T>
    {
        public Group(string key, IEnumerable<T> items)
            : base(items)
        {
            this.Key = key;
        }

        public Group(string key)
        {
            Key = key;
        }

        public string Key
        {
            get;
            set;
        }
    }
}
