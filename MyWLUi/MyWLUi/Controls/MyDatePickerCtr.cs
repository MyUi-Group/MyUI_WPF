using MyWLUi.Args;
using MyWLUi.Controls.Base;
using MyWLUi.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace MyWLUi.Controls
{
    public class MyDatePickerCtr : CustomCtrBase
    {

        private Popup Date_Popup;

        public Popup TimeSelect_Popup;

        private Button Confirm_Button;


        public MyCalendar MyCalendar_One;

        public MyCalendar MyCalendar_Second;

        private ToggleButton SelectTimeToggleButton;


        public MyTimeSelector MyTimeSelectorItem;

        public MyTimeSelector MyTimeSelectorItem_Second;
        public string CurrentDate
        {
            set { SetValue(CurrentDateProperty, value); }
            get { return (string)GetValue(CurrentDateProperty); }
        }


        public static readonly DependencyProperty CurrentDateProperty = DependencyProperty.Register("CurrentDate", typeof(string),typeof(MyDatePickerCtr));



        /// <summary>
        /// 用于控制多日历模式下 前后选择日历时的两个控件是否联动变化
        /// </summary>
        public bool IsRelevance
        {
            set { SetValue(IsRelevanceProperty, value); }
            get { return (bool)GetValue(IsRelevanceProperty); }
        }


        public static readonly DependencyProperty IsRelevanceProperty = DependencyProperty.Register("IsRelevance", typeof(bool), typeof(MyDatePickerCtr), new PropertyMetadata(true));



        public bool IsExtenShowTime 
        {
            set { SetValue(IsExtenShowTimeProperty, value); }
            get { return (bool)GetValue(IsExtenShowTimeProperty); }
        }


        public static readonly DependencyProperty IsExtenShowTimeProperty = DependencyProperty.Register("IsExtenShowTime",typeof(bool),typeof(MyDatePickerCtr),new PropertyMetadata(false));


        public SelectTimeTypeEnum SelectTimeType
        {
            set { SetValue(SelectTimeTypeProperty, value); }
            get { return (SelectTimeTypeEnum)GetValue(SelectTimeTypeProperty); }
        }


        public static readonly DependencyProperty SelectTimeTypeProperty = DependencyProperty.Register("SelectTimeType", typeof(SelectTimeTypeEnum), typeof(MyDatePickerCtr), new PropertyMetadata(SelectTimeTypeEnum.SelectTime));


        public DataPickerTypeEnum DataPickerType 
        {
            get 
            {
                return (DataPickerTypeEnum)this.GetValue(ElementExten.DataPickerTypeProperty);
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (DataPickerType == DataPickerTypeEnum.One)
            {
                CurrentDate = IsExtenShowTime ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : DateTime.Now.ToString("yyyy年MM月dd");
            }
            else 
            {
                CurrentDate = IsExtenShowTime ? DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd HH:mm:ss")+"~"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : DateTime.Now.AddMonths(-1).ToString("yyyy年MM月dd")+"~"+ DateTime.Now.ToString("yyyy年MM月dd");
            }
           
            Date_Popup = GetTemplateChild("Date_Popup") as Popup;
            TimeSelect_Popup= GetTemplateChild("TimeSelect_Popup") as Popup;
            MyCalendar_One = GetTemplateChild("MyCalendar_One") as MyCalendar;
            MyCalendar_Second= GetTemplateChild("MyCalendar_Second") as MyCalendar;
            SelectTimeToggleButton = GetTemplateChild("SelectTimeToggleButton") as ToggleButton;
            MyTimeSelectorItem = GetTemplateChild("MyTimeSelectorItem") as MyTimeSelector;
            MyTimeSelectorItem_Second= GetTemplateChild("MyTimeSelectorItem_Second") as MyTimeSelector;
            Confirm_Button = GetTemplateChild("Confirm_Button") as Button;
            if (Date_Popup==null|| MyCalendar_One==null) 
            {
                throw new Exception("初始化日历控件失败");
            }
            MyCalendar_One.Owener = this;

            if (MyCalendar_Second!=null) 
            {
                MyCalendar_Second.Owener= this;
            }

            this.Date_Popup.Opened -= ExcuteDate_PopupOpened;
            this.Date_Popup.Opened += ExcuteDate_PopupOpened;
            this.Date_Popup.Closed -= ExcuteDate_ClosedPopup;
            this.Date_Popup.Closed += ExcuteDate_ClosedPopup;


            if (SelectTimeToggleButton != null)
            {
                SelectTimeToggleButton.PreviewMouseDown -= ExcuteSelectTimeToggleButtonDown;
                SelectTimeToggleButton.PreviewMouseDown += ExcuteSelectTimeToggleButtonDown;   
            }

            if (MyTimeSelectorItem!=null) 
            {
                MyTimeSelectorItem.DateChanged -= ExcuteDateChangedEvent;
                MyTimeSelectorItem.DateChanged += ExcuteDateChangedEvent;
            }

            if (MyTimeSelectorItem_Second != null)
            {
                MyTimeSelectorItem_Second.DateChanged -= ExcuteDateChangedEvent;
                MyTimeSelectorItem_Second.DateChanged += ExcuteDateChangedEvent;
            }

            if (Confirm_Button!=null) 
            {
                Confirm_Button.PreviewMouseDown -= ExcuteConfirm_ButtonDown;
                Confirm_Button.PreviewMouseDown += ExcuteConfirm_ButtonDown;
            }

            this.Loaded -= ExcuteLoaded;
            this.Loaded += ExcuteLoaded;

            this.Unloaded -= ExcuteUnloaded;
            this.Unloaded += ExcuteUnloaded;
        }



        private void ExcuteConfirm_ButtonDown(object sender, MouseButtonEventArgs e)
        {
            Date_Popup.IsOpen = false;
        }

   

        private void ExcuteSelectTimeToggleButtonDown(object sender, RoutedEventArgs e)
        {
            switch (SelectTimeType)
            {
                case SelectTimeTypeEnum.SelectTime:
                    SelectTimeType = SelectTimeTypeEnum.SelectDate;
                    break;
                case SelectTimeTypeEnum.SelectDate:
                    SelectTimeType = SelectTimeTypeEnum.SelectTime;
                    break;
            }
        }


        private void ExcuteLoaded(object sender, RoutedEventArgs e)
        {
            if (MyCalendar_One!=null) 
            {
                MyCalendar_One.DateChanged -= ExcuteDateChanged;
                MyCalendar_One.DateChanged += ExcuteDateChanged;

                MyCalendar_One.IsDateHandConfirm -= ExcuteDateHandConfirm;
                MyCalendar_One.IsDateHandConfirm += ExcuteDateHandConfirm; 
            }

            if (MyCalendar_Second!=null) 
            {
                MyCalendar_Second.DateChanged -= ExcuteDateChanged;
                MyCalendar_Second.DateChanged += ExcuteDateChanged;

                MyCalendar_Second.IsDateHandConfirm -= ExcuteDateHandConfirm;
                MyCalendar_Second.IsDateHandConfirm += ExcuteDateHandConfirm;
            }

        }

        private void ExcuteDateHandConfirm(object sender, MyCustomRoutEventArgs<bool> e)
        {
            if (Date_Popup == null)
            {
                return;
            }
            Date_Popup.IsOpen = !e.Info;
        }

        private void ExcuteUnloaded(object sender, RoutedEventArgs e)
        {
            if (MyCalendar_One != null) 
            {
                MyCalendar_One.DateChanged -= ExcuteDateChanged;
            }
            if (MyCalendar_Second != null)
            {
                MyCalendar_Second.DateChanged -= ExcuteDateChanged;
            }
        }

        private void ExcuteDateChangedEvent(object sender, MyCustomRoutEventArgs<DateTime> e)
        {
            switch (DataPickerType) 
            {
                case DataPickerTypeEnum.One:
                    CurrentDate = e.Info.ToString("yyyy-MM-dd HH:mm:ss");
                    break;
                case DataPickerTypeEnum.Double:
                    var _itemSlectCtr = sender as MyTimeSelector;
                    if (_itemSlectCtr != null)
                    {
                        string[] _timeArray = CurrentDate.Split('~');
                        DateTime _firstTime = Convert.ToDateTime(_timeArray[0]);
                        DateTime _secondTime = Convert.ToDateTime(_timeArray[1]);
                        if (_itemSlectCtr.DataPickerType == DataPickerTypeEnum.One)
                        {
                            _firstTime = new DateTime(e.Info.Year, e.Info.Month, e.Info.Day, e.Info.Hour, e.Info.Minute, e.Info.Second);
                        }
                        else 
                        {
                            _secondTime = new DateTime(e.Info.Year, e.Info.Month, e.Info.Day, e.Info.Hour, e.Info.Minute, e.Info.Second);
                        }
                        CurrentDate =  _firstTime.ToString("yyyy-MM-dd HH:mm:ss") + "~" + _secondTime.ToString("yyyy-MM-dd HH:mm:ss") ;
                    }
                    break;
            }
           
        }

        private void ExcuteDateChanged(object sender, MyCustomRoutEventArgs<DateTime> e)
        {
            if (Date_Popup==null) 
            {
                return;
            }
           
            switch (DataPickerType) 
            {
                case DataPickerTypeEnum.One:
                    CurrentDate = IsExtenShowTime ? e.Info.ToString("yyyy-MM-dd HH:mm:ss"): e.Info.ToString("yyyy年MM月dd");
                    break;
                case DataPickerTypeEnum.Double:
                    string[] _timeArray = CurrentDate.Split('~');
                    DateTime _firstTime = Convert.ToDateTime(_timeArray[0]);
                    DateTime _secondTime = Convert.ToDateTime(_timeArray[1]);
                    var _itemCalendar = sender as MyCalendar;
                    if (_itemCalendar != null) 
                    {
                        switch (_itemCalendar.DataPickerType) 
                        {
                            case DataPickerTypeEnum.One:
                                _firstTime = new DateTime(e.Info.Year, e.Info.Month, e.Info.Day, e.Info.Hour, e.Info.Minute, e.Info.Second);                              
                                break;
                            case DataPickerTypeEnum.Double:
                                _secondTime = new DateTime(e.Info.Year, e.Info.Month, e.Info.Day, e.Info.Hour, e.Info.Minute, e.Info.Second);
                                break;
                        }
                        CurrentDate = IsExtenShowTime ? _firstTime.ToString("yyyy-MM-dd HH:mm:ss") + "~" + _secondTime.ToString("yyyy-MM-dd HH:mm:ss") : _firstTime.ToString("yyyy年MM月dd") + "~" + _secondTime.ToString("yyyy年MM月dd");
                    }
                    break;
            }
          
        }

        private void ExcuteDate_PopupOpened(object sender, EventArgs e)
        {
            MyCalendar_One.DisplayMode = CalendarMode.Month;
            if (MyCalendar_Second!=null) 
            {
                MyCalendar_Second.DisplayMode = CalendarMode.Month;
            }
        }

        private void ExcuteDate_ClosedPopup(object sender, EventArgs e)
        {
            SelectTimeType = SelectTimeTypeEnum.SelectTime;
        }
    }
}
