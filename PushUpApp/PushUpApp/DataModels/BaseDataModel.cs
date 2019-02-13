using System.ComponentModel;

namespace PushUpApp
{
    public class BaseDataModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
