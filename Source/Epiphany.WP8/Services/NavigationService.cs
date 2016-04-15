using Epiphany.ViewModel;
using Epiphany.ViewModel.Services;
using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Collections.Generic;

namespace Epiphany.View.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IViewLocator viewLocator;

        public NavigationService()
        {
            this.viewLocator = new ViewLocator();
        }

        public bool CanGoBack
        {
            get { return Frame.CanGoBack; }
        }

        public void GoBack()
        {
            Frame.GoBack();
        }

        public void GoBackAll()
        {
            while (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        public void Navigate(string uri)
        {
            Frame.Navigate(new Uri(uri, UriKind.Relative));
        }

        public INavigationOperation<TViewModel> CreateFor<TViewModel>() where TViewModel : IDataViewModel
        {
            INavigationOperation<TViewModel> operation = new NavigationOperation<TViewModel>(this, this.viewLocator);
            return operation;
        }

        public void Navigate<TViewModel>(object parameter) where TViewModel : IDataViewModel
        {
            throw new NotImplementedException();
        }

        private PhoneApplicationFrame Frame
        {
            get
            {
                return Application.Current.RootVisual as PhoneApplicationFrame;
            }
        }

        public IDictionary<Type, Type> Mapping
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
