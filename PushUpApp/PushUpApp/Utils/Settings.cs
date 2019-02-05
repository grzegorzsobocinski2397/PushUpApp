// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace PushUpApp
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string UserNameSettingsKey = "user_name";
        private const string NumberOfRepetitionsSettingsKey = "number_of_repetitions";
        private static readonly string SettingsDefault = string.Empty;

        #endregion

        /// <summary>
        /// User's name 
        /// </summary>
        public static string UserName
        {
            get => AppSettings.GetValueOrDefault(UserNameSettingsKey, SettingsDefault);
            set => AppSettings.AddOrUpdateValue(UserNameSettingsKey, value);
            
        }
        /// <summary>
        /// User's maximum number of repetitions
        /// </summary>
        public static string NumberOfRepetitions
        {
            get => AppSettings.GetValueOrDefault(NumberOfRepetitionsSettingsKey, SettingsDefault);
            set => AppSettings.AddOrUpdateValue(NumberOfRepetitionsSettingsKey, value);
        }

    }
}
