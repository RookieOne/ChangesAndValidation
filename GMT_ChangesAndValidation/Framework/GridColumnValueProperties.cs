using System.Windows;

namespace GMT_ChangesAndValidation.Framework
{
    public static class GridColumnValueProperties
    {
        static GridColumnValueProperties()
        {
            ColumnValueProperty = DependencyProperty.RegisterAttached("ColumnValue",
                                                                      typeof (object),
                                                                      typeof (GridColumnValueProperties));
        }

        public static readonly DependencyProperty ColumnValueProperty;
    }
}