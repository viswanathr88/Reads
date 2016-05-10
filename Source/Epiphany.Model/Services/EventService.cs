using Epiphany.Model.Adapter;
using Epiphany.Model.DataSources;
using Epiphany.Web;
using Epiphany.Xml;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    internal sealed class EventService : IEventService
    {
        private readonly IWebClient webClient;
        private readonly IAdapter<LiteraryEventModel, GoodreadsEvent> adapter;

        public EventService(IWebClient webClient)
        {
            this.webClient = webClient;
            this.adapter = new EventAdapter();
        }

        public async Task<IEnumerable<LiteraryEventModel>> GetEvents(double lat, double lon)
        {
            // Create headers
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["lat"] = lat.ToString();
            parameters["lng"] = lon.ToString();
            parameters["search[postal_code]"] = "'GPS_QUERY'";

            // Create the data source and get the events
            var ds = new DataSource<GoodreadsEvents>(webClient);
            ds.SourceUrl = ServiceUrls.EventsUrl;
            ds.Parameters["lat"] = lat.ToString();
            ds.Parameters["lng"] = lon.ToString();
            ds.Parameters["search[postal_code]"] = "'GPS_QUERY'";
            ds.RequiresAuthentication = false;
            ds.Returns = (response) => response.Events;
            
            GoodreadsEvents events = await ds.GetAsync();
            
            IList<LiteraryEventModel> result = new List<LiteraryEventModel>();
            foreach (GoodreadsEvent e in events.Events)
            {
                result.Add(this.adapter.Convert(e));
            }
            return result;
        }

        public async Task<IEnumerable<LiteraryEventModel>> GetEvents(int postalCode)
        {
            // Create parameters
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["search[postal_code]"] = postalCode.ToString();

            // Create the data source and get the events
            var ds = new DataSource<GoodreadsEvents>(webClient);
            ds.SourceUrl = ServiceUrls.EventsUrl;
            ds.Parameters["search[postal_code]"] = postalCode.ToString();
            ds.Returns = (response) => response.Events;
            
            GoodreadsEvents events = await ds.GetAsync();

            IList<LiteraryEventModel> result = new List<LiteraryEventModel>();
            foreach (GoodreadsEvent e in events.Events)
            {
                result.Add(this.adapter.Convert(e));
            }
            return result;
        }
    }
}
