using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.View.Share
{
    public interface ISupportShare<T>
    {
        void Share(T item);
    }
}
