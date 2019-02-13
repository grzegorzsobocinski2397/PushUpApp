// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

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
        // User name
        private const string UserNameSettingsKey = "UserName";
        private static readonly string UserNameDefault = string.Empty;
        // Number of repetitions
        private const string NumberOfRepetitionsSettingsKey = "NumberOfRepetitions";
        private static readonly int NumberOfRepetitionsDefault = default(int);
        // Next workout date
        private const string NextWorkoutDateSettingsKey = "NextWorkout";
        private static readonly DateTime NextWorkoutDateDefault = default(DateTime);
        
        #endregion

        /// <summary>
        /// User's name 
        /// </summary>
        public static string UserName
        {
            get => AppSettings.GetValueOrDefault(UserNameSettingsKey, UserNameDefault);
            set => AppSettings.AddOrUpdateValue(UserNameSettingsKey, value);
            
        }
        /// <summary>
        /// User's maximum number of repetitions
        /// </summary>
        public static int NumberOfRepetitions
        {
            get => AppSettings.GetValueOrDefault(NumberOfRepetitionsSettingsKey, NumberOfRepetitionsDefault);
            set => AppSettings.AddOrUpdateValue(NumberOfRepetitionsSettingsKey, value);
        }
        /// <summary>
        /// Next workout date 
        /// </summary>
        public static DateTime NextWorkoutDate
        {
            get => AppSettings.GetValueOrDefault(NextWorkoutDateSettingsKey, NextWorkoutDateDefault);
            set => AppSettings.AddOrUpdateValue(NextWorkoutDateSettingsKey, value);
        }

    }
}
