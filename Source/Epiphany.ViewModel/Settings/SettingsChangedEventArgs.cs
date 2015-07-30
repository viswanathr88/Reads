using System;

namespace Epiphany.ViewModel
{
    public class SettingsChangedEventArgs : EventArgs
    {
        private readonly string settingName;

        public SettingsChangedEventArgs(string settingName)
        {
            this.settingName = settingName;
        }

        public string SettingName
        {
            get
            {
                return this.settingName;
            }
        }
    }
}
