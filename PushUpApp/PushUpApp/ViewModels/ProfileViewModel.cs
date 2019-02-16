using System;

namespace PushUpApp
{
    /// <summary>
    /// View model used in both <see cref="RegisterPage"/> and <see cref="SettingsPage"/>
    /// because it serves the same functionality but on the different page views. 
    /// </summary>
    public class ProfileViewModel : BaseViewModel
    {
        #region Public Properties
        /// <summary>
        /// User name that will be remember throughout the application 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// User's maximum number of repetitions  
        /// </summary>
        public string NumberOfRepetitions { get; set; }
        #endregion
        #region Commands
        /// <summary>
        /// Changes the page to <see cref="WorkoutPage"/>
        /// </summary>
        public RelayCommand SaveCommand { get; set; }
        #endregion
        #region Constructor
        public ProfileViewModel()
        {
            // Creates commands 
            SaveCommand = new RelayCommand(() => SaveUserChanges());
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Registers user name in Settings class so it will be remembered 
        /// </summary>
        private void SaveUserChanges()
        {
            // True if this is user's first launch
            if (Settings.UserName == string.Empty && Settings.NumberOfRepetitions == 0)
            {
                // Changes the page if everything went correct 
                AssignNewValues();
            }
            else
                AssignNewValues();
        }
        /// <summary>
        /// Check if the user typed in correct data and change the setting values stored in the application
        /// to ones specified by the user.
        /// </summary>
        /// <returns></returns>
        private void AssignNewValues()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(NumberOfRepetitions))
            {
                App.Current.MainPage.DisplayAlert("", "Please, type in correct data.", "Ok");

            }
            else
            {
                // Assigns the values 
                Settings.UserName = UserName;
                bool IsDataCorrect = true;

                // Checks if the user typed in correct number of repetitions
                try
                {
                    Settings.NumberOfRepetitions = int.Parse(NumberOfRepetitions);
                }
                catch (FormatException e)
                {
                    App.Current.MainPage.DisplayAlert("", "Please, type in correct data.", "Ok");
                    IsDataCorrect = false;
                }

                if (IsDataCorrect)
                    ChangePage(new WorkoutPage());
            }
        }
        #endregion
    }
}
