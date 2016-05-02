using System.Threading.Tasks;

namespace Epiphany.Web
{
    /// <summary>
    /// Extensions to web
    /// </summary>
    public static class WebExtensions
    {
        /// <summary>
        /// Gets the response async from System.Net.WebRequest
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Task<System.Net.WebResponse> GetResponseAsync(this System.Net.WebRequest request)
        {
            return Task.Factory.FromAsync<System.Net.WebResponse>(
                request.BeginGetResponse, request.EndGetResponse, null);
        }

        public static Task<System.IO.Stream> GetRequestStreamAsync(this System.Net.HttpWebRequest request)
        {
            return Task.Factory.FromAsync<System.IO.Stream>(
                request.BeginGetRequestStream, request.EndGetRequestStream, null);
        }
    }
}
