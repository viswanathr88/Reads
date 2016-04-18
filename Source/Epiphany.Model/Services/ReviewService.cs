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
    class ReviewService : IReviewService
    {
        private readonly IWebClient webClient;
        private readonly IMessenger messenger;
        private readonly IAdapter<ReviewModel, GoodreadsReview> adapter;
        private readonly int pageSize = 20;

        private GoodreadsBook recentBook;

        public ReviewService(IWebClient webClient, IMessenger messenger)
        {
            this.webClient = webClient;
            this.messenger = messenger;
            this.adapter = new ReviewAdapter();
            //
            // Subscribe for messages
            //
            this.messenger.Subscribe<GenericMessage<GoodreadsBook>>(this, HandleBookRetrieved);
        }

        //
        // TODO: Figure out a way to send the book as well in this case
        //
        public async Task<ReviewModel> GetReviewAsync(int id)
        {
            //
            // Create headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = id;
            //
            // Create a data source
            //
            IDataSource<GoodreadsReview> ds = new DataSource<GoodreadsReview>(webClient, headers, ServiceUrls.ReviewUrl);
            GoodreadsReview review = await ds.GetAsync();
            return this.adapter.Convert(review);
        }

        public IPagedCollection<ReviewModel> GetReviewsAsync(BookModel book)
        {
            //
            // Create the headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = book.Id;
            //
            // Create a data source and the collection
            //
            IPagedDataSource<GoodreadsReviews> ds = new PagedDataSource<GoodreadsReviews>(webClient, headers, ServiceUrls.BookUrl);
            IPagedCollection<ReviewModel> reviews = null;
            if (recentBook != null && book.Id == this.recentBook.Id && recentBook.PublicReviews != null)
            {
                //
                // Leverage the reviews that were fetched as part of the book instead of retrieving it again
                //
                reviews = new PagedCollection<ReviewModel, GoodreadsReview, GoodreadsReviews>(ds, adapter, recentBook.PublicReviews.Items);
            }
            else
            {
                reviews = new PagedCollection<ReviewModel, GoodreadsReview, GoodreadsReviews>(ds, adapter, pageSize);
            }
            return reviews;
        }

        public async Task AddReviewAsync(BookModel book, ReviewModel review)
        {
            //
            // Create the headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["book_id"] = book.Id;
            headers["review[review]"] = review.Body;
            headers["review[rating]"] = review.Rating;
            //
            // Create the web request and execute it
            //
            WebRequest request = new WebRequest(ServiceUrls.AddReviewUrl, WebMethod.Post);
            request.Authenticate = true;
            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }

        public async Task EditReviewAsync(BookModel book, ReviewModel review, bool markAsFinished)
        {
            //
            // Create the headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = review.Id;
            headers["review[review]"] = review.Body;
            headers["review[rating]"] = review.Rating;
            headers["finished"] = markAsFinished;
            //
            // Create the web request and execute it
            //
            WebRequest request = new WebRequest(ServiceUrls.AddReviewUrl, WebMethod.Post);
            request.Authenticate = true;
            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.OK);
        }

        public async Task LikeReviewAsync(ReviewModel review)
        {
            //
            // Create the headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["rating[rating]"] = 1;
            headers["rating[resource_id]"] = review.Id;
            headers["rating[resource_type]"] = "Review";
            //
            // Create the web request and execute it
            //
            WebRequest request = new WebRequest(ServiceUrls.LikeUrl, WebMethod.Put);
            request.Authenticate = true;
            WebResponse response = await webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }

        public async Task UnlikeReviewAsync(ReviewModel review)
        {
            //
            // Create the headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = review.Id;
            //
            // Create the web request and execute it
            //
            WebRequest request = new WebRequest(ServiceUrls.LikeUrl, WebMethod.Delete);
            request.Authenticate = true;
            WebResponse response = await webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.OK);
        }

        public async Task AddComment(ReviewModel review, CommentModel comment)
        {
            //
            // Create headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["type"] = "review";
            headers["id"] = review.Id;
            //
            // Create the web request and execute it
            //
            WebRequest request = new WebRequest(ServiceUrls.CommentCreateUrl, WebMethod.Post);
            request.Authenticate = true;
            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }

        private void HandleBookRetrieved(object sender, GenericMessage<GoodreadsBook> msg)
        {
            if (msg.Content != null)
            {
                recentBook = msg.Content;
            }
        }
    }
}
