
namespace Epiphany.Model.Collections
{
    /// <summary>
    /// Interface for an async enumerable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAsyncEnumerable<T> : INotifyCollectionReset
    {
        IAsyncEnumerator<T> GetEnumerator();
    }
}
