using System;
using PostSharp.Laos;

namespace GMT_ChangesAndValidation.PostSharp
{
    [Serializable]
    public class OnChangedAttribute : OnMethodBoundaryAspect
    {
        public override void OnSuccess(MethodExecutionEventArgs eventArgs)
        {
            if (IsSetter(eventArgs))
            {
                var propertyName = eventArgs.Method.Name.Substring(4);
                var methodName = String.Format("On{0}Changed", propertyName);

                var method = eventArgs.Method.DeclaringType.GetMethod(methodName);

                if (method != null)
                {
                    method.Invoke(eventArgs.Instance, null);
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