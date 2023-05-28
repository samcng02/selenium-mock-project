using System.Configuration;

namespace AutomationCore.Helpers
{
    /// <summary>
    /// Configuration support read data from file setting
    /// </summary>
    public class ConfigurationHelper
    {
        /// <summary>
        /// Get value from config file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetValue<T>(string key)
        {
            //Get key from config file:
            var value = ConfigurationManager.AppSettings[key];
            if (value is null)
            {
                return default(T);
            }
            return (T)Convert.ChangeType(value, typeof(T));

        }
    }
}
