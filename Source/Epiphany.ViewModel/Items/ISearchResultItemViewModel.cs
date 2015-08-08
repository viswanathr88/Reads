using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Items
{
    public interface ISearchResultItemViewModel
    {
        IBookItemViewModel Book { get; }

        IAuthorItemViewModel Author { get; }
    }
}
