using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyUi.Controls
{
    internal class MyItemsControlHelper
    {
        /// <summary>
        /// 获得列表当前行号
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetLineNumber(DependencyObject obj)
        {
            return (int)obj.GetValue(LineNumberProperty);
        }
        /// <summary>
        /// 设置列表当前行号
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static void SetLineNumber(DependencyObject obj, int value)
        {
            obj.SetValue(LineNumberProperty, value);
        }

        // Using a DependencyProperty as the backing store for Index.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LineNumberProperty =
            DependencyProperty.RegisterAttached("LineNumber", typeof(int), typeof(MyItemsControlHelper));

    }
}
