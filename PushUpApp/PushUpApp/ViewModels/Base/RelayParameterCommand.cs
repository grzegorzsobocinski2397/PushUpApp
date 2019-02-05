using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PushUpApp
{
    /// <summary>
    /// Base class for the command that takes in the parameter
    /// </summary>
    public class RelayParameterCommand : ICommand
    {
        private Action<object> action;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public RelayParameterCommand(Action<object> action)
        {
            this.action = action;
        }
        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}
