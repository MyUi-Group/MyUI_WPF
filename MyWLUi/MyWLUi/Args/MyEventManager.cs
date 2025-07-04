using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyWLUi.Args
{
    /// <summary>
    /// LCL
    /// 附加事件管理器
    /// </summary>
    public static class MyEventManager
    {
        public static readonly RoutedEvent SearchButtonDownEvent = EventManager.RegisterRoutedEvent("SearchButtonDown", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MyEventManager));
        public static void AddSearchButtonDownHandler(DependencyObject d, RoutedEventHandler handler)
        {
            (d as UIElement)?.AddHandler(SearchButtonDownEvent, handler);
        }
        public static void RemoveSearchButtonDownHandler(DependencyObject d, RoutedEventHandler handler)
        {
            (d as UIElement)?.RemoveHandler(SearchButtonDownEvent, handler);
        }
    }
}
