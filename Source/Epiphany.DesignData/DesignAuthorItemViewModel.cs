using Epiphany.ViewModel.Items;

namespace Epiphany.View.DesignData
{
    public sealed class DesignAuthorItemViewModel : DesignBaseItemViewModel, IAuthorItemViewModel
    {
        public DesignAuthorItemViewModel()
        {
            Name = "Test Author";
        }

        public long Id
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}
