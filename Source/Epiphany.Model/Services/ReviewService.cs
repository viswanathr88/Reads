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
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["id"] = id.ToString();
            //
            // Create a data source
            //
            IDataSource<GoodreadsReview> ds = new DataSource<GoodreadsReview>(webClient, parameters, ServiceUrls.ReviewUrl);
            GoodreadsReview review = await ds.GetAsync();
            return this.adapter.Convert(review);
        }

        public IPagedCollection<ReviewModel> GetReviewsAsync(BookModel book)
        {
            //
            // Create the parameters
            //
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["id"] = book.Id.ToString();
            //
            // Create a data source and the collection
            //
            IPagedDataSource<GoodreadsReviews> ds = new PagedDataSource<GoodreadsReviews>(webClient, parameters, ServiceUrls.BookUrl);
            IPagedCollection<ReviewModel> reviews = null;
            if (recentBook != null && book.Id == this.recentBook.Id && recentBook.PublicReviews != null)
            {
                // Leverage the reviews that were fetched as part of the book instead of retrieving it again
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
            // Create the web request and execute it
            WebRequest request = new WebRequest(ServiceUrls.AddReviewUrl, WebMethod.Post);
            request.Authenticate = true;
            request.Parameters["book_id"] = book.Id.ToString();
            request.Parameters["review[review]"] = review.Body;
            request.Parameters["review[rating]"] = review.Rating.ToString();

            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }

        public async Task EditReviewAsync(BookModel book, ReviewModel review, bool markAsFinished)
        {
            // Create the web request and execute it
            WebRequest request = new WebRequest(ServiceUrls.AddReviewUrl, WebMethod.Post);
            request.Authenticate = true;
            request.Parameters["id"] = review.Id.ToString();
            request.Parameters["review[review]"] = review.Body;
            request.Parameters["review[rating]"] = review.Rating.ToString();
            request.Parameters["finished"] = markAsFinished.ToString();

            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.OK);
        }

        public async Task LikeReviewAsync(ReviewModel review)
        {
            // Create the web request and execute it
            WebRequest request = new WebRequest(ServiceUrls.LikeUrl, WebMethod.Put);
            request.Authenticate = true;
            request.Parameters["rating[rating]"] = "1";
            request.Parameters["rating[resource_id]"] = review.Id.ToString();
            request.Parameters["rating[resource_type]"] = "Review";

            WebResponse response = await webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }

        public async Task UnlikeReviewAsync(ReviewModel review)
        {
            // Create the web request and execute it
            WebRequest request = new WebRequest(ServiceUrls.LikeUrl, WebMethod.Delete);
            request.Authenticate = true;
            request.Parameters["id"] = review.Id.ToString();
            WebResponse response = await webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.OK);
        }

        public async Task AddComment(ReviewModel review, CommentModel comment)
        {
            // Create the web request and execute it
            WebRequest request = new WebRequest(ServiceUrls.CommentCreateUrl, WebMethod.Post);
            request.Authenticate = true;
            request.Parameters["type"] = "review";
            request.Parameters["id"] = review.Id.ToString();

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
