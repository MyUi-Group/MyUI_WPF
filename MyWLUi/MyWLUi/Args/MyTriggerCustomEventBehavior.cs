using Microsoft.Xaml.Behaviors;
using MyUi.Controls.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace MyUi.Args
{
    public class MyTriggerCustomEventBehavior : Behavior<CustomCtrBase>
    {
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                name: "Command",
                typeof(ICommand),
                typeof(MyTriggerCustomEventBehavior));

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PageDateUpdate += ToExcutePageDateUpdate;
            AssociatedObject.Loaded += ExcuteLoad;
        }

        private void ToExcutePageDateUpdate(object sender, MyCustomRoutEventArgs<int> e)
        {
            Command?.Execute(e.Info);
        }

        private void ExcuteLoad(object sender, RoutedEventArgs e)
        {
            AssociatedObject?.ExcuteMyCustomEvent(null);
        }

        protected override void OnDetaching()
        {           
            base.OnDetaching();
            AssociatedObject.PageDateUpdate -= ToExcutePageDateUpdate;
            AssociatedObject.Loaded -= ExcuteLoad;
        }

    
    }
}
