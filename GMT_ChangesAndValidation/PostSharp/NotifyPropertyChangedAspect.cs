using System;
using System.ComponentModel;
using PostSharp.Laos;

namespace GMT_ChangesAndValidation.PostSharp
{
    [Serializable]
    public class NotifyPropertyChangedAspect : CompositionAspect
    {
        public override object CreateImplementationObject(InstanceBoundLaosEventArgs eventArgs)
        {
            return new NotifyPropertyChangedImplementation(eventArgs.Instance);
        }

        public override Type GetPublicInterface(Type containerType)
        {
            return typeof (INotifyPropertyChanged);
        }

        public override Type[] GetProtectedInterfaces(Type containerType)
        {
            return new Type[] { typeof(INotifyPropertyChanged)};
        }

        public override CompositionAspectOptions GetOptions()
        {
            return
                CompositionAspectOptions.GenerateImplementationAccessor |
                CompositionAspectOptions.IgnoreIfAlreadyImplemented;
        }
    }
}