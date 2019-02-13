namespace PushUpApp
{
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
        public string SetToString()
        {
            return Repetitions.ToString();
        }
        #endregion
    }
}
