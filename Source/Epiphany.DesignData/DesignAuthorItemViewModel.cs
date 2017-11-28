using Epiphany.ViewModel.Items;

namespace Epiphany.View.DesignData
{
    public sealed class DesignAuthorItemViewModel : DesignBaseItemViewModel, IAuthorItemViewModel
    {
        public DesignAuthorItemViewModel()
        {
            Id = 51;
            Name = "Test Author";
            ImageUrl = @"https://d.gr-assets.com/authors/1199698411p7/18541.jpg";
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
