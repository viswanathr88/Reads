
namespace Epiphany.Model.Settings
{
    /// <summary>
    /// Interface for a storage which stores settings
    /// </summary>
    public interface ISettingStorage
    {
        /// <summary>
        /// Gets the value of a setting. If not found, the default is returned
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">setting key</param>
        /// <param name="defaultValue">default value for the setting</param>
        /// <returns>T</returns>
        T GetValueOrDefault<T>(string key, T defaultValue);
        /// <summary>
        /// Adds a setting if it doesn't exist. If it does, then updates the setting
        /// </summary>
        /// <param name="key">setting key</param>
        /// <param name="value">setting value</param>
        /// <returns>True if something was added or updated, false otherwise</returns>
        bool AddOrUpdate(string key, object value);
    }
}
