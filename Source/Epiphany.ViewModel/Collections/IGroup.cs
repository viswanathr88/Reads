using System.Collections.Generic;

namespace Epiphany.ViewModel.Collections
{
    public interface IGroup<T1, T2> : IList<T2>
    {
        T1 Key
        {
            get;
        }
    }
}
