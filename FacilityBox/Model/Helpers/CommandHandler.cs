using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ResultMD.Helpers
{
    public class CommandHandler : ICommand
    {
        private Action<object> _actionParam;
        private Action _action;
        private bool _canExecute;
        public CommandHandler(Action<object> action, bool canExecute)
        {
            _actionParam = action;
            _canExecute = canExecute;
        }

        public CommandHandler(Action action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter = null)
        {
            try
            {
                if (parameter != null)
                    _actionParam(parameter);
                else
                    _action();
            }
            catch (Exception ex)
            {
                _action();
            }
        }
    }
}
