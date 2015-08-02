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

        IAddBookViewModel AddBook
        {
            get;
        }

        IAboutViewModel About
        {
            get;
        }

        IProfileViewModel Profile
        {
            get;
        }
    }
}
