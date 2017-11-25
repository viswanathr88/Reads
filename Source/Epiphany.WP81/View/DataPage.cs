using Epiphany.Logging;
using Epiphany.View.Navigation;
using Epiphany.ViewModel;
using System;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Epiphany.View
{
    public class DataPage : Page
    {
        private readonly NavigationHelper navigationHelper;

        public DataPage()
        {
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += LoadState;
            this.navigationHelper.SaveState += SaveState;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            // Call navigation helper to restore state
            this.navigationHelper.OnNavigatedTo(e);

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

            RegisterPropertyChanged();

            Logger.LogInfo("Loading ViewModel for " + GetType().ToString());
            bool fReload = (e.NavigationMode == NavigationMode.New) || (e.NavigationMode == NavigationMode.Refresh);
            await vm.LoadAsync(e.Parameter, fReload);
            Logger.LogInfo($"Loading {GetType()} ViewModel completed");
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            this.navigationHelper.OnNavigatedFrom(e);
            Logger.LogDebug($"Navigating away from {GetType()}");
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

        protected virtual void LoadState(object sender, LoadStateEventArgs e)
        {
            Logger.LogDebug($"{GetType()}");
        }

        protected virtual void SaveState(object sender, SaveStateEventArgs e)
        {
            Logger.LogDebug($"{GetType()}");
        }
    }
}
