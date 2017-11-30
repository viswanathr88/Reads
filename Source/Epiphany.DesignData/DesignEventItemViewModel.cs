using Epiphany.Model;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;

namespace Epiphany.View.DesignData
{
    sealed class DesignEventItemViewModel : DesignBaseItemViewModel, IEventItemViewModel
    {
        public DesignEventItemViewModel()
        {
            Title = "Blah Blah Blah Blah Blah Blah (Blah Blah Blah)";
            City = "Seattle";
            Time = "Nov 25 2017";
            Venue = "Benaroya Hall";
            ImageUrl = @"https://d.gr-assets.com/authors/1199698411p7/18541.jpg";
        }
        public string City
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }

        public string Link
        {
            get;
            set;
        }

        public string StateCode
        {
            get;
            set;
        }

        public string Time
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Venue
        {
            get;
            set;
        }

        LiteraryEventModel IItemViewModel<LiteraryEventModel>.Item
        {
            get
            {
                return null;
            }
        }
    }
}
