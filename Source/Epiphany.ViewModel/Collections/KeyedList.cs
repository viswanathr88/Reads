using System.Collections.Generic;
using System.Linq;

namespace Epiphany.ViewModel.Collections
{
    public class KeyedList<TKey, TItem> : List<TItem>
    {
        public TKey Key
        {
            get;
            protected set;
        }

        public KeyedList(TKey key)
            : base()
        {
            Key = key;
        }

        public KeyedList(TKey key, IEnumerable<TItem> items)
            : base(items)
        {
            Key = key;
        }

        public KeyedList(IGrouping<TKey, TItem> grouping) :
            base(grouping)
        {

            Key = grouping.Key;
        }
    }
}
