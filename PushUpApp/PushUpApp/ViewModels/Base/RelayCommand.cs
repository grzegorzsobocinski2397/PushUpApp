using System;
using System.Windows.Input;

namespace PushUpApp
{
    /// <summary>
    /// Base class for the commands
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Public Members
        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// Command can always execute
        /// </summary>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }
        #endregion
        #region Private Members
        /// <summary>
        /// Action to perform
        /// </summary>
        private Action action;
        #endregion
        #region Constructor
        /// <param name="action"></param>
        public RelayCommand(Action action)
        {
            this.action = action;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Execute the action
        /// </summary>
        public void Execute(object parameter)
        {
            action();
        }
        #endregion

    }
}
