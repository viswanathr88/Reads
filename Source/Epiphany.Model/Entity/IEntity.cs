
namespace Epiphany.Model
{
    /// <summary>
    /// An interface that every entity should implement
    /// </summary>
    public interface IEntity
    {
        object Id
        {
            get;
        }
    }

    /// <summary>
    /// Generic version
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntity<TKey> : IEntity
    {
        new TKey Id
        {
            get;
        }
    }
}
