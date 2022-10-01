# StarterKitMvvm

## Starting
* Add the nuget to your project : https://www.nuget.org/packages/StarterKitMvvmWpf/
* Import the Ressource Dictionnary on your view :
```xaml
<Window.Resources>
        <ResourceDictionary Source="pack://application:,,,/StarterKitMvvmWpf;component/StarterKitTheme.xaml"/>
</Window.Resources>
```
* You can find a basic usage example in the [ExampleProject](ExampleProject_Using_StarterKitMvvm)
* Don't forget to open an issue for all questions or requests !
## Content

### The Base ViewModel
This starter kit provides a BaseViewModel to help you on differents ways. <br />
You just have to inherit your custom view models from the BaseViewModel.
#### PropertyChanged event
Use this event on your binded properties to notify the UI when the value changes. <br />
Example :
```C#
    public class ViewModel : BaseViewModel
    {
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                // This method is inherited from the BaseViewModel, it will invoke the PropertyChanged event
                OnPropertyChanged(nameof(Text));
            }
        }
    }
```

#### Prompt error handling
With this BaseViewModel, you can handle prompt errors by display them in the UI. <br />
Result : <br />
![image](https://user-images.githubusercontent.com/73818074/154536808-08babf4f-8d27-47c6-a54f-7ffe3012a869.png)

There is only two steps to beneficiate of this error displaying :
* Add the "ErrorInfoTextBox" style to your text box : 
```xaml
<TextBox Width="200" Height="30" Text="{Binding Text, UpdateSourceTrigger=PropertyChanged}" Style="{DynamicResource ErrorInfoTextBox}"/>
```
* Use the inherited methods to handle the error :
```C#
    public class ViewModel : BaseViewModel
    {
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                // Clear all previous errors for this property
                ClearErrors(nameof(Text));
                // Your logic to know if the user input is an error
                if (_text == "Error")
                {
                // Add an error with custom message for your property
                    AddError(nameof(Text), "This is an error !");
                }
                OnPropertyChanged(nameof(Text));
            }
        }
    }
```

### The Base Command
This starter kit provides a BaseCommand to help you with your commands. <br />
You just have to inherit your custom commands from the BaseCommand.

```C#
    public class DisplayUserInputCommand : BaseCommand
    {
        // Get the ViewModel in private field to acces the properties
        private readonly ViewModel _viewModel;

        public DisplayUserInputCommand(ViewModel viewModel)
        {
            _viewModel = viewModel;
            
            // Don't forget tu subscribe to the PropertyChanged event to check if the command can be executed
            // each time the concerned properties changes
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        // Here is the content of the command, this code will be executed when the command will be executed
        public override void Execute(object parameter)
        {
            MessageBox.Show("Your message is : " + _viewModel.Text);
        }
        
        // Your logic to allow or deny the execution of the command
        // Here, the command can be executed only if Text (content of TextBox) is not null or empty
        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Text) && base.CanExecute(parameter);
        }
        
        // Create an event handler to check if the command can be executed
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Check if the command can be executed only when concerned properties changes
            if (e.PropertyName == nameof(ViewModel.Text))
            {
                OnCanExecutedChanged();
            }
        }
    }
 ```
