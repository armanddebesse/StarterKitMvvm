# StarterKitMvvm

## Starting
Just add the nuget to your project : https://www.nuget.org/packages/StarterKitMvvmWpf/

## Content

### The Base ViewModel
This starter kit provides a BaseViewModel to help you on differents ways.
You just have to inherit your custom view models from the BaseViewModel
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
