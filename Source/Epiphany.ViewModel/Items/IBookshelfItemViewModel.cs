using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Items
{
    public interface IBookshelfItemViewModel
    {
        int ShelfId { get; }

        int UserId { get; }

        string Name { get; }

        int NumberOfBooks { get; }
    }
}
