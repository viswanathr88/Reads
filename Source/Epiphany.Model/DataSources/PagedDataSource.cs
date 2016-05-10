using Epiphany.Web;
using System.Threading.Tasks;

namespace Epiphany.Model.DataSources
{
    class PagedDataSource<T> : DataSource<T>, IPagedDataSource<T>
    {
        public PagedDataSource(IWebClient webClient) : base(webClient)
        {

        }

        public async Task<T> GetAsync(int page, int pageSize)
        {
            Parameters["page"] = page.ToString();
            Parameters["per_page"] = pageSize.ToString();

            return await GetAsync();
        }
    }
}
