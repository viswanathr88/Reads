using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public interface IBooksViewModel : IDataViewModel
    {
        int UserId
        {
            get;
            set;
        }

        string UserName
        {
            get;
            set;
        }

        string ShelfName
        {
            get;
            set;
        }
    }
}
