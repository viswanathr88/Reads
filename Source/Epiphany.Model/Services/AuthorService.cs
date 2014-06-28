using Epiphany.Model.Adapter;
using Epiphany.Model.DataSources;
using Epiphany.Model.Messaging;
using Epiphany.Model.Web;
using Epiphany.Xml;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    internal sealed class AuthorService : IAuthorService
    {
        private readonly IWebClient webClient;
        private readonly IMessenger messenger;
        private readonly IAdapter<AuthorModel, GoodreadsAuthor> adapter;

        public AuthorService(IWebClient webClient, IMessenger messenger)
        {
            this.webClient = webClient;
            this.messenger = messenger;
            this.adapter = new AuthorAdapter();
        }

        public async Task<AuthorModel> GetAuthorAsync(int id)
        {
            //
            // Create the headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = id;
            //
            // Get the parsed author
            //
            IDataSource<GoodreadsAuthor> ds = new DataSource<GoodreadsAuthor>(webClient, headers, ServiceUrls.AuthorUrl);
            GoodreadsAuthor author = await ds.GetAsync();
            //
            // Send a message to listeners
            //
            GenericMessage<GoodreadsAuthor> msg = new GenericMessage<GoodreadsAuthor>(this, author);
            this.messenger.SendMessage<GenericMessage<GoodreadsAuthor>>(this, msg);
            //
            // Create the model
            //
            return this.adapter.Convert(author);
        }

        public Task FlipFanshipAsync(AuthorModel author)
        {
            throw new System.NotImplementedException();
        }
    }
}
