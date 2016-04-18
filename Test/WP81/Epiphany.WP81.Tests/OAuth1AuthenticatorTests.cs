using Epiphany.Web;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Epiphany.WP81.Tests
{
    [TestClass]
    public class OAuth1AuthenticatorTests
    {
        string consumerKey = "fDfi6rdiIgfTp49R0xj8MQ";
        string consumerKeySecret = "xWMNPMCpx7Xu6SRa794vP8BZ1d9muqNVsYnCucPiQ";

        [TestMethod]
        public async Task RequestTokenTest()
        {
            // TODO: Pass OAuth factory
            WebClient client = new WebClient(null);

            WebRequest request = new WebRequest(@"http://www.goodreads.com/oauth/request_token", WebMethod.Get);
            request.Authenticate = true;
            request.Parameters.Add("format", "xml");
            request.Parameters.Add("zIndex", "1");

            WebResponse response = await client.ExecuteAsync(request);

            Debug.WriteLine(response.Content);
        }
    }
}
