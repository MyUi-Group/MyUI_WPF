using  MyUi.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyUi.Controls
{
    public class MyTabControlExten
    {
        public static void SetTabControlType(DependencyObject obj, object value)
        {
            obj.SetValue(TabControlTypeProperty, value);
        }
        public static object GetTabControlType(DependencyObject obj)
        {
            return obj.GetValue(TabControlTypeProperty);
        }

        public static readonly DependencyProperty TabControlTypeProperty =
            DependencyProperty.RegisterAttached("TabControlType", typeof(TabControlTypeEnum), typeof(MyTabControlExten));



    }
}
