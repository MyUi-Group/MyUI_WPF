using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyWLUi.Args
{
    public class MyCustomRoutEventArgs<T> : RoutedEventArgs
    {
        /// <summary>
        /// 目标参数
        /// </summary>
        public T Info { get; set; }
        public MyCustomRoutEventArgs(T info)
        {
            Info = info;
        }

        public MyCustomRoutEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {
        }

    }
}
