using Epiphany.Common;
using Epiphany.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Epiphany.UI.Pages
{
    public class DataPage : Page
    {
        private NavigationHelper navigationHelper;

        public DataPage()
        {
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.OnLoadState;
            this.navigationHelper.SaveState += this.OnSaveState;
        }

        protected void OnLoadState(object sender, LoadStateEventArgs e)
        {
            if (this.DataContext == null)
            {
                // Error
                return;
            }

            IDataViewModel vm = (IDataViewModel)(this.DataContext);
            vm.Load(e.NavigationParameter);
        }

        protected void OnSaveState(object sender, SaveStateEventArgs e)
        {
            // Nothing to do here
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }
    }
}
