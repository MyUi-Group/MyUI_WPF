using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;
using MyWLUi.Global;
using MyWLUi.Controls.Extens;
using MyWLUi.Controls.DataGrid;

namespace MyWLUi.Controls
{
    internal class RightFrozenSupportedDataGridCellsPanel : DataGridCellsPanel
    {
        private MyDataGrid _parentDataGrid;
        private ScrollViewer _scrollViewer;
        private ScrollBar _scrollBar;
        private Style _frozenColumnCellsStyle;
        private double _rowHeaderWidth;
        private double _verticalScrollBarWidth;
        private int _lastFrozenCount = 0;



        public bool WhetherToConsiderTheWidthOfScrollbar { get; set; } = true;



        private bool TryGetParentDataGrid()
        {
            if (_parentDataGrid == null)
            {
                if ((_parentDataGrid = this.FindVisualParent<MyDataGrid>()) == null)
                {
                    return false;
                }
            }

            return true;
        }

        private bool PrepareVisualElement()
        {
            if (_scrollViewer == null)
            {
                if ((_scrollViewer = this.FindVisualParent<ScrollViewer>()) == null)
                {
                    return false;
                }

                _scrollBar = _scrollViewer.FindVisualChildOnFlatSearching<ScrollBar>("PART_VerticalScrollBar");
            }

            if (_frozenColumnCellsStyle == null)
            {
                _frozenColumnCellsStyle = MyDataGridExten.GetFrozenColumnCellsStyle(_parentDataGrid);
            }

            return true;
        }

        private UIElement GetChildByColumn(DataGridColumn column)
        {
            var index = _parentDataGrid.Columns.IndexOf(column);
            return InternalChildren[index];
        }



        private void UpdateFrozenColumnsVisual()
        {
            var columnCount = _parentDataGrid.Columns.Count;
            var columnList = DataGridHelper.GetDisplayColumns(_parentDataGrid);

            for (var i = columnCount - 1; i >= 0; i--)
            {
                var column = columnList[i];
                var child = GetChildByColumn(column);

                if (columnCount - i <= _parentDataGrid.RightFrozenCount)
                {
                    column.CanUserResize = false;
                    column.CanUserReorder = false;
                    DataGridHelper.SetIsColumnFrozen(column, true);
                    if (child is DataGridCell cell && _frozenColumnCellsStyle != null)
                    {
                        cell.Style = _frozenColumnCellsStyle;
                    }

                    SetZIndex(child, 1000 - i);

                    var isEdge = columnCount - i == _parentDataGrid.RightFrozenCount;
                    DataGridHelper.SetIsFrozenColumnsEdge(child, isEdge);
                }
                else
                {
                    column.CanUserResize = true;
                    column.CanUserReorder = true;
                    DataGridHelper.SetIsColumnFrozen(column, false);
                    if (child is DataGridCell cell)
                    {
                        cell.Style = _parentDataGrid.CellStyle;
                    }

                    SetZIndex(child, 0);

                    DataGridHelper.SetIsFrozenColumnsEdge(child, false);
                }
            }
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            var baseSize = base.ArrangeOverride(arrangeSize);

            TryFrozenRightColumns(arrangeSize);

            return baseSize;
        }

        private void TryFrozenRightColumns(Size arrangeSize)
        {
            // 未找到 DataGrid
            if (TryGetParentDataGrid() == false)
            {
                return;
            }

            // 缺失必要元素
            if (PrepareVisualElement() == false)
            {
                return;
            }

            // 数量变更时更新元素视觉样式
            if (_lastFrozenCount != _parentDataGrid.RightFrozenCount)
            {
                UpdateFrozenColumnsVisual();
                _lastFrozenCount = _parentDataGrid.RightFrozenCount;
            }

            // 无冻结
            if (_parentDataGrid.RightFrozenCount == 0)
            {
                _parentDataGrid.RightFrozenColumnsViewportLength = 0d;
                return;
            }

            // 行标题宽度
            var isRowHeaderInvisible =
                _parentDataGrid.HeadersVisibility == DataGridHeadersVisibility.Column
                || _parentDataGrid.HeadersVisibility == DataGridHeadersVisibility.None;
            _rowHeaderWidth = isRowHeaderInvisible ? 0 : MyDataGridExten.GetDataGridRowHeaderWidth(_parentDataGrid);

            // 垂直滚动条宽度
            var isVerticalScrollBarInvisible = _scrollViewer.ComputedVerticalScrollBarVisibility == Visibility.Collapsed;
            _verticalScrollBarWidth = isVerticalScrollBarInvisible ? 0 : _scrollBar?.ActualWidth ?? 0;

            // 自动隐藏的ScrollViewer没有滚动条宽度；
            if (WhetherToConsiderTheWidthOfScrollbar == false)
            {
                _verticalScrollBarWidth = 0;
            }

            _parentDataGrid.TryGetProperty("HorizontalScrollOffset", out double horizontalScrollOffset);
            var rowVisualWidth = _parentDataGrid.ActualWidth - _rowHeaderWidth - _verticalScrollBarWidth;
            var offset = rowVisualWidth + horizontalScrollOffset - 1;
            var rightFrozenColumnsWidth = 0d;

            var columnList = DataGridHelper.GetDisplayColumns(_parentDataGrid);

            for (var i = 1; i <= _parentDataGrid.RightFrozenCount; i++)
            {
                var index = InternalChildren.Count - i;

                if (index < 0)
                {
                    break;
                }

                var column = columnList[index];
                var columnWidth = column.ActualWidth;
                var child = GetChildByColumn(column);

                // Overlap the columns to avoid the gap between the frozen columns.
                var columnDisplayWidth = columnWidth - 10;

                rightFrozenColumnsWidth += columnDisplayWidth;

                var point1 = new Point(offset - columnDisplayWidth, 0);
                var point2 = new Point(offset, arrangeSize.Height);

                //自动 适配 不在固定最后一列
                //child.Arrange(new Rect(point1, point2));

                offset -= columnDisplayWidth;
            }

            _parentDataGrid.RightFrozenColumnsViewportLength = rightFrozenColumnsWidth;
        }
    }
}
