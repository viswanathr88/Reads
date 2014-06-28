using Epiphany.Model.Adapter;
using Epiphany.Model.Collections;
using Epiphany.Model.DataSources;
using Epiphany.Model.Messaging;
using Epiphany.Model.Web;
using Epiphany.Xml;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    internal class BookshelfService : IBookshelfService
    {
        private readonly IWebClient webClient;
        private readonly int itemsCount = 20;
        private readonly IAdapter<BookshelfModel, GoodreadsUserShelf> adapter;

        public BookshelfService(IWebClient webClient)
        {
            this.webClient = webClient;
            this.adapter = new BookshelfAdapter();
        }

        public IPagedCollection<BookshelfModel> GetBookshelves(int userId)
        {
            //
            // Create the headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = userId;
            //
            // Create the data source for the collection
            //
            IPagedDataSource<GoodreadsShelves> ds = new PagedDataSource<GoodreadsShelves>(webClient, headers, ServiceUrls.ShelvesUrl);
            //
            // Create the collection
            //
            return new PagedCollection<BookshelfModel, GoodreadsUserShelf, GoodreadsShelves>(ds, adapter, itemsCount);
        }

        public async Task AddShelf(BookshelfModel shelf)
        {
            //
            // Create the headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["user_shelf[name]"] = shelf.Name;
            //
            // Create the request, execute it and validate the response
            //
            WebRequest request = new WebRequest(ServiceUrls.AddShelfUrl, WebMethod.AuthenticatedPost);
            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }

        public async Task RemoveShelf(BookshelfModel shelf)
        {
            //
            // Create the headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["user_shelf[name]"] = shelf.Name;
            //
            // Create the request, execute it and validate the response
            //
            WebRequest request = new WebRequest(ServiceUrls.AddShelfUrl, WebMethod.AuthenticatedPost);
            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.OK);
        }
    }
}
