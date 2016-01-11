using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Items
{
    public interface IUserItemViewModel
    {
        int Id { get; }

        string Name { get; }

        string ImageUrl { get; }
    }
}
