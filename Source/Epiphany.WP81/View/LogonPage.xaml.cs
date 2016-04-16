using Epiphany.Logging;
using Epiphany.ViewModel;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Epiphany.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LogonPage : DataPage
    {
        public LogonPage()
        {
            this.InitializeComponent();
            RegisterDoneEvent();
        }

        protected override void OnViewModelDone(object sender, EventArgs e)
        {
            base.OnViewModelDone(sender, e);
            Logger.LogDebug("Navigating to HomePage");
            Frame.Navigate(typeof(HomePage));
        }

        private async void OnWebViewNavigationStarting(object sender, WebViewNavigationStartingEventArgs e)
        {
            Logger.LogDebug(e.Uri.ToString());
            LogonViewModel vm = DataContext as LogonViewModel;
            await vm.CheckUriAsync(e.Uri);
        }
    }
}
