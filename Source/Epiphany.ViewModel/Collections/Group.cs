using System.Collections.Generic;

namespace Epiphany.ViewModel.Collections
{
    public class Group<T> : List<T>
    {
        public Group(string name, IEnumerable<T> items)
            : base(items)
        {
            this.Header = name;
        }

        public string Header
        {
            get;
            private set;
        }

        public bool IsEmpty
        {
            get { return this.Count == 0; }
        }
    }
}
