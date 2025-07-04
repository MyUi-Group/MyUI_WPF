using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MyWLUi.Controls
{
    internal class MyCalendarButton:Button
    {
        /// <summary>
        /// 获取或设置该日期是否高亮(多日期模式下多选)
        /// </summary>
        public bool IsHighlight
        {
            get { return (bool)GetValue(IsHighlightProperty); }
            set { SetValue(IsHighlightProperty, value); }
        }
        public static readonly DependencyProperty IsHighlightProperty =
            DependencyProperty.Register("IsHighlight", typeof(bool), typeof(MyCalendarButton), new PropertyMetadata(false));



        public bool IsToday
        {
            get { return (bool)GetValue(IsTodayProperty); }
            set { SetValue(IsTodayProperty, value); }
        }
        public static readonly DependencyProperty IsTodayProperty =
            DependencyProperty.Register("IsToday", typeof(bool), typeof(MyCalendarButton), new PropertyMetadata(false));

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(MyCalendarButton), new PropertyMetadata(false));



        public bool IsBelongCurrentMonth
        {
            get { return (bool)GetValue(IsBelongCurrentMonthProperty); }
            set { SetValue(IsBelongCurrentMonthProperty, value); }
        }
        public static readonly DependencyProperty IsBelongCurrentMonthProperty =
            DependencyProperty.Register("IsBelongCurrentMonth", typeof(bool), typeof(MyCalendarButton), new PropertyMetadata(false));

    }
}
