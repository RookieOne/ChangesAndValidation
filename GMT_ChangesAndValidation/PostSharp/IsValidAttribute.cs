using System;
using GMT_ChangesAndValidation.Framework;
using PostSharp.Laos;

namespace GMT_ChangesAndValidation.PostSharp
{
    [Serializable]
    public class IsValidAttribute : OnMethodInvocationAspect
    {
        public override void OnInvocation(MethodInvocationEventArgs eventArgs)
        {
            var columnName = Convert.ToString(eventArgs.GetArgumentArray()[0]);
            var methodName = string.Format("{0}IsValid", columnName);

            var typeWithMethod = eventArgs.Instance.GetType();
            var method = typeWithMethod.GetMethod(methodName);

            if (method == null)
                return;

            var result = method.Invoke(eventArgs.Instance, null) as ValidationResult;

            eventArgs.ReturnValue = (result.IsValid)
                                        ? string.Empty
                                        : result.Message;
        }
    }
}