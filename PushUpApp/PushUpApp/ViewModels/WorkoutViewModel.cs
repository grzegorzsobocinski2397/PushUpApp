namespace PushUpApp
{
    public class WorkoutViewModel : BaseViewModel
    {

        #region Public Properties
        /// <summary>
        /// Number of repetitions 
        /// </summary>
        public Workout Workout { get; set; }
        #endregion
        #region Commands
        /// <summary>
        /// Starts workout 
        /// </summary>
        public RelayCommand StartCommand { get; set; }
        #endregion
        #region Constructor
        public WorkoutViewModel()
        {
            // Creates commands
            StartCommand = new RelayCommand(() => StartWorkout());

            // Initialize workout
            Workout = new Workout();
        }
        #endregion
        #region Private Methods
        private void StartWorkout()
        {

        }
        #endregion
    }
}
