using Epiphany.Logging;
using Epiphany.Web;
using Epiphany.Xml;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Epiphany.Model.DataSources
{
    internal class DataSource<T> : IDataSource<T>
    {
        private readonly IDictionary<string, object> headers;
        private readonly IWebClient webClient;
        private readonly string url;

        public DataSource(IWebClient webClient, IDictionary<string, object> headers, string url)
        {
            if (webClient == null || string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException();
            }

            this.headers = headers;
            this.webClient = webClient;
            this.url = url;
        }

        public async Task<T> GetAsync()
        {
            WebRequest request = new WebRequest(url, WebMethod.Get);
            AddHeaders(request);
            //
            // Execute the request and check for errors in the response
            //
            WebResponse webResponse = await this.webClient.ExecuteAsync(request);
            webResponse.Validate(System.Net.HttpStatusCode.OK, true);
            //
            // Parse the content of the web request
            //
            try
            {
                Response response = Parser.GetResponse(webResponse.Content);
                T item = GetItem(response);
                return item;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.StackTrace);
                throw new ModelException(ModelExceptionType.ParseError);
            }
        }

        private void AddHeaders(WebRequest request)
        {
            request.Headers["format"] = "xml";
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    //TODO: request.Headers.Add(header);
                }
            }
        }

        private T GetItem(object source)
        {
            T item = default(T);
            if (source == null)
            {
                return item;
            }

            //
            // Loop through all the properties
            //
            foreach (PropertyInfo property in source.GetType().GetRuntimeProperties())
            {
                object value = null;
                try
                {
                    value = property.GetValue(source, null);
                }
                catch (Exception)
                {
                    continue;
                }

                if (value != null && property.PropertyType != typeof(Request))
                {
                    //
                    // Found a non-null property
                    //
                    if (property.PropertyType == typeof(T))
                    {
                        //
                        // Type matches! Get the value and break
                        //
                        item = (T)value;
                        break;
                    }
                    else
                    {
                        //
                        // Type did not match! Look for a type match recursively
                        //
                        item = GetItem(value);
                    }
                }
            }
            return item;
        }
    }
}
