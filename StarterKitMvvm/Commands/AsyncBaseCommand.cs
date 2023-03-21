using System.Threading.Tasks;

namespace StarterKitMvvm
{
    /// <summary>
    /// A base for all async commands.
    /// </summary>
    public abstract class AsyncBaseCommand : BaseCommand
    {
        private bool _isExecuting;
        /// <summary>
        /// Indicates if the command is currently executing.
        /// </summary>
        private bool IsExecuting
        {
            get => _isExecuting;
            set
            {
                _isExecuting = value;
                OnCanExecuteChanged();
            }
        }

        /// <inheriteddoc cref="BaseCommand.CanExecute(object)"/>
        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && base.CanExecute(parameter);
        }

        /// <inheriteddoc cref="BaseCommand.Execute(object)"/>
        public override async void Execute(object parameter)
        {
            IsExecuting = true;

            try
            {
                await ExecuteAsync(parameter);
            }
            finally
            {
                IsExecuting = false;
            }
        }

        /// <summary>
        /// Defines the method to be called asynchronously when the command is invoked.
        /// Automatically set CanExecute() value to false during the execution.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public abstract Task ExecuteAsync(object parameter);
    }
}
