using Epiphany.Logging;
using Epiphany.ViewModel;
using System;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Epiphany.View
{
    public class DataPage : Page
    {
        public DataPage()
        {
        }

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

            Logger.LogInfo("Loading ViewModel for " + GetType().ToString());
            bool fReload = (e.NavigationMode == NavigationMode.New) || (e.NavigationMode == NavigationMode.Refresh);
            await vm.LoadAsync(e.Parameter, fReload);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            if (e.NavigationMode == NavigationMode.Back)
            {
                if (DataContext == null)
                {
                    Logger.LogWarn("DataContext is null");
                    return;
                }

                IDisposable vm = DataContext as IDisposable;

                if (vm == null)
                {
                    Logger.LogWarn("VM does not implement IDisposable");
                    return;
                }

                Logger.LogInfo("Disposing ViewModel for " + GetType().ToString());
                vm.Dispose();
            }
        }

        protected T GetViewModel<T>()
        {
            T vm = default(T);
            if (DataContext != null && DataContext is T)
            {
                vm = (T)DataContext;
            }

            return vm;
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

        protected void RegisterPropertyChanged()
        {
            IDataViewModel vm = DataContext as IDataViewModel;
            if (vm == null)
            {
                Logger.LogError("DataContext does not implement IDataViewModel");
                return;
            }
            vm.PropertyChanged += OnViewModelPropertyChanged;
        }

        protected virtual void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Nothing to do here
        }

        protected virtual void OnViewModelDone(object sender, EventArgs e)
        {
            // Nothing to do here
        }
    }
}
