using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace MyUi.Controls
{
    internal class MyDataGridByRightFrozen:MyDataGrid
    {
        bool isItemRefresh = false;

        public ScrollViewer ScrollViewer
        {
            get; set;
        }

        public Action<ScrollViewer> ScrollViewerChanged;


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.Loaded -= LoadCtr;
            this.Loaded += LoadCtr;
            ScrollViewer = GetTemplateChild("DG_ScrollViewer") as ScrollViewer;
            if (ScrollViewer != null)
            {
                
                ScrollViewer.ScrollChanged += ScrollViewer_ScrollChanged;
            }
           
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ScrollViewerChanged?.Invoke(this.ScrollViewer);
        }

        public MyDataGridByRightFrozen()
        {
           
        }

        private void LoadCtr(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 监听行变化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
            if (e.Action != NotifyCollectionChangedAction.Add)
            {
                //防止当前视图出现递归刷新
                if (!isItemRefresh)
                {
                    isItemRefresh = true;
                    /////////重新渲染视图/////////
                    this.Items.Refresh();
                    isItemRefresh = false;
                }
            }
        }
        protected override void OnLoadingRow(DataGridRowEventArgs e)
        {
            base.OnLoadingRow(e);

            MyItemsControlHelper.SetLineNumber(e.Row, e.Row.GetIndex() + 1);
        }
    }
}
