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
    internal sealed class BookService : IBookService
    {
        private readonly IWebClient webClient;
        private readonly IMessenger messenger;
        private readonly int pageSize = 20;
        private readonly IAdapter<BookModel, GoodreadsBook> adapter;
        private readonly IAdapter<WorkModel, GoodreadsWork> workAdapter;

        private GoodreadsAuthor recentAuthor;

        public BookService(IWebClient webClient, IMessenger messenger)
        {
            if (webClient == null)
            {
                throw new ArgumentNullException("webClient");
            }

            this.webClient = webClient;
            this.messenger = messenger;
            this.adapter = new BookAdapter();
            this.workAdapter = new WorkAdapter(this.adapter);

            //
            // Listen to Author message
            //
            this.messenger.Subscribe<GenericMessage<GoodreadsAuthor>>(this, HandleAuthorRetrieved);
        }

        public async Task<BookModel> GetBook(int id)
        {
            //
            // Create the headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = id;
            //
            // Get the parsed author
            //
            IDataSource<GoodreadsBook> ds = new DataSource<GoodreadsBook>(webClient, headers, ServiceUrls.AuthorUrl);
            GoodreadsBook book = await ds.GetAsync();
            //
            // Send a message for listeners
            //
            GenericMessage<GoodreadsBook> msg = new GenericMessage<GoodreadsBook>(this, book);
            this.messenger.SendMessage<GenericMessage<GoodreadsBook>>(this, msg);
            //
            // Create the model
            //
            return this.adapter.Convert(book);
        }

        public IPagedCollection<BookModel> GetBooks(AuthorModel author)
        {
            if (author == null)
            {
                throw new ArgumentNullException("author");
            }

            if (author.Id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id");
            }

            //
            // Create headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = author.Id;
            //
            // Create the data source for the collection
            //
            IPagedDataSource<GoodreadsBooks> ds = new PagedDataSource<GoodreadsBooks>(webClient, headers, ServiceUrls.BooksByAuthorUrl);
            //
            // Create the collection
            //
            IPagedCollection<BookModel> books = null;
            if (recentAuthor != null && author.Id == this.recentAuthor.Id && recentAuthor.BookCollection != null)
            {
                //
                // Leverage the books that were fetched as part of the author instead of retrieving it again
                //
                books = new PagedCollection<BookModel, GoodreadsBook, GoodreadsBooks>(ds, adapter, recentAuthor.BookCollection.Items);
            }
            else
            {
                books = new PagedCollection<BookModel, GoodreadsBook, GoodreadsBooks>(ds, this.adapter, pageSize);
            }
            return books;
        }

        public IPagedCollection<BookModel> GetBooks(int userId, string shelfName, BookSortType sortType, BookSortOrder order)
        {
            //
            // Create headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = userId;
            headers["v"] = "2";
            headers["shelf"] = shelfName;
            headers["sort"] = sortType;
            headers["order"] = order;
            //
            // Create the data source for the collection
            //
            IPagedDataSource<GoodreadsBooks> ds = new PagedDataSource<GoodreadsBooks>(webClient, headers, ServiceUrls.BooksInShelfUrl);
            //
            // Create the collection
            //
            return new PagedCollection<BookModel, GoodreadsBook, GoodreadsBooks>(ds, adapter, pageSize);
        }

        public async Task AddBook(BookshelfModel shelf, BookModel book)
        {
            //
            // Create headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["name"] = shelf.Name;
            headers["book_id"] = book.Id;
            //
            // Create and execute the web request
            //
            WebRequest request = new WebRequest(ServiceUrls.AddBookUrl, WebMethod.AuthenticatedPost);
            WebResponse response = await webClient.ExecuteAsync(request);
            //
            // Validate the response
            //
            response.Validate(System.Net.HttpStatusCode.Created);
        }

        public async Task RemoveBook(BookshelfModel shelf, BookModel book)
        {
            //
            // Create headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["name"] = shelf.Name;
            headers["book_id"] = book.Id;
            headers["a"] = "remove";
            //
            // Create and execute the web request
            //
            WebRequest request = new WebRequest(ServiceUrls.AddBookUrl, WebMethod.AuthenticatedPost);
            WebResponse response = await webClient.ExecuteAsync(request);
            //
            // Validate the response
            //
            response.Validate(System.Net.HttpStatusCode.OK);
        }

        public IPagedCollection<WorkModel> Find(BookSearchType type, string term)
        {
            //
            // Create the headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["q"] = term;
            headers["search[field]"] = type.ToString();
            //
            // Create the data source for the collection
            //
            IPagedDataSource<GoodreadsSearch> ds = new PagedDataSource<GoodreadsSearch>(webClient, headers, ServiceUrls.SearchUrl);
            return new PagedCollection<WorkModel, GoodreadsWork, GoodreadsSearch>(ds, workAdapter, pageSize);
        }

        private void HandleAuthorRetrieved(object sender, GenericMessage<GoodreadsAuthor> msg)
        {
            GoodreadsAuthor author = msg.Content;
            if (author != null)
            {
                this.recentAuthor = author;
            }
        }
    }
}
