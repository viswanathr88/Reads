using Epiphany.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public class FeedItemViewModel : ItemViewModel<FeedItemModel> 
    {
        public FeedItemViewModel(FeedItemModel model) 
            : base (model)
        {

        }
    }
}
