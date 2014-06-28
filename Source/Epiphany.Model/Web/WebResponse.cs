
using System.Net;
namespace Epiphany.Model.Web
{
    /// <summary>
    /// Interface for author WebResponse
    /// </summary>
    public sealed class WebResponse
    {
        private readonly HttpStatusCode code;
        private readonly string content;

        public WebResponse(HttpStatusCode code, string content)
        {
            this.code = code;
            this.content = content;
        }
        /// <summary>
        /// Gets the Status code of the response
        /// </summary>
        public HttpStatusCode StatusCode
        {
            get
            {
                return this.code;
            }
        }
        /// <summary>
        /// Gets the content
        /// </summary>
        public string Content
        {
            get
            {
                return this.content;
            }
        }
    }
}
