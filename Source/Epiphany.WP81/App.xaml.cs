﻿using Epiphany.Logging;
using Epiphany.View;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Media.SpeechRecognition;
using Windows.Phone.UI.Input;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Epiphany.WP81
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : Application
    {
        private TransitionCollection transitions;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected async override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                // TODO: change this value to a cache size that is appropriate for your application
                rootFrame.CacheSize = 5;

                // Set the default language
                rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
                Window.Current.Activated += Window_Activated;
            }

            if (rootFrame.Content == null)
            {
                // Removes the turnstile navigation for startup.
                if (rootFrame.ContentTransitions != null)
                {
                    this.transitions = new TransitionCollection();
                    foreach (var c in rootFrame.ContentTransitions)
                    {
                        this.transitions.Add(c);
                    }
                }

                rootFrame.ContentTransitions = this.transitions ?? new TransitionCollection();

                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainPage), e.Arguments, new ContinuumNavigationTransitionInfo()))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

            // Install Voice commands
            if (!await InitializeVoiceCommands())
            {
                Logger.LogError("Failed to initialize voice commands");
            }

            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Callback when the current window is activated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Window_Activated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
        {
            var statusBar = StatusBar.GetForCurrentView();
            statusBar.BackgroundColor = (App.Current.Resources["PhoneChromeBrush"] as SolidColorBrush).Color;
            statusBar.ForegroundColor = (App.Current.Resources["ApplicationForegroundThemeBrush"] as SolidColorBrush).Color;
            statusBar.BackgroundOpacity = 1;
            statusBar.ProgressIndicator.ProgressValue = 1;
            await statusBar.ShowAsync();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            // TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        private async Task<bool> InitializeVoiceCommands()
        {
            bool commandSetsInstalled = true;

            try
            {
                Uri vcdUri = new Uri("ms-appx:///VoiceCommands.xml", UriKind.Absolute);

                //load the VCD file from local storage 
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(vcdUri);

                //register the voice command definitions        
                await VoiceCommandManager.InstallCommandSetsFromStorageFileAsync(file);

            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                //voice command file not found or language not supported or file is 
                //invalid format (missing stuff), or capabilities not selected, etc etc
                commandSetsInstalled = false;
            }


            return commandSetsInstalled;
        }
        /// <summary>
        /// Navigation related methods
        /// </summary>
        /// <param name="page"></param>
        /// <param name="parameter"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public static async Task Navigate(Type page, object parameter, NavigationTransitionInfo info)
        {
            Frame frame = Window.Current.Content as Frame;

            if (frame == null)
            {
                Logger.LogError("Frame is null. Navigation failed");
                return;
            }

            if (info != null)
            {
                await Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => frame.Navigate(page, parameter, info));
            }
            else
            {
                await Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => frame.Navigate(page, parameter));
            }
        }

        public static async Task Navigate(Type page, object parameter)
        {
            await App.Navigate(page, parameter, null);
        }
    }
}