using System.Threading.Tasks;

namespace Epiphany.Model.Web
{
    /// <summary>
    /// Represents a web client with async calls
    /// </summary>
    public interface IWebClient
    {
        Task<WebResponse> ExecuteAsync(WebRequest request);
    }
}
