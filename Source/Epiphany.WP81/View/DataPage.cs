using Epiphany.Logging;
using Epiphany.ViewModel;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Epiphany.View
{
    public class DataPage : Page
    {
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (DataContext == null)
            {
                Logger.LogError("DataPage cannot have a null DataContext");
                return;
            }

            IDataViewModel vm = DataContext as IDataViewModel;
            if (vm == null)
            {
                Logger.LogError("DataContext does not implement IDataViewModel");
                return;
            }

            await vm.LoadAsync(e.Parameter);
            Logger.LogDebug("LoadAsync returned");
        }

        protected void RegisterDoneEvent()
        {
            IDataViewModel vm = DataContext as IDataViewModel;
            if (vm == null)
            {
                Logger.LogError("DataContext does not implement IDataViewModel");
                return;
            }

            vm.Done += OnViewModelDone;
        }

        protected virtual void OnViewModelDone(object sender, EventArgs e)
        {
            // Nothing to do here
        }
    }
}
