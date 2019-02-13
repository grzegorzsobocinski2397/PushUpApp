using System.Collections.Generic;

namespace PushUpApp
{
    /// <summary>
    /// User workout consisting of five sets.
    /// </summary>
    public class Workout : BaseDataModel
    {
        #region Public Properties
        /// <summary>
        /// List of sets
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
                    Repetitions = Settings.NumberOfRepetitions,
                },
                new Set()
                {
                    Repetitions = (Settings.NumberOfRepetitions + 2),
                },
                 new Set()
                {
                    Repetitions = (Settings.NumberOfRepetitions - 1),
                },
                new Set()
                {
                    Repetitions = (Settings.NumberOfRepetitions + 4),
                },
                new Set()
                {
                    Repetitions = (Settings.NumberOfRepetitions - 4),
                },
            };
        }
        #endregion

    }
}
