using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyWLUiDemo.Args
{

    /// <summary>
    /// LCL
    /// 事件绑定Trigger
    /// </summary>
    public class RoutedEventTrigger : EventTriggerBase<DependencyObject>
    {
        /// <summary>
        /// 路由事件/附加事件
        /// </summary>
        public RoutedEvent RoutedEvent { get; set; }

        protected override void OnAttached()
        {
            FrameworkElement associatedElement = AssociatedObject as FrameworkElement;

            if (AssociatedObject is Behavior behavior)
            {
                associatedElement = ((IAttachedObject)behavior).AssociatedObject as FrameworkElement;
            }

            if (associatedElement == null)
            {
                throw new ArgumentException("Routed Event trigger can only be associated to framework elements");
            }

            if (RoutedEvent != null)
            {
                associatedElement.AddHandler(RoutedEvent, new RoutedEventHandler(OnRoutedEvent));
            }
        }

        void OnRoutedEvent(object sender, RoutedEventArgs args)
        {
            base.OnEvent(args);
        }

        protected override string GetEventName()
        {
            return RoutedEvent.Name;
        }
    }
}
