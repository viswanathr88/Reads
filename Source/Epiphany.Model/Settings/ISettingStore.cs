
namespace Epiphany.Model.Settings
{
    /// <summary>
    /// Interface for a storage which stores settings
    /// </summary>
    public interface ISettingStore
    {
        /// <summary>
        /// Gets the value of a setting. If not found, the default is returned
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setting">container</param>
        /// <param name="defaultValue">default value for the setting</param>
        /// <returns>T</returns>
        T GetValueOrDefault<T>(Setting setting, T defaultValue);
        /// <summary>
        /// Adds a setting if it doesn't exist. If it does, then updates the setting
        /// </summary>
        /// <param name="setting">container</param>
        /// <param name="value">setting value</param>
        /// <returns>True if something was added or updated, false otherwise</returns>
        bool AddOrUpdate(Setting setting, object value);
        /// <summary>
        /// Returns true if the setting is found in the container
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        bool Contains(Setting setting);
    }
}
