
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.Web
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

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("StatusCode = " + StatusCode);
            if (!string.IsNullOrEmpty(Content))
            {
                builder.AppendLine(Content);
            }

            return builder.ToString();
        }
    }
}
