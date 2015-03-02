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

        private void WebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            Debug.WriteLine("Navigation Starting");
            Debug.WriteLine("Uri = {0}", args.Uri);

            LogonViewModel vm = (LogonViewModel)this.DataContext;
            if (vm.CheckUriForLoginCompletion.CanExecute(args.Uri))
            {
                vm.CheckUriForLoginCompletion.Execute(args.Uri);
            }
        }

        private void WebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            Debug.WriteLine("Navigation Completed");
            Debug.WriteLine("IsSuccess = {0}, Uri = {1}, WebErrorStatus = {2}", args.IsSuccess, args.Uri, args.WebErrorStatus);
        }
    }
}
