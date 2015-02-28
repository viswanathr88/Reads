using Epiphany.Settings;
using Windows.Foundation.Collections;
using Windows.Storage;

namespace Epiphany.Settings
{
    sealed class SettingsStore : ISettingStorage
    {
        //
        // Private members
        //
        private readonly IPropertySet storage;
        private readonly object syncRoot = new object();
        private static volatile SettingsStore instance;

        private SettingsStore()
        {
            //
            // Constructor for creating a static instance
            //
            storage = ApplicationData.Current.RoamingSettings.Values;
        }

        public static SettingsStore Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SettingsStore();
                }

                return instance;
            }
        }

        public T GetValueOrDefault<T>(string key, T defaultValue)
        {
            T value = defaultValue;
            if (this.storage.ContainsKey(key))
            {
                value = (T)this.storage[key];
            }

            return value;
        }

        public bool AddOrUpdate(string key, object value)
        {
            lock (syncRoot)
            { 
                bool valueChanged = false;
                if (!this.storage.ContainsKey(key))
                {
                    this.storage.Add(key, value);
                    valueChanged = true;
                }
                else
                {
                    if (this.storage[key] != value)
                    {
                        this.storage[key] = value;
                        valueChanged = true;
                    }
                }

                return valueChanged;
            }
        }
    }
}
