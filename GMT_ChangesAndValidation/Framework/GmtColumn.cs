using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using GMT_ChangesAndValidation.PostSharp;
using Microsoft.Windows.Controls;

namespace GMT_ChangesAndValidation.Framework
{
    [LogExceptions]
    public class GmtColumn : DataGridBoundColumn
    {
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            var control = new ContentControl();
            var binding = CreateBinding();

            BindingOperations.SetBinding(control, ContentPresenter.ContentProperty, binding);

            var template = GetDisplayTemplate(dataItem);

            control.ContentTemplate = template;

            return control;
        }

        protected override bool CommitCellEdit(FrameworkElement editingElement)
        {
            var b = BindingOperations.GetBindingExpression(editingElement, ContentControl.ContentProperty);
            b.UpdateSource();

            return !Validation.GetHasError(editingElement);
        }

        Binding CreateBinding()
        {
            var b = (Binding) Binding;
            var binding = new Binding(b.Path.Path);
            return binding;
        }

        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            var control = new ContentControl();
            var binding = CreateBinding();

            BindingOperations.SetBinding(control, ContentPresenter.ContentProperty, binding);

            var template = GetEditingTemplate(dataItem);

            control.ContentTemplate = template;

            return control;
        }

        DataTemplate GetDisplayTemplate(object dataItem)
        {
            var binding = Binding as Binding;

            var path = binding.Path.Path;

            var propertyInfo = dataItem.GetType().GetProperty(path);

            if (propertyInfo != null)
            {
                var propertyType = dataItem.GetType().GetProperty(path).PropertyType;                
                var templateName = propertyType.Name + "DisplayTemplate";
                return Application.Current.Resources[templateName] as DataTemplate;
            }

            return null;
        }

        DataTemplate GetEditingTemplate(object dataItem)
        {
            var binding = Binding as Binding;

            var path = binding.Path.Path;

            var propertyInfo = dataItem.GetType().GetProperty(path);

            if (propertyInfo != null)
            {
                var propertyType = dataItem.GetType().GetProperty(path).PropertyType;
                var templateName = propertyType.Name + "EditTemplate";
                return Application.Current.Resources[templateName] as DataTemplate;
            }

            return null;
        }
    }
}