
using System;
using System.Collections.Generic;

namespace Epiphany.ViewModel.Services
{
    /// <summary>
    /// Interface for the navigation service
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Gets the View-VM mapping
        /// </summary>
        IDictionary<Type, Type> Mapping
        {
            get;
        }
        /// <summary>
        /// Gets whether back navigation is possible
        /// </summary>
        bool CanGoBack
        {
            get;
        }
        /// <summary>
        /// Perform back navigation
        /// </summary>
        void GoBack();
        /// <summary>
        /// Perform back navigation as far as possible
        /// </summary>
        void GoBackAll();
        /// <summary>
        /// Create a navigation operation
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <returns></returns>
        INavigationOperation<TViewModel> CreateFor<TViewModel>() where TViewModel : IDataViewModel;
        /// <summary>
        /// Navigate to a uri
        /// </summary>
        /// <param name="uri"></param>
        void Navigate(string uri);
        /// <summary>
        /// Navigate to a VM using a parameter
        /// </summary>
        /// <typeparam name="TViewModel">type of ViewModel</typeparam>
        /// <param name="parameter">navigation parameter</param>
        void Navigate<TViewModel>(object parameter) where TViewModel : IDataViewModel;
    }
}
