using Epiphany.ViewModel;
using System;

namespace Epiphany.View.Services
{
    interface IViewModelLocator : IDisposable
    {
        LogonViewModel Logon
        {
            get;
        }

        AboutViewModel About
        {
            get;
        }
    }
}
