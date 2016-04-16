using Epiphany.Logging;
using Epiphany.Model.Settings;
using System;
using Windows.Foundation.Collections;
using Windows.Storage;

namespace Epiphany.View.Services
{
    public class SettingStorage : ISettingStore
    {
        private readonly object syncRoot = new object();

        public bool AddOrUpdate(Setting setting, object value)
        {
            bool valueUpdated = false;

            lock (syncRoot)
            {
                try
                {
                    IPropertySet values = (setting.Container == SettingContainer.Local) ? ApplicationData.Current.LocalSettings.Values :
                        ApplicationData.Current.RoamingSettings.Values;

                    if (!values.ContainsKey(setting.Name) ||
                        values[setting.Name] != value)
                    {
                        values[setting.Name] = value;
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

        public bool Contains(Setting setting)
        {
            IPropertySet values = (setting.Container == SettingContainer.Local) ? ApplicationData.Current.LocalSettings.Values :
                        ApplicationData.Current.RoamingSettings.Values;

            return values.ContainsKey(setting.Name);
        }

        public T GetValueOrDefault<T>(Setting setting, T defaultValue)
        {
            T value = defaultValue;

            try
            {
                IPropertySet values = (setting.Container == SettingContainer.Local) ? ApplicationData.Current.LocalSettings.Values :
                        ApplicationData.Current.RoamingSettings.Values;

                if (values.ContainsKey(setting.Name))
                {
                    value = (T)values[setting.Name];
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
