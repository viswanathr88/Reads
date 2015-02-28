using Epiphany.Model;
using Epiphany.Model.Authentication;
using Epiphany.Model.Services;
using Epiphany.Model.Web;
using RestSharp.Portable;
using RestSharp.Portable.Authenticators;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Epiphany.View.Web
{
    public class WebClient : IWebClient
    {
        private readonly IAuthService authService;
        private readonly RestClient restClient;

        public WebClient(IAuthService authService)
        {
            if (authService == null)
            {
                throw new ArgumentNullException("authService");
            }

            this.authService = authService;
            this.restClient = new RestClient(this.authService.Configuration.BaseUri.ToString());
        }
        public async Task<WebResponse> ExecuteAsync(WebRequest request)
        {
            switch (request.Method)
            {
                case WebMethod.Get:
                    return await DoHttpOperation(request.Url, HttpMethod.Get, request.Headers);
                case WebMethod.Post:
                    return await DoHttpOperation(request.Url, HttpMethod.Post, request.Headers);
                case WebMethod.Put:
                    return await DoHttpOperation(request.Url, HttpMethod.Put, request.Headers);
                case WebMethod.Delete:
                    return await DoHttpOperation(request.Url, HttpMethod.Delete, request.Headers);
                case WebMethod.AuthenticatedGet:
                    return await DoAuthenticatedHttpOperation(request.Url, HttpMethod.Get, request.Headers);
                case WebMethod.AuthenticatedPost:
                    return await DoAuthenticatedHttpOperation(request.Url, HttpMethod.Post, request.Headers);
                case WebMethod.AuthenticatedPut:
                    return await DoAuthenticatedHttpOperation(request.Url, HttpMethod.Put, request.Headers);
                case WebMethod.AuthenticatedDelete:
                    return await DoAuthenticatedHttpOperation(request.Url, HttpMethod.Delete, request.Headers);
                default:
                    throw new NotSupportedException();
            }
        }

        private async Task<WebResponse> DoHttpOperation(string url, HttpMethod method, IDictionary<string, object> parameters)
        {
            var request = new RestRequest(url, method);
            foreach (KeyValuePair<string, object> paramater in parameters)
            {
                request.AddParameter(paramater.Key, paramater.Value);
            }
            request.AddParameter("key", this.authService.Configuration.ConsumerKey);
            IRestResponse<string> response = await this.restClient.Execute<string>(request);
            WebResponse webResponse = new WebResponse(response.StatusCode, response.Data);
            return webResponse;
        }

        private async Task<WebResponse> DoAuthenticatedHttpOperation(string url, HttpMethod method, IDictionary<string, object> parameters)
        {
            var request = new RestRequest(url, method);
            Token token = await this.authService.GetToken();

            if (token == null)
            {
                throw new ModelException(ModelExceptionType.NoTokens);
            }

            this.restClient.Authenticator = OAuth1Authenticator.ForProtectedResource(
                this.authService.Configuration.ConsumerKey, this.authService.Configuration.ConsumerKeySecret,
                token.AuthToken, token.TokenSecret);
            foreach (KeyValuePair<string, object> paramater in parameters)
            {
                request.AddParameter(paramater.Key, paramater.Value);
            }
            request.AddParameter("key", this.authService.Configuration.ConsumerKey);
            IRestResponse<string> response = await this.restClient.Execute<string>(request);
            WebResponse webResponse = new WebResponse(response.StatusCode, string.Empty);
            return webResponse;
        }
    }
}
