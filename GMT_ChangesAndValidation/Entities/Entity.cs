using System.ComponentModel;
using GMT_ChangesAndValidation.PostSharp;

namespace GMT_ChangesAndValidation.Entities
{
    public abstract class Entity : INotifyPropertyChanged, IDataErrorInfo
    {
        [IsValid]
        public string this[string columnName]
        {
            get { return string.Empty; }
        }

        public string Error { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}