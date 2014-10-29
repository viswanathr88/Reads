
namespace Epiphany.ViewModel
{
    /// <summary>
    /// Represents an interface that every data viewmodel will implement
    /// </summary>
    public interface IDataViewModel
    {
        void Load(object param);
    }

    /// <summary>
    /// Represents a templated version of IDataViewModel
    /// </summary>
    /// <typeparam name="TParam"></typeparam>
    public interface IDataViewModel<TParam>
    {
        void Load(TParam param);
    }
}
