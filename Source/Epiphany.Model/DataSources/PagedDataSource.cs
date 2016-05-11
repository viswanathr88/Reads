using Epiphany.Web;
using System.Threading.Tasks;

namespace Epiphany.Model.DataSources
{
    class PagedDataSource<T> : DataSource<T>, IPagedDataSource<T>
    {
        public PagedDataSource(IWebClient webClient) : base(webClient)
        {
            PerPageSupported = true;
        }

        public bool PerPageSupported
        {
            get;
            set;
        }

        public async Task<T> GetAsync(int page, int pageSize)
        {
            Parameters["page"] = page.ToString();

            if (PerPageSupported)
            {
                Parameters["per_page"] = pageSize.ToString();
            }

            return await GetAsync();
        }
    }
}
