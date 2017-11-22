using Epiphany.Model;

namespace Epiphany.ViewModel.Items
{
    /// <summary>
    /// Represents a literary event item in a list
    /// </summary>
    public interface IEventItemViewModel : IItemViewModel<LiteraryEventModel>
    {
        /// <summary>
        /// Gets the title of the literary event
        /// </summary>
        string Title
        {
            get;
        }
        /// <summary>
        /// Gets the image url
        /// </summary>
        string ImageUrl
        {
            get;
        }
        /// <summary>
        /// Gets the starting time of the event
        /// </summary>
        string Time
        {
            get;
        }
        /// <summary>
        /// Gets the venue of the literary event
        /// </summary>
        string Venue
        {
            get;
        }
        /// <summary>
        /// Gets the city where the literary event is hosted
        /// </summary>
        string City
        {
            get;
        }
        /// <summary>
        /// Gets the state code
        /// </summary>
        string StateCode
        {
            get;
        }
        /// <summary>
        /// Gets the description of the event
        /// </summary>
        string Description
        {
            get;
        }
        /// <summary>
        /// Gets the link to the event
        /// </summary>
        string Link
        {
            get;
        }
    }
}
