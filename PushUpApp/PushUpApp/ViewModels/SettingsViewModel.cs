namespace PushUpApp
{
    public class SettingsViewModel : BaseViewModel
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
        /// Save changes 
        /// </summary>
        public RelayCommand SaveCommand { get; set; }

        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public SettingsViewModel()
        {
            // Create commands
            SaveCommand = new RelayCommand(() => SaveSettings());
        }
        #endregion
        #region Private Methods
        private void SaveSettings()
        {
            // Assigns the values 
            Settings.UserName = UserName;
            Settings.NumberOfRepetitions = NumberOfRepetitions;

        }
        #endregion
    }
}
