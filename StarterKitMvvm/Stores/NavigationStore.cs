using System;

namespace StarterKitMvvm
{
    /// <summary>
    /// Stores the current state of app.
    /// </summary>
    public class NavigationStore
    {
        private BaseViewModel _currentViewModel;
        /// <summary>
        /// The currently displayed ViewModel.
        /// </summary>
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        /// <summary>
        /// Event handling changes on CurrentViewModel.
        /// </summary>
        public event Action CurrentViewModelChanged;

        /// <summary>
        /// Invokes CurrentViewModelChanged event.
        /// </summary>
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
