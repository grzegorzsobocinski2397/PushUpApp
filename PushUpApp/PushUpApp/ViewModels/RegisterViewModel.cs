namespace PushUpApp
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Public Properties
        /// <summary>
        /// User name that will be remember throughout the application 
        /// </summary>
        public string UserName { get; set; }
        #endregion
        #region Commands
        public RelayCommand RegisterCommand { get; set; } 
        #endregion
        #region Default constructor
        public RegisterViewModel()
        {
            // Creates commands 
            RegisterCommand = new RelayCommand(() => RegisterUser());
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Registers user name in Settings class so it will be remembered 
        /// </summary>
        private void RegisterUser()
        {
            Settings.UserName = UserName;
        }
        #endregion
    }
}
