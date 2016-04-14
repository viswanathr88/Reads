using Epiphany.ViewModel.Services;
using System;

namespace Epiphany.ViewModel.Tests.Mock
{
    public class MockNavigationService : INavigationService
    {
        public bool CanGoBack
        {
            get { throw new NotImplementedException(); }
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void GoBackAll()
        {
            throw new NotImplementedException();
        }

        public INavigationOperation<TViewModel> CreateFor<TViewModel>() where TViewModel : IDataViewModel
        {
            return new MockNavigationOperation<TViewModel>();
        }

        public void Navigate(string uri)
        {
            throw new NotImplementedException();
        }

        public void Navigate<TViewModel>(object parameter) where TViewModel : IDataViewModel
        {
            throw new NotImplementedException();
        }
    }
}
