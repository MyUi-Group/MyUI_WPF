using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyUi.Controls
{
    public class MyDataGrid : System.Windows.Controls.DataGrid
    {
        private MyDataGridByRightFrozen _rightDataGrid;

        private ScrollViewer _scrollViewer;

        private ScrollViewer _rightScrollViewer;


        [Bindable(true)]
        public Thickness DateGridBorderThickness
        {
            get { return (Thickness)GetValue(DateGridBorderThicknessProperty); }
            set { SetValue(DateGridBorderThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditingComboBoxColumnStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DateGridBorderThicknessProperty =
            DependencyProperty.Register("DateGridBorderThickness", typeof(Thickness), typeof(MyDataGrid), new PropertyMetadata(new Thickness(1, 0, 1, 0)));


        public bool IsRightFrozen
        {
            set { SetValue(IsRightFrozenProperty, value); }
            get { return (bool)GetValue(IsRightFrozenProperty); }
        }


        public static readonly DependencyProperty IsRightFrozenProperty = DependencyProperty.Register("IsRightFrozen", typeof(bool), typeof(MyDataGrid),new PropertyMetadata(false));


        private static readonly DependencyPropertyKey RightFrozenColumnsViewportLengthPropertyKey = DependencyProperty.RegisterReadOnly(
"RightFrozenColumnsViewportLength", typeof(double), typeof(MyDataGrid), new PropertyMetadata(
   0d));
        public static readonly DependencyProperty RightFrozenColumnsViewportLengthProperty = RightFrozenColumnsViewportLengthPropertyKey.DependencyProperty;
        public double RightFrozenColumnsViewportLength
        {
            get { return (double)GetValue(RightFrozenColumnsViewportLengthProperty); }
            internal set { SetValue(RightFrozenColumnsViewportLengthPropertyKey, value); }
        }


        public int RightFrozenCount
        {
            get
            {
                return (int)GetValue(RightFrozenCountProperty);
            }
            set
            {
                SetValue(RightFrozenCountProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for RightFrozenCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RightFrozenCountProperty =
            DependencyProperty.Register(nameof(RightFrozenCount), typeof(int), typeof(MyDataGrid), new PropertyMetadata(0, OnRightFrozenCountChanged));

        private static void OnRightFrozenCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MyDataGrid MyDataGridCtr)
            {
                MyDataGridCtr.ExcuteRightFrozenCountChanged();
            }
        }



        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.Loaded -= ExcuteLoad;
            this.Loaded += ExcuteLoad; 
            _scrollViewer = GetTemplateChild("DG_ScrollViewer") as ScrollViewer;
            if (_scrollViewer != null)
            {
                _scrollViewer.ScrollChanged += ScrollViewer_ScrollChanged;
            }
            _rightDataGrid = GetTemplateChild("PART_Right") as MyDataGridByRightFrozen;

            if (_rightDataGrid != null)
            {
                
                _rightDataGrid.ScrollViewerChanged += ExCuteRightScrollViewerChanged;
                _rightDataGrid.SelectionChanged += ExcuteRightDataGrid_SelectionChanged;
            }
            this.SelectionChanged += DataGridRightFrozen_SelectionChanged;
        
        }

        private void ExcuteLoad(object sender, RoutedEventArgs e)
        {
            ExcuteRightFrozenCountChanged();
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (_rightScrollViewer != null)
            {
                _rightScrollViewer?.ScrollToVerticalOffset(_scrollViewer.VerticalOffset);
            }
        }

        private void DataGridRightFrozen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {          
            if (_rightDataGrid != null)
            {
                _rightDataGrid.SetCurrentValue(SelectedItemProperty, SelectedItem);
            }
        }

        private void ExCuteRightScrollViewerChanged(ScrollViewer viewer)
        {
            _rightScrollViewer = viewer;
            _rightScrollViewer.ScrollChanged += _rightScrollViewer_ScrollChanged;

        }
        private void _rightScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (_scrollViewer != null)
            {
                _scrollViewer?.ScrollToVerticalOffset(_rightScrollViewer.VerticalOffset);
            }
        }

        private void ExcuteRightDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.SetCurrentValue(SelectedItemProperty, _rightDataGrid.SelectedItem);
        }

        

        private void ExcuteRightFrozenCountChanged()
        {
            if (RightFrozenCount > 0)
            {
                DateGridBorderThickness = new Thickness(1, 0, 0, 0);
            }
            else
            {
                DateGridBorderThickness = new Thickness(1, 0, 1, 0);
            }
            if (_rightDataGrid != null)
            {
                _rightDataGrid.RowHeight = this.RowHeight;
                if (RightFrozenCount > 0)
                {
                    for (int i = 0; i < _rightDataGrid.Columns.Count; i++)
                    {
                        var column = _rightDataGrid.Columns[i];
                        _rightDataGrid.Columns.Remove(column);

                        this.Columns.Add(column);
                    }
                    for (int i = 0; i < RightFrozenCount; i++)
                    {
                        var last = Columns[Columns.Count - 1];
                        this.Columns.Remove(last);

                        _rightDataGrid.Columns.Insert(0, last);
                    }
                    _rightDataGrid.SetCurrentValue(VisibilityProperty, Visibility.Visible);
                }
                else
                {
                    _rightDataGrid.SetCurrentValue(VisibilityProperty, Visibility.Collapsed);
                }
            }
        }

    }
}
