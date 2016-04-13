using Epiphany.ViewModel;
using Epiphany.ViewModel.Services;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            throw new NotSupportedException();
        }

        public INavigationOperation<TViewModel> CreateFor<TViewModel>() where TViewModel : IDataViewModel
        {
            INavigationOperation<TViewModel> operation = new NavigationOperation<TViewModel>(this, this.viewLocator);
            return operation;
        }

        private Frame Frame
        {
            get
            {
                return Window.Current.Content as Frame;
            }
        }
    }
}
