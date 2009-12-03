using System;
using PostSharp.Laos;

namespace GMT_ChangesAndValidation.PostSharp
{
    [Serializable]    
    public class LogExceptionsAttribute : OnMethodBoundaryAspect
    {
        public override void OnException(MethodExecutionEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Exception.Message);
            eventArgs.FlowBehavior = FlowBehavior.Continue;
        }
    }
}