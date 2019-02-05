using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PushUpApp
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public BaseViewModel()
        {

        }
    }
}
