using System;
using System.Collections.Generic;
using System.Text;

namespace Epiphany.Web
{
    public enum WebMethod
    {
        Get,
        Post,
        Put,
        Delete
    };
    /// <summary>
    /// Represents a web request to be used with a IWebClient
    /// </summary>
    public sealed class WebRequest
    {
        private readonly string url;
        private readonly IDictionary<string, string> headers;
        private readonly IDictionary<string, string> parameters;
        private WebMethod method;
        /// <summary>
        /// Create an instance of WebRequest
        /// </summary>
        /// <param name="url">request url</param>
        /// <param name="method">web method</param>
        public WebRequest(string url, WebMethod method)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url", "url cannot be null");
            }

            this.url = url;
            this.method = method;
            this.parameters = new Dictionary<string, string>();
            this.headers = new Dictionary<string, string>();
        }
        /// <summary>
        /// Gets the request url
        /// </summary>
        public string Url
        {
            get
            {
                return GetUrl();
            }
        }
        /// <summary>
        /// Gets or sets whether the request should be authenticated
        /// </summary>
        public bool Authenticate
        {
            get;
            set;
        }
        /// <summary>
        /// Gets the request headers
        /// </summary>
        public IDictionary<string, string> Headers
        {
            get
            {
                return this.headers;
            }
        }
        /// <summary>
        /// Gets the parameters for the request
        /// </summary>
        public IDictionary<string, string> Parameters
        {
            get
            {
                return this.parameters;
            }
        }
        /// <summary>
        /// Gets the request method
        /// </summary>
        public WebMethod Method
        {
            get
            {
                return this.method;
            }
            set
            {
                this.method = value;
            }
        }
        /// <summary>
        /// Gets the request information
        /// </summary>
        /// <returns>request info as string</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format("URL={0}, Method={1}, Headers.Count={2}", Url, Method, Headers.Count));
            foreach (var header in Headers)
            {
                builder.AppendLine(string.Format("Key={0}, Value={1}", header.Key, header.Value));
            }

            return builder.ToString();
        }

        private string GetUrl()
        {
            StringBuilder urlBuilder = new StringBuilder();
            urlBuilder.Append(this.url);
            urlBuilder.Append("?");

            int total = Parameters.Count;
            int count = 0;

            foreach (var parameter in Parameters)
            {
                urlBuilder.Append(parameter.Key);
                urlBuilder.Append("=");
                urlBuilder.Append(parameter.Value);

                count++;
                if (count < total)
                {
                    urlBuilder.Append("&");
                }
            }
            return urlBuilder.ToString();
        }
    }
}
