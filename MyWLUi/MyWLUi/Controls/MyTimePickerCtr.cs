using MyWLUi.Args;
using MyWLUi.Controls.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace MyWLUi.Controls
{
    public class MyTimePickerCtr : CustomCtrBase
    {
        public Popup Date_Popup;
        private MyTimeSelector MyTimeSelectorItem;
        public string CurrentTime
        {
            set { SetValue(CurrentTimeProperty, value); }
            get { return (string)GetValue(CurrentTimeProperty); }
        }


        public static readonly DependencyProperty CurrentTimeProperty = DependencyProperty.Register("CurrentTime", typeof(string), typeof(MyTimePickerCtr), new PropertyMetadata(DateTime.Now.ToString("HH:mm:ss")));


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Date_Popup = GetTemplateChild("Date_Popup") as Popup;
            MyTimeSelectorItem= GetTemplateChild("MyTimeSelectorItem") as MyTimeSelector;
            if (Date_Popup==null|| MyTimeSelectorItem==null) 
            {
                throw new Exception("时间控件初始化失败");
            }
            MyTimeSelectorItem.DateChanged -= ExcuteDateChangedEvent;
            MyTimeSelectorItem.DateChanged += ExcuteDateChangedEvent;
            MyTimeSelectorItem.Owener = this;
            this.Loaded -= ExcuteLoad;
            this.Loaded += ExcuteLoad;
        }

        private void ExcuteDateChangedEvent(object sender, MyCustomRoutEventArgs<DateTime> e)
        {
            CurrentTime = e.Info.ToString("HH:mm:ss");
        }

        private void ExcuteLoad(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
