namespace PushUpApp
{
    public class Workout
    {
        #region Public Properties
        /// <summary>
        /// Workout sets 
        /// </summary>
        #region Workouts Sets
        public int FirstSet { get; set; }
        public int SecondSet { get; set; }
        public int ThirdSet { get; set; }
        public int FourthSet { get; set; }
        public int FifthSet { get; set; }
        #endregion
        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public Workout()
        {
            // Creates workout based on the user maximum 
            FirstSet = int.Parse(Settings.NumberOfRepetitions);
            SecondSet = FirstSet + 2;
            ThirdSet = FirstSet;
            FourthSet = SecondSet + 2;
            FifthSet = FirstSet - 4;
        }
        #endregion
    }
}
