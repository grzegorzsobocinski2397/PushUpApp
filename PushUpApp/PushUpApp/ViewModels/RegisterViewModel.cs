namespace PushUpApp
{
    public class RegisterViewModel : BaseViewModel
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
        public RelayCommand ContinueCommand { get; set; } 
        #endregion
        #region Default constructor
        public RegisterViewModel()
        {
            // Creates commands 
            ContinueCommand = new RelayCommand(() => RegisterUser());
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Registers user name in Settings class so it will be remembered 
        /// </summary>
        private void RegisterUser()
        {
            // Assigns the values 
            Settings.UserName = UserName;
            Settings.NumberOfRepetitions = NumberOfRepetitions;

            // Changes current page
            App.Current.MainPage.Navigation.PushAsync(new WorkoutPage());
        }
        #endregion
    }
}
