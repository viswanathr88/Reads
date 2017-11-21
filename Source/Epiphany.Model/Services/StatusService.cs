using Epiphany.Model.Adapter;
using Epiphany.Model.DataSources;
using Epiphany.Web;
using Epiphany.Xml;
using System;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    class StatusService : IStatusService
    {
        private readonly IWebClient webClient;
        private readonly IAdapter<UserStatusModel, GoodreadsUserStatus> adapter;

        public StatusService(IWebClient webClient)
        {
            if (webClient == null)
            {
                throw new ArgumentNullException();
            }

            this.webClient = webClient;
            this.adapter = new UserStatusAdapter();
        }

        public async Task<UserStatusModel> GetUserStatus(long id)
        {
            // Create the data source
            var ds = new DataSource<GoodreadsUserStatus>(webClient);
            ds.SourceUrl = ServiceUrls.UserStatusUrl;
            ds.Parameters["id"] = id.ToString();
            // TODO: ds.Returns = (response) =>

            GoodreadsUserStatus status = await ds.GetAsync();
            return this.adapter.Convert(status);
        }

        public async Task UpdateUserStatus(UserStatusModel status)
        {
            // Create the web request and execute it
            WebRequest request = new WebRequest(ServiceUrls.UpdateUserStatusUrl, WebMethod.Post);
            request.Authenticate = true;
            request.Parameters["user_status[book_id]"] = status.Book.Id.ToString();
            request.Parameters["user_status[page]"] = status.Page.ToString();
            request.Parameters["user_status[percent]"] = status.Percentage.ToString();
            request.Parameters["user_status[body]"] = status.Body;

            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.OK);
        }


        public async Task LikeStatus(UserStatusModel status)
        {
            // Create the web request and execute it
            WebRequest request = new WebRequest(ServiceUrls.LikeUrl, WebMethod.Put);
            request.Authenticate = true;
            request.Parameters["rating[rating]"] = "1";
            request.Parameters["rating[resource_id]"] = status.Id.ToString();
            request.Parameters["rating[resource_type]"] = "UserStatus";

            WebResponse response = await webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }

        public async Task UnlikeStatus(UserStatusModel status)
        {
            // Create the web request and execute it
            WebRequest request = new WebRequest(ServiceUrls.LikeUrl, WebMethod.Delete);
            request.Authenticate = true;
            request.Parameters["id"] = status.Id.ToString();

            WebResponse response = await webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.OK);
        }

        public async Task AddComment(UserStatusModel status, CommentModel comment)
        {
            // Create the web request and execute it
            WebRequest request = new WebRequest(ServiceUrls.CommentCreateUrl, WebMethod.Post);
            request.Authenticate = true;
            request.Parameters["type"] = "user_status";
            request.Parameters["id"] = status.Id.ToString();

            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }
    }
}
