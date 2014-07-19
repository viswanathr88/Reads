using Epiphany.Common;
using System.IO;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Epiphany.UI.Pages
{
    public abstract class DataPage : Page
    {
        private readonly NavigationHelper navigationHelper;

        public DataPage()
        {
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += OnLoadState;
            this.navigationHelper.SaveState += OnSaveState;
        }

        public NavigationHelper NavigationHelper
        {
            get
            {
                return this.navigationHelper;
            }
        }

        protected virtual void OnSaveState(object sender, SaveStateEventArgs e)
        {
            //
            // Nothing to do here
            //
        }

        protected virtual void OnLoadState(object sender, LoadStateEventArgs e)
        {

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
