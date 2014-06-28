using System.Threading.Tasks;

namespace Epiphany.Model.DataSources
{
    interface IPagedDataSource<T>
    {
        Task<T> GetAsync(int page, int pageSize);
    }
}
