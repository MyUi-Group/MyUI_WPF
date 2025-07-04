using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyUi.Controls.Extens
{
    public static class MyDataGridExten
    {
        public static readonly DependencyProperty FrozenColumnCellsStyleProperty = DependencyProperty.RegisterAttached(
            "FrozenColumnCellsStyle", typeof(Style), typeof(MyDataGridExten), new PropertyMetadata(
                default));
        public static Style GetFrozenColumnCellsStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(FrozenColumnCellsStyleProperty);
        }
        public static void SetFrozenColumnCellsStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(FrozenColumnCellsStyleProperty, value);
        }


        public static readonly DependencyProperty DataGridRowHeaderWidthProperty = DependencyProperty.RegisterAttached(
            "DataGridRowHeaderWidth", typeof(double), typeof(MyDataGridExten), new PropertyMetadata(
                30.0));
        public static double GetDataGridRowHeaderWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(DataGridRowHeaderWidthProperty);
        }
        public static void SetDataGridRowHeaderWidth(DependencyObject obj, double value)
        {
            obj.SetValue(DataGridRowHeaderWidthProperty, value);
        }
    }
}
