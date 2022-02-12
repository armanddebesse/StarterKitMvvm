using System;
using System.Windows.Input;

namespace StarterKitMvvmWpf
{
    /// <summary>
    /// A base for commands with the CanExecuteChanged Event, implements ICommand
    /// </summary>
    public abstract class BaseCommand : ICommand
    {
        #region Implement ICommand
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);

        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}
