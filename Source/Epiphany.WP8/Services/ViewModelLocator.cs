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

        public IHomeViewModel Home
        {
            get
            {
                return this.locatorImpl.Home;
            }
        }

        public IAboutViewModel About
        {
            get
            {
                return this.locatorImpl.About;
            }
        }


        public IAddBookViewModel AddBook
        {
            get
            {
                return this.locatorImpl.AddBook;
            }
        }

        public void Dispose()
        {
            locatorImpl.Dispose();
        }
    }
}
