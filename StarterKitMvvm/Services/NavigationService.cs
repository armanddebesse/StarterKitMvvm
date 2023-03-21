using System;

namespace StarterKitMvvm
{
    /// <summary>
    /// A service to navigate between ViewModels.
    /// </summary>
    public class NavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<BaseViewModel> _createViewModel;

        /// <summary>
        /// Instanciates NavigationService.
        /// </summary>
        /// <param name="navigationStore">The NavigationStore of the module.</param>
        /// <param name="createViewModel">A function which return the ViewModel that we want to navigate.</param>
        public NavigationService(NavigationStore navigationStore, Func<BaseViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        /// <summary>
        /// Navigates to the desired ViewModel.
        /// </summary>
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
