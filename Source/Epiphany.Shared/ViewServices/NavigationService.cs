using Epiphany.ViewModel.Services;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Epiphany.View.Services
{
    class NavigationService : INavigationService
    {
        private readonly ViewLocator viewLocator;
        private Frame frame;

        public NavigationService()
        {
            this.viewLocator = new ViewLocator();
        }

        public async Task InitializeAsync(Frame frame)
        {
            if (frame == null)
            {
                throw new ArgumentNullException("frame");
            }

            this.frame = frame;
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
            if (param == null)
            {
                return;
            }

            Type viewType = this.viewLocator.GetViewType<TViewModel>();
            if (viewType == null)
            {
                return;
            }

            bool result = Frame.Navigate(viewType, param);
        }

        private Frame Frame
        {
            get
            {
                return this.frame;
            }
            set
            {
                if (this.frame == value) return;
                this.frame = value;
            }
        }
    }
}
