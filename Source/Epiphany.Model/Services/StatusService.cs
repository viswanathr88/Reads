using Epiphany.Model.Adapter;
using Epiphany.Model.DataSources;
using Epiphany.Web;
using Epiphany.Xml;
using System;
using System.Collections.Generic;
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

        public async Task<UserStatusModel> GetUserStatus(int id)
        {
            //
            // Create headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = id;
            //
            // Create the data source
            //
            IDataSource<GoodreadsUserStatus> ds = new DataSource<GoodreadsUserStatus>(webClient, headers, ServiceUrls.UserStatusUrl);
            GoodreadsUserStatus status = await ds.GetAsync();
            return this.adapter.Convert(status);
        }

        public async Task UpdateUserStatus(UserStatusModel status)
        {
            //
            // Create the headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["user_status[book_id]"] = status.Book.Id;
            headers["user_status[page]"] = status.Page;
            headers["user_status[percent]"] = status.Percentage;
            headers["user_status[body]"] = status.Body;
            //
            // Create the web request and execute it
            //
            WebRequest request = new WebRequest(ServiceUrls.UpdateUserStatusUrl, WebMethod.Post);
            request.Authenticate = true;
            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.OK);
        }


        public async Task LikeStatus(UserStatusModel status)
        {
            //
            // Create the headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["rating[rating]"] = 1;
            headers["rating[resource_id]"] = status.Id;
            headers["rating[resource_type]"] = "UserStatus";
            //
            // Create the web request and execute it
            //
            WebRequest request = new WebRequest(ServiceUrls.LikeUrl, WebMethod.Put);
            request.Authenticate = true;
            WebResponse response = await webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }

        public async Task UnlikeStatus(UserStatusModel status)
        {
            //
            // Create the headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = status.Id;
            //
            // Create the web request and execute it
            //
            WebRequest request = new WebRequest(ServiceUrls.LikeUrl, WebMethod.Delete);
            request.Authenticate = true;
            WebResponse response = await webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.OK);
        }

        public async Task AddComment(UserStatusModel status, CommentModel comment)
        {
            //
            // Create headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["type"] = "user_status";
            headers["id"] = status.Id;
            //
            // Create the web request and execute it
            //
            WebRequest request = new WebRequest(ServiceUrls.CommentCreateUrl, WebMethod.Post);
            request.Authenticate = true;
            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }
    }
}
