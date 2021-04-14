using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace libary
{
    public class CustomCommand: ICommand
    {
        Action action;

        public CustomCommand(Action action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}
