using Epiphany.ViewModel;
using System;

namespace Epiphany.View.Services
{
    sealed class DesignTimeViewModelLocator : IViewModelLocator
    {
        public ILogonViewModel Logon
        {
            get { throw new NotImplementedException(); }
        }

        public AboutViewModel About
        {
            get { throw new NotImplementedException(); }
        }

        public void Dispose()
        {

        }
    }
}
