using Plugin.LocalNotification;
using System;
using System.Timers;
using Xamarin.Forms;

namespace PushUpApp
{
    public class WorkoutViewModel : BaseViewModel
    {
        #region Private Members
        /// <summary>
        /// Current set number 
        /// </summary>
        private int numberOfSet = 0;
        /// <summary>
        /// Service for local push notifications 
        /// </summary>
        private ILocalNotificationService notificationService = DependencyService.Get<ILocalNotificationService>();
        #endregion
        #region Public Properties
        /// <summary>
        /// Text above the button 
        /// </summary>
        public string UpperLabelText { get; set; }
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
        public string ButtonText { get; set; }
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
            // If user already completed workout then show this...
            if(Settings.NextWorkoutDate > DateTime.Now)
            {
                ButtonText = "Skip workout?";
                UpperLabelText = string.Format("Next workout {0}", Settings.NextWorkoutDate.ToShortDateString());
            }
            // ...else show this
            else
            {
                ButtonText = "Start";
                UpperLabelText = string.Format("Hello, {0}", Settings.UserName);
            }
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
        private async void CheckWorkout()
        {
            if (ButtonText == "Start")
            {
                NextSet();
                IsInformationTextVisible = true;
            }
            else if (ButtonText == Workout.Sets[4].SetToString())
                FinishWorkout();
            else if(ButtonText == "Skip workout?")
            {
                var question = await App.Current.MainPage.DisplayAlert("Skip break", "Are you sure you want to skip a break?", "I'm sure", "No thanks!");

                if (question)
                {
                    ButtonText = "Start";
                    UpperLabelText = string.Format("Hello, {0}", Settings.UserName);
                }
                else
                {
                    return;
                }
            }
            else
                NextSet();

        }
        /// <summary>
        /// Changes the current set
        /// </summary>
        private void NextSet()
        {
            // Changes texts
            ButtonText = Workout.Sets[numberOfSet].SetToString();
            UpperLabelText = "Nice job!";


            // Changes bool values of sets to default 
            foreach (var set in Workout.Sets)
            {
                set.IsActive = false;
            }

            // Sets current set to active
            Workout.Sets[numberOfSet].IsActive = true;

            numberOfSet++;

            // Starts a pause
            PauseWorkout();
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
            if (BreakTimeLeft == 0)
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
        /// <summary>
        /// Completes the workout
        /// </summary>
        private void FinishWorkout()
        {
            // Changes the user's maximum number of repetitions 
            Settings.NumberOfRepetitions = Workout.Sets[1].Repetitions;

            // Date for next workout 
            Settings.NextWorkoutDate = DateTime.Now.AddDays(1);

            // Creates new notification 
            var notification = new LocalNotification
            {
                NotificationId = 100,
                Title = "Time for a workout!",
                Description = String.Format("{0}, it's time for your daily push-up workout!", Settings.UserName),
                NotifyTime = Settings.NextWorkoutDate,

            };
            // Sends notification
            notificationService.Show(notification);

            // Changes the text inside of a circle button 
            ButtonText = "Skip break?";
            // Changes the text above the button 
            UpperLabelText = string.Format("Come back tomorrow! ");
        }
        #endregion
    }
}
