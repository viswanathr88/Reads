using Epiphany.Model.Adapter;
using Epiphany.Model.Collections;
using Epiphany.Model.DataSources;
using Epiphany.Model.Messaging;
using Epiphany.Web;
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
        private IAdapter<BookModel, GoodreadsBook> adapter;
        private IAdapter<WorkModel, GoodreadsWork> workAdapter;

        private GoodreadsAuthor recentAuthor;

        public BookService(IWebClient webClient, IMessenger messenger)
        {
            if (webClient == null)
            {
                throw new ArgumentNullException(nameof(webClient));
            }

            this.webClient = webClient;
            this.messenger = messenger;

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
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["id"] = id.ToString();
            //
            // Get the parsed author
            //
            IDataSource<GoodreadsBook> ds = new DataSource<GoodreadsBook>(webClient, parameters, ServiceUrls.AuthorUrl);
            GoodreadsBook book = await ds.GetAsync();
            //
            // Send a message for listeners
            //
            GenericMessage<GoodreadsBook> msg = new GenericMessage<GoodreadsBook>(this, book);
            this.messenger.SendMessage<GenericMessage<GoodreadsBook>>(this, msg);
            //
            // Create the model
            //
            return BookAdapter.Convert(book);
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
            IDictionary<string, string> headers = new Dictionary<string, string>();
            headers["id"] = author.Id.ToString();
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
                books = new PagedCollection<BookModel, GoodreadsBook, GoodreadsBooks>(ds, BookAdapter, recentAuthor.BookCollection.Items);
            }
            else
            {
                books = new PagedCollection<BookModel, GoodreadsBook, GoodreadsBooks>(ds, BookAdapter, pageSize);
            }
            return books;
        }

        public IPagedCollection<BookModel> GetBooks(int userId, string shelfName, BookSortType sortType, BookSortOrder order)
        {
            //
            // Create headers
            //
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["id"] = userId.ToString();
            parameters["v"] = "2";
            parameters["shelf"] = shelfName;
            parameters["sort"] = sortType.ToString();
            parameters["order"] = order.ToString();
            //
            // Create the data source for the collection
            //
            IPagedDataSource<GoodreadsBooks> ds = new PagedDataSource<GoodreadsBooks>(webClient, parameters, ServiceUrls.BooksInShelfUrl);
            //
            // Create the collection
            //
            return new PagedCollection<BookModel, GoodreadsBook, GoodreadsBooks>(ds, BookAdapter, pageSize);
        }

        public async Task AddBook(BookshelfModel shelf, BookModel book)
        {
            // Create and execute the web request
            WebRequest request = new WebRequest(ServiceUrls.AddBookUrl, WebMethod.Post);
            request.Authenticate = true;
            request.Parameters["name"] = shelf.Name;
            request.Parameters["book_id"] = book.Id.ToString();
            WebResponse response = await webClient.ExecuteAsync(request);

            // Validate the response
            response.Validate(System.Net.HttpStatusCode.OK);

            // Create a dummy Review object and set it. Goodreads doesn't have an api
            // to refresh in place without making another request
            GoodreadsReview review = new GoodreadsReview()
            {
                Shelves = new List<GoodreadsShelf>()
                {
                    new GoodreadsShelf()
                    {
                        Name = shelf.Name
                    }
                }
            };
            if (book.Inner != null)
            {
                book.Inner.UserReview = review;
            }
        }

        public async Task RemoveBook(BookshelfModel shelf, BookModel book)
        {
            // Create and execute the web request
            WebRequest request = new WebRequest(ServiceUrls.AddBookUrl, WebMethod.Post);
            request.Authenticate = true;
            request.Parameters["name"] = shelf.Name;
            request.Parameters["book_id"] = book.Id.ToString();
            request.Parameters["a"] = "remove";
            WebResponse response = await webClient.ExecuteAsync(request);

            // Validate the response
            response.Validate(System.Net.HttpStatusCode.OK);

            // If to-read is the only shelf for this remove, empty it
            if (book.Inner != null && book.Inner.UserReview != null)
            {
                if (book.Inner.UserReview.Shelves.Count == 1 &&
                    book.Inner.UserReview.Shelves[0].Name == "to-read")
                {
                    book.Inner.UserReview = null;
                }
            }
        }

        public IPagedCollection<WorkModel> Find(BookSearchType type, string term)
        {
            //
            // Create the headers
            //
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["format"] = "xml";
            parameters["q"] = term;
            parameters["search[field]"] = type.ToString().ToLower();
            //
            // Create the data source for the collection
            //
            IPagedDataSource<GoodreadsSearch> ds = new PagedDataSource<GoodreadsSearch>(webClient, parameters, ServiceUrls.SearchUrl);
            return new PagedCollection<WorkModel, GoodreadsWork, GoodreadsSearch>(ds, WorkAdapter, pageSize);
        }

        private void HandleAuthorRetrieved(object sender, GenericMessage<GoodreadsAuthor> msg)
        {
            GoodreadsAuthor author = msg.Content;
            if (author != null)
            {
                this.recentAuthor = author;
            }
        }

        private IAdapter<BookModel, GoodreadsBook> BookAdapter
        {
            get
            {
                if (this.adapter == null)
                {
                    this.adapter = new BookAdapter();
                }

                return this.adapter;
            }
        }

        private IAdapter<WorkModel, GoodreadsWork> WorkAdapter
        {
            get
            {
                if (this.workAdapter == null)
                {
                    this.workAdapter = new WorkAdapter(BookAdapter);
                }

                return this.workAdapter;
            }
        }
    }
}
