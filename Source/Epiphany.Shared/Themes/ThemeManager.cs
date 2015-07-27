using Epiphany.Logging;
using Epiphany.Settings;
using System;
using Windows.UI.Xaml;

namespace Epiphany.Themes
{
    public sealed class ThemeManager
    {
        public void SetTheme(Theme theme)
        {
            Log.Instance.Info("Setting theme to " + theme);

            switch (theme)
            {
                case Theme.Default:
                    Log.Instance.Debug("Using system theme. Nothing to do here.");
                    break;

                case Theme.EpiphanyTheme:
                    LoadThemeInternal(new Uri("ms-appx:///Themes/EpiphanyTheme.xaml", UriKind.Absolute));
                    break;
                    
                case Theme.ReadsTheme:
                    LoadThemeInternal(new Uri("ms-appx:///Themes/ReadsTheme.xaml", UriKind.Absolute));
                    break;

                default:
                    Log.Instance.Warn("Not supported currently");
                    break;
            };
        }

        private void LoadThemeInternal(Uri uri)
        {
            try
            {
                var dictionary = new ResourceDictionary()
                {
                    Source = uri
                };

                App.Current.Resources.MergedDictionaries.Add(dictionary);
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex.Message + ex.StackTrace);
            }
        }
    }
}
