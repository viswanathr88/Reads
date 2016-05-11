using Epiphany.Logging;
using Epiphany.Model.Authentication;
using Epiphany.Web;
using Epiphany.Xml;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.Model.DataSources
{
    class DataSource<T> : IDataSource<T>
    {
        private readonly IWebClient webClient;

        public DataSource(IWebClient webClient)
        {
            if (webClient == null)
            {
                throw new ArgumentNullException(nameof(webClient));
            }

            this.webClient = webClient;
            Parameters = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Parameters
        {
            get;
        }

        public string SourceUrl
        {
            get;
            set;
        }

        public bool RequiresAuthentication
        {
            get;
            set;
        }

        public Func<Response, T> Returns
        {
            get;
            set;
        }

        public async Task<T> GetAsync()
        {
            if (string.IsNullOrEmpty(SourceUrl))
            {
                throw new ModelException(ModelExceptionType.NoUrlForDataSource);
            }

            if (Returns == null)
            {
                throw new ModelException(ModelExceptionType.NoReturnsForDataSource);
            }

            WebRequest request = new WebRequest(SourceUrl, WebMethod.Get);
            request.Authenticate = RequiresAuthentication;
            AddParameters(request);
            
            // Execute the request and check for errors in the response
            WebResponse webResponse = await this.webClient.ExecuteAsync(request);
            webResponse.Validate(System.Net.HttpStatusCode.OK, true);
            
            // Parse the content of the web request
            try
            {
                Response response = Parser.GetResponse(webResponse.Content);
                T item = Returns.Invoke(response);
                return item;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.StackTrace);
                throw new ModelException(ModelExceptionType.ParseError);
            }
        }

        private void AddParameters(WebRequest request)
        {
            request.Parameters["format"] = "xml";
            request.Parameters["key"] = AuthConfig.Default.ConsumerKey;

            foreach (var parameter in Parameters)
            {
                request.Parameters[parameter.Key] = parameter.Value;
            }
        }
    }
}
