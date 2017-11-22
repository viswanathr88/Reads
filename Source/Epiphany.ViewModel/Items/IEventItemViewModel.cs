using Epiphany.Model;

namespace Epiphany.ViewModel.Items
{
    public interface IEventItemViewModel : IItemViewModel<LiteraryEventModel>
    {
        string Title
        {
            get;
        }

        string ImageUrl
        {
            get;
        }

        string Time
        {
            get;
        }

        string Venue
        {
            get;
        }

        string City
        {
            get;
        }

        string StateCode
        {
            get;
        }

        string Description
        {
            get;
        }
    }
}
