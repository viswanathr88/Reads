using Epiphany.ViewModel.Services;
using System;

namespace Epiphany.ViewModel.Tests.Mock
{
    public class MockNavigationOperation<TViewModel> : INavigationOperation<TViewModel>
    {
        public INavigationOperation<TViewModel> AddParam<TValue>(System.Linq.Expressions.Expression<Func<TViewModel, TValue>> expr, TValue value)
        {
            return this;
        }

        public void Navigate()
        {
            
        }
    }
}
