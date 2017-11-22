using Epiphany.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Items
{
    sealed class EventItemViewModel : ItemViewModel<LiteraryEventModel>, IEventItemViewModel
    {
        public EventItemViewModel(LiteraryEventModel item) 
            : base(item)
        {
        }

        public string City
        {
            get
            {
                return Item.City;
            }
        }

        public string Description
        {
            get
            {
                var builder = new StringBuilder();
                if (!string.IsNullOrEmpty(Item.Description))
                {
                    builder.AppendWithoutTags(Item.Description);
                }
                return builder.ToString();
            }
        }

        public string ImageUrl
        {
            get
            {
                return Item.ImageUrl;
            }
        }

        public string Link
        {
            get
            {
                return Item.Link;
            }
        }

        public string StateCode
        {
            get
            {
                return Item.StateCode;
            }
        }

        public string Time
        {
            get
            {
                return String.Format("{0:dddd, MMMM d, yyyy}", Item.StartTime);
            }
        }

        public string Title
        {
            get
            {
                return Item.Title;
            }
        }

        public string Venue
        {
            get
            {
                return Item.Venue;
            }
        }
    }
}
