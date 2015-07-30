using Epiphany.ViewModel;

namespace Epiphany.View.Services
{
    sealed class ViewModelLocator : IViewModelLocator
    {
        private readonly IViewModelLocator locatorImpl;

        public ViewModelLocator()
        {
            if (System.ComponentModel.DesignerProperties.IsInDesignTool)
            {
                // Use the DesignViewModelLocator for blendability
                this.locatorImpl = new DesignTimeViewModelLocator();
            }
            else
            {
                // Use the RuntimeViewModelLocator
                this.locatorImpl = new RuntimeViewModelLocator();
            }

        }

        public ILogonViewModel Logon
        {
            get
            {
                return this.locatorImpl.Logon;
            }
        }

        public AboutViewModel About
        {
            get
            {
                return this.locatorImpl.About;
            }
        }

        public void Dispose()
        {
            locatorImpl.Dispose();
        }
    }
}
