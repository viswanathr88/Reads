using System.Threading.Tasks;

namespace Epiphany.Model.Collections
{
    public interface IAsyncEnumerator<T>
    {
        /// <summary>
        /// Gets the current element in the collection.
        /// </summary>
        T Current
        {
            get;
        }
        /// <summary>
        /// Advances the enumerator to the next element of the collection asynchronously
        /// </summary>
        /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection</returns>
        Task<bool> MoveNext();
        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection
        /// </summary>
        void Reset();
    }
}
