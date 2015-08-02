
using System;
using System.ComponentModel;
using System.Threading.Tasks;
namespace Epiphany.ViewModel
{
    /// <summary>
    /// Represents an interface that every data viewmodel will implement
    /// </summary>
    public interface IDataViewModel : INotifyPropertyChanged, IDisposable
    {
        bool IsLoading
        {
            get;
        }

        bool IsLoaded
        {
            get;
        }

        Task LoadAsync();

        object Error
        {
            get;
        }
    }
}
