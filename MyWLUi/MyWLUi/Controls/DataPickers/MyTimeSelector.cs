using MyUi.Args;
using MyUi.Controls.Base;
using  MyUi.Global;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace MyUi.Controls
{
    public class MyTimeSelector : CustomCtrBase
    {

        private ListBox PART_Hour;
        private ListBox PART_Minute;
        private ListBox PART_Second;
        public MyTimePickerCtr Owener;
        private ObservableCollection<MyTimeSelectButton> HourButtons = new ObservableCollection<MyTimeSelectButton>();
        private ObservableCollection<MyTimeSelectButton> MinuteButtons = new ObservableCollection<MyTimeSelectButton>();
        private ObservableCollection<MyTimeSelectButton> SecondButtons = new ObservableCollection<MyTimeSelectButton>();

        private int HoursTypeNum = 24;


        public DateTime SelectTime
        {
            get { return (DateTime)GetValue(SelectTimeProperty); }
            set { SetValue(SelectTimeProperty, value); }
        }

        public static readonly DependencyProperty SelectTimeProperty =
            DependencyProperty.Register("SelectTime", typeof(DateTime), typeof(MyTimeSelector));


        public DataPickerTypeEnum DataPickerType
        {
            get { return (DataPickerTypeEnum)GetValue(DataPickerTypeProperty); }
            set { SetValue(DataPickerTypeProperty, value); }
        }

        public static readonly DependencyProperty DataPickerTypeProperty =
            DependencyProperty.Register("DataPickerType", typeof(DataPickerTypeEnum), typeof(MyTimeSelector));




        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            PART_Hour = GetTemplateChild("PART_Hour") as ListBox;
            PART_Minute = GetTemplateChild("PART_Minute") as ListBox;
            PART_Second = GetTemplateChild("PART_Second") as ListBox;
            if (PART_Hour==null|| PART_Minute==null|| PART_Second==null) 
            {
                throw new Exception("初始化时间选择控件失败");
            }
            this.Loaded -= ExcuteLoad;
            this.Loaded += ExcuteLoad;
            if (Owener!=null) 
            {
                SelectTime = Convert.ToDateTime(Owener.CurrentTime);
            }
           
            CreatHoursButton();
            CreatMinuteButtons();
            CreatSecondButtons();
            SetDefaultButtonState();
        }


        private void CreatHoursButton() 
        {
            for (int i = 0; i < HoursTypeNum; i++)
            {
                MyTimeSelectButton timeButton = new MyTimeSelectButton();
                timeButton.PreviewMouseDown -= ExcuteHoursButtonMouseDown;
                timeButton.PreviewMouseDown += ExcuteHoursButtonMouseDown;
                timeButton.SetValue(MyTimeSelectButton.DataContextProperty, i);
                timeButton.SetValue(MyTimeSelectButton.ContentProperty, (i < 10) ? "0" + i : i.ToString());
                timeButton.SetValue(MyTimeSelectButton.IsSelectedProperty, false);
                HourButtons.Add(timeButton);
            }
            PART_Hour.ItemsSource = HourButtons;
        }

    

        private void CreatMinuteButtons() 
        {
            for (int i = 0; i < 60; i++)
            {
                MyTimeSelectButton timeButton = new MyTimeSelectButton();
                timeButton.PreviewMouseDown -= ExcuteMinuteButtonMouseDown;
                timeButton.PreviewMouseDown += ExcuteMinuteButtonMouseDown;
                timeButton.SetValue(MyTimeSelectButton.DataContextProperty, i);
                timeButton.SetValue(MyTimeSelectButton.ContentProperty, (i < 10) ? "0" + i : i.ToString());
                timeButton.SetValue(MyTimeSelectButton.IsSelectedProperty, false);
                MinuteButtons.Add(timeButton);
            }
            PART_Minute.ItemsSource=MinuteButtons;
        }

    

        private void CreatSecondButtons() 
        {
            for (int i = 0; i < 60; i++)
            {
                MyTimeSelectButton timeButton = new MyTimeSelectButton();
                timeButton.PreviewMouseDown -= ExcuteSecondButtonMouseDown;
                timeButton.PreviewMouseDown += ExcuteSecondButtonMouseDown;
                timeButton.SetValue(MyTimeSelectButton.DataContextProperty, i);
                timeButton.SetValue(MyTimeSelectButton.ContentProperty, (i < 10) ? "0" + i : i.ToString());
                timeButton.SetValue(MyTimeSelectButton.IsSelectedProperty, false);
                SecondButtons.Add(timeButton);
            }
            PART_Second.ItemsSource = SecondButtons;
        }

        private void SetDefaultButtonState() 
        {
            if (Owener==null) 
            {
                return;
            }
            int _hour = SelectTime.Hour;
            int _minute = SelectTime.Minute;
            int _second = SelectTime.Second;
            foreach (var itme in PART_Hour.Items) 
            {
                if (itme is MyTimeSelectButton itemButton) 
                {
                    int _h = Convert.ToInt32(itemButton.DataContext);
                    if (_hour== _h) 
                    {
                        itemButton.IsSelected = true;
                        break;
                    }
                }
            }

            foreach (var itme in PART_Minute.Items)
            {
                if (itme is MyTimeSelectButton itemButton)
                {
                    int _m = Convert.ToInt32(itemButton.DataContext);
                    if (_minute == _m)
                    {
                        itemButton.IsSelected = true;
                        break;
                    }
                }
            }

            foreach (var itme in PART_Second.Items)
            {
                if (itme is MyTimeSelectButton itemButton)
                {
                    int _s = Convert.ToInt32(itemButton.DataContext);
                    if (_second == _s)
                    {
                        itemButton.IsSelected = true;
                        break;
                    }
                }
            }
        }


        private void ClearHourButtonState(MyTimeSelectButton _CurrentButton) 
        {
            foreach (var itme in PART_Hour.Items)
            {
                if (itme is MyTimeSelectButton itemButton)
                {
                    if (_CurrentButton!= itemButton) 
                    {
                        itemButton.IsSelected= false;
                    }
                }
            }
        }

        private void ClearMinutButtonState(MyTimeSelectButton _CurrentButton)
        {
            foreach (var itme in PART_Minute.Items)
            {
                if (itme is MyTimeSelectButton itemButton)
                {
                    if (_CurrentButton != itemButton)
                    {
                        itemButton.IsSelected = false;
                    }
                }
            }
        }

        private void ClearSecondtButtonState(MyTimeSelectButton _CurrentButton)
        {
            foreach (var itme in PART_Second.Items)
            {
                if (itme is MyTimeSelectButton itemButton)
                {
                    if (_CurrentButton != itemButton)
                    {
                        itemButton.IsSelected = false;
                    }
                }
            }
        }

        private void ExcuteHoursButtonMouseDown(object sender, MouseButtonEventArgs e)
        {
            var _itemButton = sender as MyTimeSelectButton;
            ClearHourButtonState(_itemButton);
            SelectTime = new DateTime(SelectTime.Year, SelectTime.Month, SelectTime.Day,Convert.ToInt32(_itemButton.DataContext), SelectTime.Minute, SelectTime.Second);
            ExcuteMyCustomEvent(null);
        }

        private void ExcuteMinuteButtonMouseDown(object sender, MouseButtonEventArgs e)
        {
            var _itemButton = sender as MyTimeSelectButton;
            ClearMinutButtonState(_itemButton);
            SelectTime = new DateTime(SelectTime.Year, SelectTime.Month, SelectTime.Day, SelectTime.Hour, Convert.ToInt32(_itemButton.DataContext), SelectTime.Second);
            ExcuteMyCustomEvent(null);
        }

        private void ExcuteSecondButtonMouseDown(object sender, MouseButtonEventArgs e)
        {
            var _itemButton = sender as MyTimeSelectButton;
            ClearSecondtButtonState(_itemButton);
            SelectTime = new DateTime(SelectTime.Year, SelectTime.Month, SelectTime.Day, SelectTime.Hour, SelectTime.Minute, Convert.ToInt32(_itemButton.DataContext));
            ExcuteMyCustomEvent(null);
        }

        private void ExcuteLoad(object sender, RoutedEventArgs e)
        {
            
        }

        public override void ExcuteMyCustomEvent(object ItemBoj)
        {
            RaiseEvent(new MyCustomRoutEventArgs<DateTime>(DateChangedEvent, this)
            {
                Info = this.SelectTime
            });
        }

    }
}
