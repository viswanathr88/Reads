using Epiphany.ViewModel;
using System.ComponentModel;

namespace Epiphany.View.DesignData
{
    public abstract class DesignBaseItemViewModel : ViewModelBase, IItemViewModel
    {
        public bool IsSelected
        {
            get;
            set;
        }

        public object Item
        {
            get;
            set;
        }
    }
}
