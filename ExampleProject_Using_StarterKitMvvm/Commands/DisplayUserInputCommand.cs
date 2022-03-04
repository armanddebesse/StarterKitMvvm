using ExampleProject_Using_StarterKitMvvm.ViewModels;
using StarterKitMvvmWpf;
using System.ComponentModel;
using System.Windows;

namespace ExampleProject_Using_StarterKitMvvm.Commands
{
    public class DisplayUserInputCommand : BaseCommand
    {
        private readonly ViewModel _viewModel;

        public DisplayUserInputCommand(ViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            MessageBox.Show("Your message is : " + _viewModel.Text);
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Text) && base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.Text))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
