using System;
using System.ComponentModel;
using PostSharp.Laos;

namespace GMT_ChangesAndValidation.PostSharp
{
    [Serializable]
    public class DataErrorInfoAspect : CompositionAspect
    {
        public override object CreateImplementationObject(InstanceBoundLaosEventArgs eventArgs)
        {
            return new DataErrorInfoImplementation(eventArgs.Instance);
        }

        public override Type GetPublicInterface(Type containerType)
        {
            return typeof (IDataErrorInfo);
        }
    }
}