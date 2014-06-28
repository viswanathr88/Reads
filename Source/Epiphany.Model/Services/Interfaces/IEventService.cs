using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    /// <summary>
    /// Interface for literary events service
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Gets events near a location
        /// </summary>
        /// <param name="lat">latitute</param>
        /// <param name="lon">longitude</param>
        /// <returns>list of literary event</returns>
        Task<IEnumerable<LiteraryEventModel>> GetEvents(double lat, double lon);
        /// <summary>
        /// Gets events occurring in an area
        /// </summary>
        /// <param name="postalCode">postal code of the area</param>
        /// <returns>list of literary events</returns>
        Task<IEnumerable<LiteraryEventModel>> GetEvents(int postalCode);
    }
}
