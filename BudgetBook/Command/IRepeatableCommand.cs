using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgetBook
{
    public interface IRepeatableCommand : ICommand
    {
        event EventHandler<CommandExecutedEventArgs> CommandExecuted;
        event EventHandler<CommandExecutingEventArgs> CommandExecuting;

        bool IsExecutable { get; set; }
    }

    public class CommandExecutedEventArgs : EventArgs
    {
    }

    public class CommandExecutingEventArgs : EventArgs
    {
    }
}
