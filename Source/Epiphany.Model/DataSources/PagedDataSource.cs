using Epiphany.Web;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.Model.DataSources
{
    internal class PagedDataSource<T> : IPagedDataSource<T>
    {
        private readonly IDictionary<string, string> headers;
        private readonly IWebClient webClient;
        private readonly string url;

        public PagedDataSource(IWebClient webClient, IDictionary<string, string> headers, string url)
        {
            this.webClient = webClient;
            this.headers = headers;
            this.url = url;
        }

        public async Task<T> GetAsync(int page, int pageSize)
        {
            headers["page"] = page.ToString();
            headers["per_page"] = pageSize.ToString();

            IDataSource<T> ds = new DataSource<T>(webClient, headers, url);
            return await ds.GetAsync();
        }
    }
}
