using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiphany.Model.Adapter
{
    interface IAdapter<T1, T2>
    {
        T1 Convert(T2 item);
    }
}
