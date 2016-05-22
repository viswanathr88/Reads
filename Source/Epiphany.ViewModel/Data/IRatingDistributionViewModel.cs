using Epiphany.ViewModel.Items;
using System.Collections.Generic;
using System.ComponentModel;

namespace Epiphany.ViewModel
{
    public interface IRatingDistributionViewModel : INotifyPropertyChanged
    {
        int Total
        {
            get;
        }

        IList<IRatingDistributionItemViewModel> Ratings
        {
            get;
        }
    }
}
