using System;
using PostSharp.Laos;

namespace GMT_ChangesAndValidation.PostSharp
{
    [Serializable]
    public class NotifyAttribute : OnMethodBoundaryAspect
    {
        public override void OnSuccess(MethodExecutionEventArgs eventArgs)
        {
            if (IsSetter(eventArgs))
            {
                var propertyName = eventArgs.Method.Name.Substring(4);                
                var method = eventArgs.Method.DeclaringType.GetMethod("RaisePropertyChanged");

                if (method != null)
                {
                    method.Invoke(eventArgs.Instance, new object[] {propertyName});
                }
            }

            base.OnSuccess(eventArgs);
        }        

        bool IsSetter(MethodExecutionEventArgs eventArgs)
        {
            return eventArgs.Method.IsSpecialName
                   && !eventArgs.Method.IsConstructor
                   && eventArgs.Method.Name.Substring(0, 3) == "set";
        }
    }
}