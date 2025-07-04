using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace MyWLUi.Controls.DataGrid
{
    internal static class DataGridHelper
    {
        public static readonly DependencyProperty IsColumnFrozenProperty = DependencyProperty.RegisterAttached(
            "IsColumnFrozen", typeof(bool), typeof(DataGridHelper), new PropertyMetadata(
                false));
        public static bool GetIsColumnFrozen(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsColumnFrozenProperty);
        }
        public static void SetIsColumnFrozen(DependencyObject obj, bool value)
        {
            obj.SetValue(IsColumnFrozenProperty, value);
        }

        public static readonly DependencyProperty IsFrozenColumnsEdgeProperty = DependencyProperty.RegisterAttached(
            "IsFrozenColumnsEdge", typeof(bool), typeof(DataGridHelper), new PropertyMetadata(
                false));
        public static bool GetIsFrozenColumnsEdge(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsFrozenColumnsEdgeProperty);
        }
        public static void SetIsFrozenColumnsEdge(DependencyObject obj, bool value)
        {
            obj.SetValue(IsFrozenColumnsEdgeProperty, value);
        }



        public static Size SubtractFromSize(Size size, double thickness, bool height)
        {
            return height
                ? new Size(size.Width, Math.Max(0.0, size.Height - thickness))
                : new Size(Math.Max(0.0, size.Width - thickness), size.Height);
        }

        public static bool IsGridLineVisible(System.Windows.Controls.DataGrid dataGrid, bool isHorizontal)
        {
            if (dataGrid != null)
            {
                switch (dataGrid.GridLinesVisibility)
                {
                    case DataGridGridLinesVisibility.All:
                        return true;
                    case DataGridGridLinesVisibility.Horizontal:
                        return isHorizontal;
                    case DataGridGridLinesVisibility.None:
                        return false;
                    case DataGridGridLinesVisibility.Vertical:
                        return !isHorizontal;
                }
            }
            return false;
        }

        internal static List<DataGridColumn> GetDisplayColumns(System.Windows.Controls.DataGrid dataGrid)
        {
            var columnList = dataGrid.Columns.ToList();
            columnList.Sort((c1, c2) => c1.DisplayIndex - c2.DisplayIndex);

            return columnList;
        }
    }
}
