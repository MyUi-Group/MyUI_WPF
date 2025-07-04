using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyUiDemo.Mvvm
{
    internal class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action<object> _executeMethod;
        private Func<object, bool> _canExecuteMethod;

        public bool CanExecute(object parameter)
        {
            if (this._canExecuteMethod == null)
            {
                return true;
            }
            return this._canExecuteMethod(parameter);
        }
        public DelegateCommand(Action<object> executeMethod)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException("executeMethod", "DelegateCommandDelegatesCannotBeNull");
            }
            _executeMethod = executeMethod;
            _canExecuteMethod = (o) => true;
        }
        public DelegateCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException("executeMethod", "DelegateCommandDelegatesCannotBeNull");
            }
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }
        public void Execute(object parameter)
        {
            if (this._executeMethod == null) return;
            this._executeMethod(parameter);
        }
    }
   
}
