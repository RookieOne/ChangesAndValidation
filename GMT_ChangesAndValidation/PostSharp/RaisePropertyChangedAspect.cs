using System;
using System.ComponentModel;
using PostSharp.Laos;

namespace GMT_ChangesAndValidation.PostSharp
{
    [Serializable]
    public class RaisePropertyChangedAspect : OnMethodBoundaryAspect
    {
        public RaisePropertyChangedAspect(string propertyName)
        {
            _PropertyName = propertyName;
        }

        readonly string _PropertyName;

        public override void OnSuccess(MethodExecutionEventArgs eventArgs)
        {
            var composedObj = (IComposed<INotifyPropertyChanged>)eventArgs.Instance;
            var implementation =
                composedObj.GetImplementation(eventArgs.InstanceCredentials) as NotifyPropertyChangedImplementation;

            implementation.OnPropertyChanged(_PropertyName);

            var methodName = String.Format("On{0}Changed", _PropertyName);

            var method = eventArgs.Method.DeclaringType.GetMethod(methodName);

            if (method != null)
            {
                method.Invoke(eventArgs.Instance, null);
            }
        }
    }
}