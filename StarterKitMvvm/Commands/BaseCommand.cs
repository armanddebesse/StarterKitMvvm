using System;
using System.Windows.Input;

namespace StarterKitMvvm
{
    /// <summary>
    /// A base for all commands. Implements System.Windows.Input.ICommand.
    /// </summary>
    public abstract class BaseCommand : ICommand
    {
        /// <summary>
        /// Event handling changes on CanExecute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Virtual method to know if the command can be executed. Binded to "Enabled" properties of the button.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter"></param>
        public abstract void Execute(object parameter);

        /// <summary>
        /// Invokes CanExecuteChanged event.
        /// </summary>
        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
