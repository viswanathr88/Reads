using Epiphany.View.DesignData;
using Epiphany.ViewModel;
using System;

namespace Epiphany.View.Services
{
    sealed class DesignTimeViewModelLocator : IViewModelLocator
    {
        public IHomeViewModel Home
        {
            get { throw new NotImplementedException(); }
        }

        public ILogonViewModel Logon
        {
            get
            {
                return new DesignLogonViewModel();
            }
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
