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
            //
            // Create headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["lat"] = lat;
            headers["lng"] = lon;
            headers["search[postal_code]"] = "'GPS_QUERY'";
            //
            // Create the data source and get the events
            //
            IDataSource<GoodreadsEvents> ds = new DataSource<GoodreadsEvents>(webClient, headers, ServiceUrls.EventsUrl);
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
            //
            // Create headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["search[postal_code]"] = postalCode;
            //
            // Create the data source and get the events
            //
            IDataSource<GoodreadsEvents> ds = new DataSource<GoodreadsEvents>(webClient, headers, ServiceUrls.EventsUrl);
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
