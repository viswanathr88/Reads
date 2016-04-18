using System.Threading.Tasks;

namespace Epiphany.Web
{
    /// <summary>
    /// Represents a web client interface that executes a web request
    /// </summary>
    public interface IWebClient
    {
        /// <summary>
        /// Execute the request asynchronously
        /// </summary>
        /// <param name="request">Web request to execute</param>
        /// <returns></returns>
        Task<WebResponse> ExecuteAsync(WebRequest request);
    }
}
