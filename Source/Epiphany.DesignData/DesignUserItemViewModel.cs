using Epiphany.ViewModel.Items;

namespace Epiphany.View.DesignData
{
    public sealed class DesignUserItemViewModel : DesignBaseItemViewModel, IUserItemViewModel
    {
        public long Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }
    }
}
