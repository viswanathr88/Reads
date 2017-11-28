using Epiphany.ViewModel.Items;

namespace Epiphany.View.DesignData
{
    public sealed class DesignUserItemViewModel : DesignBaseItemViewModel, IUserItemViewModel
    {
        public DesignUserItemViewModel()
        {
            Id = 50;
            Name = "Test User";
            ImageUrl = @"http://www.photonicconference.com/Phosphors/media/Examples/male-placeholder.png";
        }
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
