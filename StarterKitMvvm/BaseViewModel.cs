using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace StarterKitMvvmWpf
{
    /// <summary>
    /// A Base for viewmodels with the propertyChanged event and the dataErrorInfo logic
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        
        /// <summary>
        /// Invoke the PropertyChanged Event to notify the UI
        /// </summary>
        /// <param name="propertyName">The name of the attribute binded in the UI</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Implement INotifyDataErrorInfo
        private readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();
        public bool HasErrors => _propertyErrors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        /// Gets all errors of the specified property
        /// </summary>
        /// <param name="propertyName">The name of the property (use nameof())</param>
        /// <returns>List of errors</returns>
        public IEnumerable GetErrors(string propertyName)
        {
            if (_propertyErrors.ContainsKey(propertyName))
            {
                return _propertyErrors[propertyName];
            } else
            {
                return null;
            }
        }

        /// <summary>
        /// Add an error for the specified property
        /// </summary>
        /// <param name="propertyName">The name of the property (use nameof())</param>
        /// <param name="errorMessage">The error message to display to user</param>
        public void AddError(string propertyName, string errorMessage)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Add(propertyName, new List<string>());
            }

            _propertyErrors[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }

        /// <summary>
        /// Clear the error list for the specified property
        /// </summary>
        /// <param name="propertyName">The name of the property (use nameof())</param>
        public void ClearErrors(string propertyName)
        {
            if (_propertyErrors.Remove(propertyName))
            {
                OnErrorsChanged(propertyName);
            }
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        #endregion
    }
}
