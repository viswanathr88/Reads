using System;
using System.Linq.Expressions;

namespace Epiphany.ViewModel.Services
{
    public interface INavigationOperation<TViewModel>
    {
        INavigationOperation<TViewModel> AddParam<TValue>(Expression<Func<TViewModel, TValue>> expr, TValue value);

        void Navigate();
    }
}
