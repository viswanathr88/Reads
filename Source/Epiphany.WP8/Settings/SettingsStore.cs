using Epiphany.Model.Settings;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;

namespace Epiphany.Settings
{
    sealed class SettingsStore : ISettingStorage
    {
        //
        // Private members
        //
        private readonly IsolatedStorageSettings storage;
        private readonly object syncRoot = new object();
        private static volatile SettingsStore instance;

        private SettingsStore()
        {
            //
            // Constructor for creating a static instance
            //
            storage = IsolatedStorageSettings.ApplicationSettings;
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
            if (this.storage.Contains(key))
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
                if (!this.storage.Contains(key))
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
