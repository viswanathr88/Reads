using System;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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

#if WINDOWS_PHONE_APP
            Loaded += OnShellLoaded;
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += OnBackButtonPressed;
#endif
        }

        public Frame GetFrame()
        {
            return this.MainFrame;
        }

        private bool CloseMenuLeftPane()
        {
            bool result = false;

            if (this.hamburgerMenu != null && this.hamburgerMenu.IsLeftPaneOpen)
            {
                this.hamburgerMenu.IsLeftPaneOpen = false;
                result = true;
            }

            return result;
        }

        private void OnShellItemSelected(object sender, SelectionChangedEventArgs e)
        {
            CloseMenuLeftPane();
        }

#if WINDOWS_PHONE_APP
        private async void OnShellLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            StatusBar statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
            statusBar.BackgroundColor = ((SolidColorBrush)App.Current.Resources["PhoneChromeBrush"]).Color;
            statusBar.BackgroundOpacity = 1.0;

            await statusBar.ShowAsync();

        }

        private void OnBackButtonPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            if (this.hamburgerMenu != null && this.hamburgerMenu.IsLeftPaneOpen)
            {
                this.hamburgerMenu.IsLeftPaneOpen = false;
                e.Handled = true;
            }
        }
#endif

    }
}
