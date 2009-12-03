using System.ComponentModel;

namespace GMT_ChangesAndValidation.PostSharp
{
    public class NotifyPropertyChangedImplementation : INotifyPropertyChanged
    {
        public NotifyPropertyChangedImplementation(object instance)
        {
            _Instance = instance;
        }

        readonly object _Instance;
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(_Instance, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}