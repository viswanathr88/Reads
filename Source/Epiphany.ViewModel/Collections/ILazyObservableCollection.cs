using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Data;

namespace Epiphany.ViewModel.Collections
{
    /// <summary>
    /// Represents an interface to lazy load a collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILazyObservableCollection<T> : IList<T>,  ISupportIncrementalLoading
    {
        /// <summary>
        /// Event when the list is loading
        /// </summary>
        event EventHandler<EventArgs> Loading;
        /// <summary>
        /// Event when the list has loaded
        /// </summary>
        event EventHandler<LoadedEventArgs> Loaded;
        /// <summary>
        /// Gets whether the list is loading
        /// </summary>
        bool IsLoading
        {
            get;
        }
    }
}
