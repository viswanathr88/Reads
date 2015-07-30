using Epiphany.ViewModel;
using System;

namespace Epiphany.View.Services
{
    interface IViewModelLocator : IDisposable
    {
        ILogonViewModel Logon
        {
            get;
        }

        AboutViewModel About
        {
            get;
        }
    }
}
