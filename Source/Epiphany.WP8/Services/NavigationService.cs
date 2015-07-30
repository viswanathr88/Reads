using Epiphany.ViewModel;
using Epiphany.ViewModel.Services;
using Microsoft.Phone.Controls;
using System;
using System.Windows;

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

        public INavigationOperation<TViewModel> CreateFor<TViewModel>() where TViewModel : ViewModelBase
        {
            INavigationOperation<TViewModel> operation = new NavigationOperation<TViewModel>(this, this.viewLocator);
            return operation;
        }

        private PhoneApplicationFrame Frame
        {
            get
            {
                return Application.Current.RootVisual as PhoneApplicationFrame;
            }
        }
    }
}
