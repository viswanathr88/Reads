
using Epiphany.ViewModel;
using System;
namespace Epiphany.View
{
    public interface IViewLocator
    {
        Type GetViewType<TViewModel>();

        string GetViewKey<TViewModel>();

        string GetViewKey(Type viewType);

    }
}
