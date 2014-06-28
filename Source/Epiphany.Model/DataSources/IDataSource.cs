using System.Threading.Tasks;

namespace Epiphany.Model.DataSources
{
    interface IDataSource<T>
    {
        Task<T> GetAsync();
    }
}
