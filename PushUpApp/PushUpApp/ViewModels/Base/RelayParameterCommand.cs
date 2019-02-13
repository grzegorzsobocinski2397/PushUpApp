using System;
using System.Windows.Input;

namespace PushUpApp
{
    /// <summary>
    /// Base class for the command that takes in the parameter
    /// </summary>
    public class RelayParameterCommand : ICommand
    {
        #region Public Members
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        #endregion
        #region Private Members
        /// <summary>
        /// Action to perform
        /// </summary>
        private Action<object> action;
        #endregion
        #region Constructor
        public RelayParameterCommand(Action<object> action)
        {
            this.action = action;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Perform the action with parameter specified.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            action(parameter);
        }
        #endregion
    }
}
