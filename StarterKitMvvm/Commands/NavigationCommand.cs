using System.Windows.Navigation;

namespace StarterKitMvvm
{
    /// <summary>
    /// A command to navigate between ViewModels.
    /// </summary>
    public class NavigationCommand : BaseCommand
    {
        /// <summary>
        /// The service used to navigate to next ViewModel.
        /// </summary>
        protected readonly NavigationService _navigationService;

        /// <summary>
        /// Instanciate a NavigationCommand.
        /// </summary>
        /// <param name="navigationService"></param>
        public NavigationCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        /// <summary>
        /// Navigates with the NavigationService.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}

