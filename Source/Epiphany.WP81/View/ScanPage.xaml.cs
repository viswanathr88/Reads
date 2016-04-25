// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

using Epiphany.Logging;
using Epiphany.ViewModel;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace Epiphany.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScanPage : DataPage
    {
        public ScanPage()
        {
            this.InitializeComponent();
            Application.Current.Suspending += App_Suspending;
            Application.Current.Resuming += App_Resuming;
        }

        private async void App_Resuming(object sender, object e)
        {
            if (Frame.CurrentSourcePageType == typeof(ScanPage) && DataContext != null)
            {
                ScanViewModel vm = DataContext as ScanViewModel;

                if (vm != null)
                {
                    Logger.LogInfo("Resuming... Initialize Camera");
                    await vm.InitializeCameraAsync();
                }
            }
        }

        private void App_Suspending(object sender, Windows.ApplicationModel.SuspendingEventArgs e)
        {
            if (Frame.CurrentSourcePageType == typeof(ScanPage) && DataContext != null)
            {
                var deferral = e.SuspendingOperation.GetDeferral();

                ScanViewModel vm = DataContext as ScanViewModel;

                if (vm != null)
                {
                    Logger.LogInfo("Cleaning up camera resources");
                    vm.CleanupCamera();
                }

                deferral.Complete();
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            if (DataContext == null)
            {
                return;
            }

            ScanViewModel vm = DataContext as ScanViewModel;

            if (vm == null)
            {
                Logger.LogWarn("DataContext is not ScanViewModel");
                return;
            }

            Logger.LogInfo("Cleaning up camera resources");
            vm.CleanupCamera();
        }
    }
}
