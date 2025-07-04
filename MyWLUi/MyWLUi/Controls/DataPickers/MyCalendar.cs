using MyWLUi.Args;
using MyWLUi.Controls.Base;
using MyWLUi.Global;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyWLUi.Controls
{
    public class MyCalendar:CustomCtrBase
    {

        public MyCalendarItem MyCalendarItemCtr;

        public MyDatePickerCtr Owener;


        public DateTime SelectDate { get; set; }

        public DateTime DisplayDate
        {
            get { return (DateTime)GetValue(DisplayDateProperty); }
            set { SetValue(DisplayDateProperty, value); }
        }

        public static readonly DependencyProperty DisplayDateProperty =
            DependencyProperty.Register("DisplayDate", typeof(DateTime), typeof(MyCalendar), new PropertyMetadata(DateTime.Today, ExcuteDisplayDateChanged));

        private static void ExcuteDisplayDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = d as MyCalendar;
            DateTime oldTime = Convert.ToDateTime(e.OldValue);
            DateTime newTime = Convert.ToDateTime(e.NewValue);
            if (calendar != null)
            {
                calendar.SelectDate = newTime;
                calendar.UpdateGridItems();
            }
        }


        public DataPickerTypeEnum DataPickerType
        {
            get { return (DataPickerTypeEnum)GetValue(DataPickerTypeProperty); }
            set { SetValue(DataPickerTypeProperty, value); }
        }

        public static readonly DependencyProperty DataPickerTypeProperty =
            DependencyProperty.Register("DataPickerType", typeof(DataPickerTypeEnum), typeof(MyCalendar));

      



        public CalendarMode DisplayMode
        {
            get { return (CalendarMode)GetValue(DisplayModeProperty); }
            set { SetValue(DisplayModeProperty, value); }
        }

        public static readonly DependencyProperty DisplayModeProperty =
            DependencyProperty.Register("DisplayMode", typeof(CalendarMode), typeof(MyCalendar), new PropertyMetadata(CalendarMode.Month, CalendarModeChange));

        private static void CalendarModeChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MyCalendar myItem)
            {
                if (myItem.MyCalendarItemCtr != null)
                {
                    myItem.MyCalendarItemCtr.ClearHigtLight();
                    switch (myItem.DisplayMode)
                    {
                        case CalendarMode.Month:
                            myItem.MyCalendarItemCtr.UpdateMonthMode();
                            break;
                        case CalendarMode.Year:
                            myItem.MyCalendarItemCtr.UpdateYearMode();
                            break;
                        case CalendarMode.Decade:
                            myItem.MyCalendarItemCtr.UpdateDecadeMode();
                            break;
                    }
                }              
            }
        }



        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            MyCalendarItemCtr= GetTemplateChild("MyCalendarItemCtr") as MyCalendarItem;
            if (MyCalendarItemCtr!=null) 
            {
                MyCalendarItemCtr.OwnerCtr = this;
            }
            this.Loaded -= ExcuteLoaded;
            this.Loaded += ExcuteLoaded;

          
        }



        private void ExcuteLoaded(object sender, RoutedEventArgs e)
        {
            if (Owener.DataPickerType == DataPickerTypeEnum.Double)
            {
                if (DataPickerType == DataPickerTypeEnum.One)
                {
                    DisplayDate = DateTime.Now.AddMonths(-1);
                }
            }
            if (!string.IsNullOrEmpty(this.Owener.CurrentDate))
            {
                if (this.Owener.DataPickerType == DataPickerTypeEnum.One)
                {
                    DisplayDate = Convert.ToDateTime(this.Owener.CurrentDate);
                }
                else
                {
                    string[] _arrayTime = this.Owener.CurrentDate.Split('~');
                    if (DataPickerType == DataPickerTypeEnum.One)
                    {
                        DisplayDate = Convert.ToDateTime(_arrayTime[0]);
                    }
                    else
                    {
                        DisplayDate = Convert.ToDateTime(_arrayTime[1]);
                    }
                }
            }
        }


        public override void ExcuteMyCustomEvent(object item)
        {
            if (DisplayMode== CalendarMode.Month)
            {
                RaiseEvent(new MyCustomRoutEventArgs<DateTime>(DateChangedEvent, this)
                {
                    Info = this.DisplayDate
                });
            }
        }

        private void UpdateGridItems()
        {
            if (MyCalendarItemCtr==null) 
            {
                return;
            }
            this.MyCalendarItemCtr.ClearHigtLight();
            switch (this.DisplayMode)
            {
                case CalendarMode.Month:
                    this.MyCalendarItemCtr.UpdateMonthMode();
                    break;
                case CalendarMode.Year:
                    this.MyCalendarItemCtr.UpdateYearMode();
                    break;
                case CalendarMode.Decade:
                    this.MyCalendarItemCtr.UpdateDecadeMode();
                    break;
                default:
                    break;
            }
        }

    }
}
