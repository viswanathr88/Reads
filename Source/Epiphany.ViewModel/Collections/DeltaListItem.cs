using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Collections
{
    public enum DeltaListOperation
    {
        Added,
        Removed
    };

    public class DeltaListItem<T> where T : IEquatable<T>, IComparable<T>
    {
        private readonly DeltaListOperation operation;
        private readonly T item;

        public DeltaListItem(DeltaListOperation operation, T item)
        {
            this.operation = operation;
            this.item = item;
        }

        public DeltaListOperation Operation
        {
            get { return this.operation; }
        }

        public T Item
        {
            get { return this.item; }
        }
    }
}
