using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFOCE
{
    class DelegateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        Action<object?> m_execute;
        Func<object?, bool> m_canExecute;

        public DelegateCommand(Action<object?> _execute, Func<object?,bool> _canExecute)
        {
            m_execute = _execute;
            m_canExecute = _canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return m_canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            m_execute(parameter);
        }
    }
}
