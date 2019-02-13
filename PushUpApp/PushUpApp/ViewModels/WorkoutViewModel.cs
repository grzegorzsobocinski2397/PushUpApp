using Plugin.LocalNotification;
using System;
using System.Timers;
using Xamarin.Forms;

namespace PushUpApp
{
    public class WorkoutViewModel : BaseViewModel
    {
        #region Private Members
        ILocalNotificationService notificationService = DependencyService.Get<ILocalNotificationService>();
        #endregion
        #region Public Properties
        /// <summary>
        /// Timer that is used in the <see cref="PauseWorkout"/>
        /// </summary>
        public Timer Timer { get; set; }
        /// <summary>
        /// Number of repetitions 
        /// </summary>
        public Workout Workout { get; set; }
        /// <summary>
        /// Text inside of the button 
        /// </summary>
        public string ButtonText { get; set; } = "Start";
        /// <summary>
        /// True if user started the workout
        /// </summary>
        public bool IsInformationTextVisible { get; set; }
        /// <summary>
        /// True if user completed one set
        /// </summary>
        public bool IsPauseEnabled { get; set; }
        /// <summary>
        /// String informing the user of how much break time he has left 
        /// </summary>
        public int BreakTimeLeft { get; set; } = 150;
        #endregion
        #region Commands
        /// <summary>
        /// Starts workout 
        /// </summary>
        public RelayCommand StartCommand { get; set; }
        /// <summary>
        /// Changes page to <see cref="SettingsPage"/>
        /// </summary>
        public RelayCommand SettingsCommand { get; set; }
        public RelayCommand StopBreakCommand { get; set; }
        #endregion
        #region Constructor
        public WorkoutViewModel()
        {
            // Creates commands
            StartCommand = new RelayCommand(() => CheckWorkout());
            SettingsCommand = new RelayCommand(() => ChangePage(new SettingsPage()));
            StopBreakCommand = new RelayCommand(() => StopBreak());
            // Initialize workout
            Workout = new Workout();
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Changes the button text based on the previous text 
        /// </summary>
        private void CheckWorkout()
        {
           if(ButtonText == "Start")
            {
                ButtonText = Workout.Sets[0].SetToString();
                IsInformationTextVisible = true;
            }
            else if(ButtonText == Workout.Sets[0].SetToString())
            {
                ButtonText = Workout.Sets[1].SetToString();
                PauseWorkout();
            }
            else if (ButtonText == Workout.Sets[1].SetToString())
            {
                ButtonText = Workout.Sets[2].SetToString();
                PauseWorkout();
            }
            else if (ButtonText == Workout.Sets[2].SetToString())
            {
                ButtonText = Workout.Sets[3].SetToString();
                PauseWorkout();
            }
            else if (ButtonText == Workout.Sets[3].SetToString())
            {
                ButtonText = Workout.Sets[4].SetToString();
                PauseWorkout();
            }
            else if (ButtonText == Workout.Sets[4].SetToString())
            {
                FinishWorkout();
            }

        }
        /// <summary>
        /// Display black screen for the user informing him of the break time 
        /// </summary>
        private void PauseWorkout()
        {
            // Shows the black screen 
            IsPauseEnabled = true;
            // Starts timer that lasts 1.5 minutes
            Timer = new Timer(1000);
            Timer.Enabled = true;
            Timer.Elapsed += ChangeBreakTime;
        }
        /// <summary>
        /// Changes the break time by one second
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeBreakTime(object sender, ElapsedEventArgs e)
        {
            BreakTimeLeft--;

            // If the break time is 0, change everything to default and stop timer.
            if(BreakTimeLeft == 0)
            {
                StopBreak();
            }
        }
        /// <summary>
        /// Stops the break time and continues with the workout
        /// </summary>
        private void StopBreak()
        {
            IsPauseEnabled = false;
            Timer.Stop();
            BreakTimeLeft = 150;
        }
        private void FinishWorkout()
        {
            ButtonText = "Finish workout";

            // Changes the user's maximum number of repetitions 
            Settings.NumberOfRepetitions = Workout.Sets[1].Repetitions;

            // Sends new notification 
            var notification = new LocalNotification
            {
                NotificationId = 100,
                Title = "Time for a workout!",
                Description = String.Format("{0}, it's time for your daily push-up workout!", Settings.UserName),
                NotifyTime = DateTime.Now.AddDays(1),
                 
            };
            notificationService.Show(notification);
        }
        #endregion
    }
}
