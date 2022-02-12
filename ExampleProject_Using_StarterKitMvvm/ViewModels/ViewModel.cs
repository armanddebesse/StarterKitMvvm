using StarterKitMvvmWpf;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject_Using_StarterKitMvvm.ViewModels
{
    public class ViewModel : BaseViewModel
    {
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                ClearErrors(nameof(Text));
                if (_text == "Error")
                {
                    AddError(nameof(Text), "This is an error !");
                }
                OnPropertyChanged(nameof(Text));
            }
        }
    }
}
