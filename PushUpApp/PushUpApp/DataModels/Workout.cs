using System.Collections.Generic;

namespace PushUpApp
{
    public class Workout
    {
        #region Private Members
        /// <summary>
        /// User's maximum saved in the application.
        /// </summary>
        private int maximumRepetitions = int.Parse(Settings.NumberOfRepetitions);
        #endregion
        #region Public Properties
        /// <summary>
        /// Lists of sets
        /// </summary>
        public List<Set> Sets { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public Workout()
        {
            // Creates workout based on the user maximum 
            Sets = new List<Set>()
            {
                new Set()
                {
                    Repetitions = maximumRepetitions.ToString(),
                },
                new Set()
                {
                    Repetitions = (maximumRepetitions + 2).ToString(),
                },
                 new Set()
                {
                    Repetitions = (maximumRepetitions - 1).ToString(),
                },
                new Set()
                {
                    Repetitions = (maximumRepetitions + 4).ToString(),
                },
                new Set()
                {
                    Repetitions = (maximumRepetitions - 4).ToString(),
                },
            };
        }
        #endregion

    }
}
