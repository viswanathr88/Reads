using System;
using System.Collections.Generic;
using System.Text;

namespace Epiphany.Model.Web
{
    public enum WebMethod
    {
        Get,
        Post,
        Put,
        Delete,
        AuthenticatedGet,
        AuthenticatedPost,
        AuthenticatedPut,
        AuthenticatedDelete
    };

    public sealed class WebRequest
    {
        private readonly string url;
        private readonly IDictionary<string, object> headers;
        private WebMethod method;

        public WebRequest(string url, WebMethod method)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url", "url cannot be null");
            }

            this.url = url;
            this.method = method;
            this.headers = new Dictionary<string, object>();
        }

        public string Url
        {
            get
            {
                return this.url; 
            }
        }

        public IDictionary<string, object> Headers
        {
            get
            {
                return this.headers;
            }
        }

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

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format("URL={0}, Method={1}, Headers.Count={2}", Url, Method, Headers.Count));
            foreach (KeyValuePair<string, object> header in Headers)
            {
                builder.AppendLine(string.Format("Key={0}, Value={1}", header.Key, header.Value.ToString()));
            }

            return builder.ToString();
        }
    }
}
