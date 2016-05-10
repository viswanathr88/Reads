using Epiphany.Model.Adapter;
using Epiphany.Model.DataSources;
using Epiphany.Model.Messaging;
using Epiphany.Web;
using Epiphany.Xml;
using System.Threading.Tasks;
using System;

namespace Epiphany.Model.Services
{
    internal sealed class AuthorService : IAuthorService
    {
        private readonly IWebClient webClient;
        private readonly IMessenger messenger;
        private IAdapter<AuthorModel, GoodreadsAuthor> adapter;

        public AuthorService(IWebClient webClient, IMessenger messenger)
        {
            this.webClient = webClient;
            this.messenger = messenger;
        }

        public async Task<AuthorModel> GetAuthorAsync(int id)
        {
            // Create the data source
            var ds = new DataSource<GoodreadsAuthor>(webClient);
            ds.SourceUrl = ServiceUrls.AuthorUrl;
            ds.Parameters["id"] = id.ToString();

            GoodreadsAuthor author = await ds.GetAsync();
            
            // Send a message to listeners
            GenericMessage<GoodreadsAuthor> msg = new GenericMessage<GoodreadsAuthor>(this, author);
            this.messenger.SendMessage<GenericMessage<GoodreadsAuthor>>(this, msg);
            
            // Create the model
            return Adapter.Convert(author);
        }

        public Task FlipFanshipAsync(AuthorModel author)
        {
            throw new System.NotImplementedException();
        }

        public async Task FollowAuthor(AuthorModel author)
        {
            WebRequest request = new WebRequest(ServiceUrls.FollowAuthorUrl, WebMethod.Post);
            request.Authenticate = true;
            request.Parameters["id"] = author.Id.ToString();
            request.Parameters["format"] = "xml";

            var webResponse = await this.webClient.ExecuteAsync(request);
            webResponse.Validate(System.Net.HttpStatusCode.OK);
        }

        private IAdapter<AuthorModel, GoodreadsAuthor> Adapter
        {
            get
            {
                if (this.adapter == null)
                {
                    this.adapter = new AuthorAdapter();
                }
                return this.adapter;
            }
        }
    }
}
