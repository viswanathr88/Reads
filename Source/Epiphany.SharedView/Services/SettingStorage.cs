using Epiphany.Logging;
using Epiphany.Model.Settings;
using System;
using Windows.Storage;

namespace Epiphany.View.Services
{
    public class SettingStorage : ISettingStorage
    {
        private readonly object syncRoot = new object();

        public bool AddOrUpdate(string key, object value)
        {
            bool valueUpdated = false;

            lock (syncRoot)
            {
                try
                {
                    if (!ApplicationData.Current.LocalSettings.Values.ContainsKey(key) ||
                        ApplicationData.Current.LocalSettings.Values[key] != value)
                    {
                        ApplicationData.Current.LocalSettings.Values[key] = value;
                        valueUpdated = true;
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                    valueUpdated = false;
                }
            }

            return valueUpdated;
        }

        public T GetValueOrDefault<T>(string key, T defaultValue)
        {
            T value = defaultValue;

            try
            {
                if (ApplicationData.Current.LocalSettings.Values.ContainsKey(key))
                {
                    value = (T)ApplicationData.Current.LocalSettings.Values[key];
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                value = defaultValue; // Just in case, reset it to defaultValue
            }
            return value;
        }
    }
}
