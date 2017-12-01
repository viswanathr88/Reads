using System;
using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI.Xaml.Data;

namespace Epiphany.ViewModel.Collections
{
    /// <summary>
    /// Represents an interface to lazy load a collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILazyObservableCollection<T> : IList<T>,  ISupportIncrementalLoading, INotifyPropertyChanged
    {
        /// </summary>
        bool IsLoading
        {
            get;
        }
        /// <summary>
        /// Gets the latest error while loading
        /// </summary>
        Exception Error
        {
            get;
        }
    }
}
