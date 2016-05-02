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
        private byte[] body;
        private string contentType;
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

            if (this.method == WebMethod.Post || this.method == WebMethod.Put)
            {
                this.contentType = "application/x-www-form-urlencoded";
            }
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

        public byte[] Body
        {
            get
            {
                UpdateBodyIfNeeded();
                return this.body;
            }
            set
            {
                if (this.body == value) return;
                this.body = value;
            }
        }

        public string ContentType
        {
            get
            {
                return this.contentType;
            }
        }

        private void UpdateBodyIfNeeded()
        {
            if (Method == WebMethod.Post || 
                Method == WebMethod.Put)
            {
                if (Parameters.Count > 0)
                {
                    string paramString = StringifyParameters();
                    this.body = System.Text.Encoding.UTF8.GetBytes(paramString);
                }
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
            if (Body != null && Body.Length > 0)
            {
                builder.AppendLine("Body = " + System.Text.Encoding.UTF8.GetString(Body, 0, Body.Length));
            }

            return builder.ToString();
        }

        private string GetUrl()
        {
            StringBuilder urlBuilder = new StringBuilder();
            urlBuilder.Append(this.url);

            if (Method != WebMethod.Post && Method != WebMethod.Put)
            {
                urlBuilder.Append("?");
                urlBuilder.Append(StringifyParameters());
            }
            return urlBuilder.ToString();
        }

        private string StringifyParameters()
        {
            StringBuilder parameterStringBuilder = new StringBuilder();
            int total = Parameters.Count;
            int count = 0;

            foreach (var parameter in Parameters)
            {
                parameterStringBuilder.Append(parameter.Key);
                parameterStringBuilder.Append("=");
                parameterStringBuilder.Append(parameter.Value);

                count++;
                if (count < total)
                {
                    parameterStringBuilder.Append("&");
                }
            }

            return parameterStringBuilder.ToString();
        }
    }
}
