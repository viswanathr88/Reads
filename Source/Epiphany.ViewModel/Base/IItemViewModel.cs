using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public interface IItemViewModel
    {
        bool IsSelected
        {
            get;
            set;
        }
    }
}
