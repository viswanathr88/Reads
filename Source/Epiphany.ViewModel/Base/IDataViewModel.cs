
using System;
using System.ComponentModel;
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

        void Load();

        object Error
        {
            get;
        }
    }
}
