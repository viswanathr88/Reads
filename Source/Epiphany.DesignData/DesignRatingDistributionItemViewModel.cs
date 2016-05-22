using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;

namespace Epiphany.View.DesignData
{
    public sealed class DesignRatingDistributionItemViewModel : ViewModelBase, IRatingDistributionItemViewModel
    {
        public string Header
        {
            get;
            set;
        }

        public int Value
        {
            get;
            set;
        }
    }
}
