namespace PushUpApp
{
    public class Set
    {
        #region Public Properties
        /// <summary>
        /// Number of push ups to perform. 
        /// This is string, because it's easier to display this on the <see cref="WorkoutPage"/>
        /// </summary>
        public int Repetitions { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public Set()
        {

        }
        #endregion
        #region Public Methods
        public string SetToString()
        {
            return Repetitions.ToString();
        }
        #endregion
    }
}
