using System;
using System.Windows.Input;

namespace StarterKitMvvm
{
    /// <summary>
    /// A command used with a delegate for simple actions.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        /// <summary>
        /// Event to know when the canExecute prop needs to be updated
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Creates a new DelegateCommand.
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Creates a new DelegateCommand witch always can be executed.
        /// </summary>
        /// <param name="execute"></param>
        public DelegateCommand(Action<object> execute) : this(execute, null) { }

        /// <summary>
        /// Indicates if the command can be executed.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public virtual bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        /// <summary>
        /// Updates the CanExecute property.
        /// </summary>
        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
