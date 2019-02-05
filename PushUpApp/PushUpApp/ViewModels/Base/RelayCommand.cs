using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PushUpApp
{
    /// <summary>
    /// Base class for the commands
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action action;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public RelayCommand(Action action)
        {
            this.action = action;
        }
        public void Execute(object parameter)
        {
            action();
        }
    }
}
