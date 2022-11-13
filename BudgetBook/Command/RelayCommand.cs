using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgetBook
{
    public class RelayCommand : IRepeatableCommand
    {
        public RelayCommand(Action<object> execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute) : this(execute)
        {
            _canExecute = canExecute;
        }

        private readonly Func<object, bool>? _canExecute;
        private readonly Action<object>? _execute;

        public event EventHandler<CommandExecutingEventArgs>? CommandExecuting;
        public event EventHandler<CommandExecutedEventArgs>? CommandExecuted;

        public event EventHandler? CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool IsExecutable { get; set; }


        public virtual bool CanExecute(object? parameter)
        {
            if (parameter == null)
            {
                return true;
            }
            else
            {
                return _canExecute?.Invoke(parameter) ?? true;
            }
        }

        public void Execute(object? parameter)
        {
            CommandExecuting?.Invoke(this, new CommandExecutingEventArgs());

            if (parameter != null)
            {
                _execute?.Invoke(parameter);
            }
            else
            {
                _execute?.Invoke(new object());
            }

            CommandExecuted?.Invoke(this, new CommandExecutedEventArgs());
        }
    }
}
