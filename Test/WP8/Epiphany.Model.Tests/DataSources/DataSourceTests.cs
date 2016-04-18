using Epiphany.Model.DataSources;
using Epiphany.Web;
using Epiphany.Web;
using Epiphany.Xml;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace Epiphany.Model.Tests.DataSources
{
    [TestClass]
    public class DataSourceTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Dictionary<string, object> headers = new Dictionary<string,object>();
            string url = "www.google.com";
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                IDataSource<GoodreadsProfile> ds = new DataSource<GoodreadsProfile>(null, headers, url);
            });

            IWebClient webClient = new DataSourceWebClient(headers, "www.google.com", System.Net.HttpStatusCode.OK, string.Empty);

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                IDataSource<GoodreadsProfile> ds = new DataSource<GoodreadsProfile>(webClient, headers, string.Empty);
            });

            //
            // Should not throw even if headers is null
            //
            IDataSource<GoodreadsProfile> source = new DataSource<GoodreadsProfile>(webClient, null, "www.google.com");
        }

        [TestMethod]
        public async Task GetItemTest()
        {
            string url = "www.google.com";
            string fileUrl = "Input\\Profile.xml";
            Dictionary<string, object> headers = new Dictionary<string, object>();
            headers["foo"] = "bar";
            headers["id"] = 5;

            IWebClient webClient = new DataSourceWebClient(headers, url, System.Net.HttpStatusCode.OK, fileUrl);
            IDataSource<GoodreadsProfile> ds = new DataSource<GoodreadsProfile>(webClient, headers, url);
            GoodreadsProfile expected = await ds.GetAsync();

            Response response = await GetResponse(fileUrl);
            CompareLogic logic = new CompareLogic();
            ComparisonResult result = logic.Compare(expected, response.Profile);
            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }

        [TestMethod]
        public async Task GetItemForChildPropertyTest()
        {
            string url = "www.google.com";
            string fileUrl = "Input\\Author.xml";
            Dictionary<string, object> headers = new Dictionary<string, object>();
            headers["foo"] = "bar";
            headers["id"] = 5;

            IWebClient webClient = new DataSourceWebClient(headers, url, System.Net.HttpStatusCode.OK, fileUrl);
            IDataSource<GoodreadsBooks> ds = new DataSource<GoodreadsBooks>(webClient, headers, url);
            GoodreadsBooks expected = await ds.GetAsync();

            Response response = await GetResponse(fileUrl);
            CompareLogic logic = new CompareLogic();
            ComparisonResult result = logic.Compare(expected, response.Author.BookCollection);
            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }

        [TestMethod]
        public async Task BadHttpStatusCodeTest()
        {
            string url = "www.google.com";
            string fileUrl = "Input\\Author.xml";
            Dictionary<string, object> headers = new Dictionary<string, object>();
            headers["foo"] = "bar";
            headers["id"] = 5;

            //
            // Server unreachable
            //
            IWebClient webClient = new DataSourceWebClient(headers, url, System.Net.HttpStatusCode.NotFound, fileUrl);
            IDataSource<GoodreadsBooks> ds = new DataSource<GoodreadsBooks>(webClient, headers, url);
            var ex = await AssertHelper.ThrowsExceptionAsync<ModelException>(async () =>
            {
                await ds.GetAsync();
            });

            Assert.AreEqual(ex.Type, ModelExceptionType.ServerUnreachable);

            //
            // Unexpected response
            //
            webClient = new DataSourceWebClient(headers, url, System.Net.HttpStatusCode.PartialContent, fileUrl);
            ds = new DataSource<GoodreadsBooks>(webClient, headers, url);
            ex = await AssertHelper.ThrowsExceptionAsync<ModelException>(async () =>
            {
                await ds.GetAsync();
            });

            Assert.AreEqual(ex.Type, ModelExceptionType.UnexpectedError);

            //
            // Empty server response
            //
            webClient = new DataSourceWebClient(headers, url, System.Net.HttpStatusCode.OK, fileUrl, true);
            ds = new DataSource<GoodreadsBooks>(webClient, headers, url);
            ex = await AssertHelper.ThrowsExceptionAsync<ModelException>(async () =>
            {
                await ds.GetAsync();
            });

            Assert.AreEqual(ex.Type, ModelExceptionType.EmptyServerResponse);
        }

        private async Task<Response> GetResponse(string url)
        {
            var folder = Package.Current.InstalledLocation;

            using (Stream stream = await folder.OpenStreamForReadAsync(url))
            {
                return TestParser.ParseXml(stream);
            }
        }
    }

    class DataSourceWebClient : IWebClient
    {
        private readonly IDictionary<string, object> headers;
        private readonly string url;
        private System.Net.HttpStatusCode returnCode;
        private string fileUrl;
        private bool emptyResponse;

        public IAuthenticator Authenticator
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public DataSourceWebClient(IDictionary<string, object> headers, string url, System.Net.HttpStatusCode returnCode, string fileUrl, bool emptyResponse = false)
        {
            this.headers = headers;
            this.url = url;
            this.returnCode = returnCode;
            this.fileUrl = fileUrl;
            this.emptyResponse = emptyResponse;
        }

        public async Task<WebResponse> ExecuteAsync(WebRequest request)
        {
            Assert.IsNotNull(request);
            Assert.AreEqual(request.Method, WebMethod.Get, "WebMethod is not AuthenticatedGet");
            Assert.IsNotNull(request.Headers);
            Assert.AreEqual(request.Url, url);
            Assert.IsTrue(request.Headers.ContainsKey("format"));
            Assert.AreEqual(request.Headers["format"], "xml");

            foreach (KeyValuePair<string, object> header in this.headers)
            {
                Assert.IsTrue(request.Headers.ContainsKey(header.Key));
                Assert.AreEqual(request.Headers[header.Key], header.Value);
            }

            string xml = await FileReader.ReadFile(fileUrl);
            if (emptyResponse)
            {
                xml = string.Empty;
            }
            return new WebResponse(returnCode, xml);
        }
    }

}
