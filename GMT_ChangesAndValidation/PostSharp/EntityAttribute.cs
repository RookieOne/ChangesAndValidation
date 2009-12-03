using System;
using System.Reflection;
using PostSharp.Extensibility;
using PostSharp.Laos;

namespace GMT_ChangesAndValidation.PostSharp
{
    [Serializable]    
    [MulticastAttributeUsage(MulticastTargets.Class)]
    public class EntityAttribute : CompoundAspect
    {
        public override void ProvideAspects(object element, LaosReflectionAspectCollection collection)
        {
            collection.AddAspect(element, new DataErrorInfoAspect());

            collection.AddAspect(element, new NotifyPropertyChangedAspect());

            AddRaisePropertyChangedAspects(element, collection);
        }

        void AddRaisePropertyChangedAspects(object element, LaosReflectionAspectCollection collection)
        {
            Type type = (Type)element;

            foreach ( PropertyInfo property in type.UnderlyingSystemType.GetProperties() )
            {
                if ( property.DeclaringType == type && property.CanWrite )
                {
                    MethodInfo method = property.GetSetMethod(true);

                    if ( !method.IsStatic )
                    {
                        collection.AddAspect( method, new RaisePropertyChangedAspect(property.Name) );
                    }
                }
            }
        }
    }
}