using LSports.STM.SampleApp.Common.Exceptions;
using System.Configuration;

namespace LSports.STM.SampleApp.Common.Configurations
{
    public class ConfigurationHelper
    {
        public static string GetValue(string key)
        {
            string value = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(value))
                throw new MissingKeyInConfigurationException($"The key '{key}' was missing in Application Configuration");

            return value;
        }

        public static string GetValueOrDefault(string key, string defValue)
        {
            string value = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(value))
                return defValue;

            return value;
        }

        public static int GetIntValue(string key)
        {
            string value = GetValue(key);
            int intValue;
            if (!int.TryParse(value, out intValue))
                throw new UnexpectedValueTypeException($"Expected integer value under key '{key}' but value was: '{value}'");
            return intValue;
        }
    }
}
