using Epiphany.Common;
using Epiphany.View.Attributes;
using Epiphany.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using System;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Epiphany.UI.Pages
{
    [SourceModel(typeof(HomeViewModel))]
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : DataPage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
            statusBar.BackgroundColor = (App.Current.Resources["PageHeaderBackgroundBrush"] as SolidColorBrush).Color;
            statusBar.ForegroundColor = (App.Current.Resources["ApplicationForegroundThemeBrush"] as SolidColorBrush).Color;
            statusBar.BackgroundOpacity = 1.0;
            await statusBar.ShowAsync();
        }
    }
}
