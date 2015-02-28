
using System;
namespace Epiphany.View.Services
{
    public interface IViewLocator
    {
        Type GetViewType<TViewModel>();

        string GetViewKey<TViewModel>();

        string GetViewKey(Type viewType);

    }
}
