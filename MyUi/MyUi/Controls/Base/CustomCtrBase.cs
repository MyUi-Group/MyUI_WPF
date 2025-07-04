using MyUi.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyUi.Controls.Base
{
    public class CustomCtrBase : System.Windows.Controls.Control
    {
        public event EventHandler<MyCustomRoutEventArgs<int>> PageDateUpdate
        {
            add { AddHandler(PageDateUpdateEvent, value); }
            remove { RemoveHandler(PageDateUpdateEvent, value); }
        }


        public static readonly RoutedEvent PageDateUpdateEvent = EventManager.RegisterRoutedEvent("PageDateUpdate", RoutingStrategy.Bubble, typeof(EventHandler<MyCustomRoutEventArgs<int>>), typeof(CustomCtrBase));



        public event EventHandler<MyCustomRoutEventArgs<DateTime>> DateChanged
        {
            add { AddHandler(DateChangedEvent, value); }
            remove { RemoveHandler(DateChangedEvent, value); }
        }


        public static readonly RoutedEvent DateChangedEvent = EventManager.RegisterRoutedEvent("DateChanged", RoutingStrategy.Bubble, typeof(EventHandler<MyCustomRoutEventArgs<DateTime>>), typeof(CustomCtrBase));



        public event EventHandler<MyCustomRoutEventArgs<bool>> IsDateHandConfirm
        {
            add { AddHandler(IsDateHandConfirmEvent, value); }
            remove { RemoveHandler(IsDateHandConfirmEvent, value); }
        }


        public static readonly RoutedEvent IsDateHandConfirmEvent = EventManager.RegisterRoutedEvent("IsDateHandConfirm", RoutingStrategy.Bubble, typeof(EventHandler<MyCustomRoutEventArgs<bool>>), typeof(CustomCtrBase));



        public virtual void ExcuteMyCustomEvent(object ItemBoj) { }


    }
}
