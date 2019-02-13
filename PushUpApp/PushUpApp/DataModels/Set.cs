namespace PushUpApp
{
    /// <summary>
    /// One push-up set.
    /// </summary>
    public class Set : BaseDataModel
    {
        #region Public Properties 
        /// <summary>
        /// Number of push ups to perform. 
        /// This is string, because it's easier to display this on the <see cref="WorkoutPage"/>
        /// </summary>
        public int Repetitions { get; set; }
        /// <summary>
        /// True, if user is going to perform this set
        /// </summary>
        public bool IsActive { get; set; }
        #endregion
        #region Public Methods
        /// <summary>
        /// Converts the <see cref="Repetitions"/> to string, so code looks less clustered.
        /// </summary>
        /// <returns></returns>
        public string SetToString()
        {
            return Repetitions.ToString();
        }
        #endregion
    }
}
