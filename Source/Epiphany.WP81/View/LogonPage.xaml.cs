using Epiphany.Logging;
using Epiphany.ViewModel;
using System.ComponentModel;
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

            // Register for property changed events from the ViewModel
            RegisterPropertyChanged();
        }

        protected override void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnViewModelPropertyChanged(sender, e);

            if (e.PropertyName == nameof(ILogonViewModel.IsLoginCompleted))
            {
                Logger.LogDebug("Navigating Back");

                if (Frame.CanGoBack)
                {
                    Frame.GoBack();
                }
            }
        }

        private async void OnWebViewNavigationStarting(object sender, WebViewNavigationStartingEventArgs e)
        {
            Logger.LogDebug(e.Uri.ToString());
            LogonViewModel vm = DataContext as LogonViewModel;
            await vm.CheckUriAsync(e.Uri);
        }
    }
}
