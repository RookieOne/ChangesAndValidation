using System.ComponentModel;
using GMT_ChangesAndValidation.Framework;

namespace GMT_ChangesAndValidation.PostSharp
{
    public class DataErrorInfoImplementation : IDataErrorInfo
    {
        public DataErrorInfoImplementation(object instance)
        {
            _Instance = instance;
        }

        readonly object _Instance;

        public string this[string columnName]
        {
            get { return GetErrorFor(columnName); }
        }

        public string Error { get; set; }

        string GetErrorFor(string columnName)
        {
            var methodName = string.Format("{0}IsValid", columnName);

            var typeWithMethod = _Instance.GetType();
            var method = typeWithMethod.GetMethod(methodName);

            if (method == null)
                return string.Empty;

            var result = new ValidationResult();

            method.Invoke(_Instance, new object[] {result});            

            return (result.IsValid)
                       ? string.Empty
                       : result.Message;
        }
    }
}