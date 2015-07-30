using Epiphany.ViewModel;
using System;

namespace Epiphany.View.Services
{
    sealed class RuntimeViewModelLocator : IViewModelLocator
    {
        public IHomeViewModel Home
        {
            get { throw new NotImplementedException(); }
        }

        public ILogonViewModel Logon
        {
            get { throw new NotImplementedException(); }
        }

        public IAboutViewModel About
        {
            get { throw new NotImplementedException(); }
        }

        public void Dispose()
        {
            
        }
    }
}
