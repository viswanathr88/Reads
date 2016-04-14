using Epiphany.ViewModel;
using Epiphany.ViewModel.Services;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Epiphany.View.Services
{
    public sealed class NavigationService : INavigationService
    {
        private readonly IDictionary<Type, Type> mapping;
        public NavigationService()
        {
            this.mapping = new Dictionary<Type, Type>();
        }

        public IDictionary<Type, Type> Mapping
        {
            get
            {
                return this.mapping;
            }
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
            throw new NotImplementedException();
        }

        public INavigationOperation<TViewModel> CreateFor<TViewModel>() where TViewModel : IDataViewModel
        {
            throw new NotImplementedException();
        }

        public void Navigate<TViewModel>(object parameter) where TViewModel : IDataViewModel
        {
            Type vmType = typeof(TViewModel);

            if (!Mapping.ContainsKey(vmType))
            {
                throw new NotSupportedException(vmType.ToString());
            }

            Frame.Navigate(Mapping[vmType], parameter);
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
