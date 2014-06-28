using System;
using System.Collections.Generic;

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
    }
}
