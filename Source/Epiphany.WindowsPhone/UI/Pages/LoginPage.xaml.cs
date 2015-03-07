using Epiphany.View.Attributes;
using Epiphany.ViewModel;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;

namespace Epiphany.UI.Pages
{
    [SourceModel(typeof(LogonViewModel))]
    /// <summary>
    /// Represents the Login Page
    /// </summary>
    public sealed partial class LoginPage : DataPage
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void OnNavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            LogonViewModel vm = (LogonViewModel)this.DataContext;
            if (vm.CheckUriForLoginCompletion.CanExecute(args.Uri))
            {
                vm.CheckUriForLoginCompletion.Execute(args.Uri);
            }
        }

        private void OnNavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            LogonViewModel vm = (LogonViewModel)this.DataContext;
            vm.SetIsLoading(false);
        }
    }
}
