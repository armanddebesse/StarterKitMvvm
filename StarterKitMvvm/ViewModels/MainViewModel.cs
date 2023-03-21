namespace StarterKitMvvm
{
    /// <summary>
    /// The main ViewModel of a module. Used to navigate between all ViewModels of the component.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        /// <summary>
        /// Store the current state of app.
        /// </summary>
        protected NavigationStore _navigationStore;

        /// <summary>
        /// The currently displayed ViewModel.
        /// </summary>
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        /// <summary>
        /// Instanciates MainViewModel with a new NavigationStore.
        /// </summary>
        public MainViewModel()
        {
            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        /// <summary>
        /// Instanciates MainViewModel with an existing NavigationStore.
        /// </summary>
        /// <param name="navigationStore"></param>
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        /// <summary>
        /// Notifies UI when a new ViewModel needs to be displayed.
        /// </summary>
        protected void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
