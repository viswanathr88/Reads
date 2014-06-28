
namespace Epiphany.ViewModel
{
    public interface IDisposer
    {
        void Dispose<T>(T item);
    }
}
