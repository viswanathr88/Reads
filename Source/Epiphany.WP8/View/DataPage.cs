using Epiphany.Logging;
using Epiphany.ViewModel;
using Microsoft.Phone.Controls;
using System.Collections.Generic;
using System.Windows.Navigation;

namespace Epiphany.View
{
    public class DataPage : PhoneApplicationPage
    {
        public DataPage()
            : base()
        {
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (this.DataContext == null)
            {
                Logger.LogError("There is no DataContext set on the View");
                return;
            }

            ViewModelBase vm = this.DataContext as ViewModelBase;
            if (vm == null)
            {
                Logger.LogError("DataContext does not implement ViewModelBase");
                return;
            }

            foreach (KeyValuePair<string, string> param in NavigationContext.QueryString)
            {
                vm.SetValue(param.Key, param.Value);
            }

            IDataViewModel dataVM = vm as IDataViewModel;
            if (dataVM == null)
            {
                Logger.LogError("VM does not implement IDataViewModel");
                return;
            }

            await dataVM.LoadAsync(VoidType.Empty);
        }

        protected override void OnRemovedFromJournal(JournalEntryRemovedEventArgs e)
        {
            base.OnRemovedFromJournal(e);

            if (this.DataContext != null)
            {
                ViewModelBase vm = this.DataContext as ViewModelBase;
                vm.Dispose();
                this.DataContext = null;
            }
        }
    }
}
