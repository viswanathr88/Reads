using Epiphany.ViewModel.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Epiphany.View.Services
{
    class NavigationService : INavigationService
    {
        private readonly ViewLocator viewLocator;

        public NavigationService()
        {
            this.viewLocator = new ViewLocator();
        }

        public async Task InitializeAsync()
        {
            await this.viewLocator.LoadViewsAsync();
        }
        public bool CanGoBack
        {
            get
            {
                return Frame.CanGoBack;
            }
        }

        public void GoBack()
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        public void GoBackAll()
        {
            while(Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        public void Navigate<TViewModel, TParam>(TParam param) where TViewModel : ViewModel.DataViewModel<TParam>
        {
            Debug.Assert(param != null);
            if (param == null)
            {
                return;
            }

            Type viewType = this.viewLocator.GetViewType<TViewModel>();
            Debug.Assert(viewType != null);
            if (viewType == null)
            {
                return;
            }

            bool result = Frame.Navigate(viewType, param);
            Debug.Assert(result, "Frame.Navigate failed");
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
