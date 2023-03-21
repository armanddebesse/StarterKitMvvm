using System.ComponentModel;

namespace StarterKitMvvm
{
    /// <summary>
    /// A base for all ViewModels. Implements System.ComponentModel.INotifyPropertyChanged.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Event to notify the UI when the binded property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Invokes PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The binded property.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Defines the method to be called when the ViewModel is disposed.
        /// </summary>
        public virtual void Dispose() { }
    }
}
