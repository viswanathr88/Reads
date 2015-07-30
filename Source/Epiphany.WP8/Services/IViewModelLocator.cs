using Epiphany.ViewModel;
using System;

namespace Epiphany.View.Services
{
    interface IViewModelLocator : IDisposable
    {
        IHomeViewModel Home
        {
            get;
        }

        ILogonViewModel Logon
        {
            get;
        }

        IAboutViewModel About
        {
            get;
        }
    }
}
