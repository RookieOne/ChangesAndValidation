using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.Windows.Controls;

namespace GMT_ChangesAndValidation.Framework
{
    public class GmtColumn : DataGridBoundColumn
    {
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            var control = new ContentControl();
            control.SetBinding(ContentControl.ContentProperty, Binding);

            var template = GetDisplayTemplate(dataItem);

            if (!string.IsNullOrEmpty(template))
            {
                control.ContentTemplate = Application.Current.Resources[template] as DataTemplate;
            }

            return control;
        }

        //protected override bool CommitCellEdit(FrameworkElement editingElement)
        //{            
        //    var b = BindingOperations.GetBindingExpression(editingElement, TextBox.TextProperty);
        //    b.UpdateSource();

        //    return !Validation.GetHasError(editingElement);
        //}
        
        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            var control = new ContentControl();
            control.SetBinding(ContentControl.ContentProperty, Binding);

            var template = GetEditingTemplate(dataItem);

            if (!string.IsNullOrEmpty(template))
            {
                control.ContentTemplate = Application.Current.Resources[template] as DataTemplate;
            }

            return control;
        }

        string GetDisplayTemplate(object dataItem)
        {
            var binding = Binding as Binding;

            var path = binding.Path.Path;

            var propertyInfo = dataItem.GetType().GetProperty(path);

            if (propertyInfo != null)
            {
                var propertyType = dataItem.GetType().GetProperty(path).PropertyType;
                return propertyType.Name + "DisplayTemplate";
            }

            return string.Empty;            
        }

        string GetEditingTemplate(object dataItem)
        {
            var binding = Binding as Binding;

            var path = binding.Path.Path;
            
            var propertyInfo = dataItem.GetType().GetProperty(path);

            if (propertyInfo != null)
            {
                var propertyType = dataItem.GetType().GetProperty(path).PropertyType;
                return propertyType.Name + "EditTemplate";
            }

            return string.Empty;
        }
    }
}