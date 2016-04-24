using Epiphany.Model.Adapter;
using Epiphany.Model.Collections;
using Epiphany.Model.DataSources;
using Epiphany.Model.Messaging;
using Epiphany.Web;
using Epiphany.Xml;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    internal class BookshelfService : IBookshelfService
    {
        private readonly IWebClient webClient;
        private readonly IMessenger messenger;
        private readonly int itemsCount = 20;
        private readonly IAdapter<BookshelfModel, GoodreadsUserShelf> adapter;

        private GoodreadsProfile recentProfile;

        public BookshelfService(IWebClient webClient, IMessenger messenger)
        {
            this.webClient = webClient;
            this.messenger = messenger;
            this.adapter = new BookshelfAdapter();

            this.messenger.Subscribe<GenericMessage<GoodreadsProfile>>(this, HandleProfileRetrived);
        }

        public IPagedCollection<BookshelfModel> GetBookshelves(int userId)
        {
            //
            // Create the headers
            //
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["user_id"] = userId.ToString();
            //
            // Create the data source for the collection
            //
            IPagedDataSource<GoodreadsShelves> ds = new PagedDataSource<GoodreadsShelves>(webClient, parameters, ServiceUrls.ShelvesUrl);
            //
            // Create the collection
            //
            IPagedCollection<BookshelfModel> collection = null;
            if (this.recentProfile != null && this.recentProfile.Id == userId && this.recentProfile.Shelves != null)
            {
                collection = new PagedCollection<BookshelfModel, GoodreadsUserShelf, GoodreadsShelves>(ds, adapter, this.recentProfile.Shelves);
            }
            else
            {
                collection = new PagedCollection<BookshelfModel, GoodreadsUserShelf, GoodreadsShelves>(ds, adapter, itemsCount);
            }


            return collection;
        }

        public async Task AddShelf(BookshelfModel shelf)
        {
            // Create the request, execute it and validate the response
            WebRequest request = new WebRequest(ServiceUrls.AddShelfUrl, WebMethod.Post);
            request.Parameters["user_shelf[name]"] = shelf.Name;
            request.Authenticate = true;
            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }

        public async Task RemoveShelf(BookshelfModel shelf)
        {
            // Create the request, execute it and validate the response
            WebRequest request = new WebRequest(ServiceUrls.AddShelfUrl, WebMethod.Post);
            request.Parameters["user_shelf[name]"] = shelf.Name;
            request.Authenticate = true;
            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.OK);
        }

        private void HandleProfileRetrived(object sender, GenericMessage<GoodreadsProfile> message)
        {
            if (message != null && message.Content != null)
            {
                this.recentProfile = message.Content;
            }
        }
    }
}
