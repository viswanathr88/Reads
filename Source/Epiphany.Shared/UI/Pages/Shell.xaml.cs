using System;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Epiphany.UI.Pages
{
    /// <summary>
    /// Represents the Shell of the entire app
    /// </summary>
    public sealed partial class Shell : Page
    {
        public Shell()
        {
            this.InitializeComponent();

            Loaded += OnShellLoaded;
        }

        private async void OnShellLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
#if WINDOWS_PHONE_APP

            StatusBar statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
            statusBar.BackgroundColor = ((SolidColorBrush)App.Current.Resources["PhoneChromeBrush"]).Color;
            statusBar.BackgroundOpacity = 1.0;

            await statusBar.ShowAsync();

#endif
        }

        private void OnShellItemSelected(object sender, SelectionChangedEventArgs e)
        {
            this.hamburgerMenu.IsLeftPaneOpen = false;
        }
    }
}
