using MyUi.Args;
using MyUi.Controls.Base;
using  MyUi.Global;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;


namespace MyUi.Controls
{
    public class MyCalendarItem : CustomCtrBase
    {
        private Button Head_Button;

        public Button Preview_Button;

        public Button Next_Button;

        public Button PreviewYear_Button;

        public Button NextYear_Button;

        private Grid Date_Contian_Grid;

        private Grid Month_Contian_Grid;

     

        public MyCalendar OwnerCtr;


        private MyCalendarButton[,] CalendarDayButtons = new MyCalendarButton[7, 7];
        private MyCalendarButton[,] CalendarButtons = new MyCalendarButton[3, 4];


        private DateTime MonthViewJudgeTime;

   
        private DateTime ShowTime 
        {
            get
            {
                if (this.OwnerCtr == null)
                {
                    return DateTime.Today;
                }
                return this.OwnerCtr.DisplayDate;
            }
        }






        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Head_Button = GetTemplateChild("Head_Button") as Button;
            PreviewYear_Button= GetTemplateChild("PreviewYear_Button") as Button;
            Preview_Button = GetTemplateChild("Preview_Button") as Button;
            Next_Button = GetTemplateChild("Next_Button") as Button;
            NextYear_Button= GetTemplateChild("NextYear_Button") as Button;
            Date_Contian_Grid = GetTemplateChild("Date_Contian_Grid") as Grid;
            Month_Contian_Grid = GetTemplateChild("Month_Contian_Grid") as Grid;
           
            if (Head_Button!=null&& Preview_Button != null&& Next_Button != null) 
            {
                Head_Button.Click -= ExcuteHead_ButtonClick;
                Head_Button.Click += ExcuteHead_ButtonClick;

                Preview_Button.Click -= ExcutePreview_ButtonClick;
                Preview_Button.Click += ExcutePreview_ButtonClick;

                Next_Button.Click -= ExcuteNext_ButtonClick;
                Next_Button.Click += ExcuteNext_ButtonClick;
            }
    
            InitMonthDayView();
            InitMonthGrid();
            this.Loaded -= ExcuteLoad;
            this.Loaded += ExcuteLoad;
            if (this.OwnerCtr!=null) 
            {
                if (this.OwnerCtr.Owener.DataPickerType== DataPickerTypeEnum.Double)
                {
                    this.PreviewYear_Button.PreviewMouseDown -= ExcutePreviewYear_ButtonDown;
                    this.PreviewYear_Button.PreviewMouseDown += ExcutePreviewYear_ButtonDown;

                    this.NextYear_Button.PreviewMouseDown -= ExcuteNextYear_ButtonDown;
                    this.NextYear_Button.PreviewMouseDown += ExcuteNextYear_ButtonDown;
                    if (this.OwnerCtr.DataPickerType == DataPickerTypeEnum.One)
                    {
                        this.Next_Button.Visibility = Visibility.Hidden;
                        this.NextYear_Button.Visibility = Visibility.Hidden;
                    }
                    else if (this.OwnerCtr.DataPickerType == DataPickerTypeEnum.Double)
                    {
                        this.Preview_Button.Visibility = Visibility.Hidden;
                        this.PreviewYear_Button.Visibility = Visibility.Hidden;
                       
                    }
                }
            
            }
        }

        private void SetButtonStateOnDoube(bool _isShow)
        {
            if (this.OwnerCtr.Owener.DataPickerType == DataPickerTypeEnum.Double)
            {
                if (this.OwnerCtr.DataPickerType == DataPickerTypeEnum.One) 
                {
                    this.Preview_Button.Visibility = _isShow ? Visibility.Visible : Visibility.Hidden;
                   
                }
                else if (this.OwnerCtr.DataPickerType == DataPickerTypeEnum.Double)
                {

                    this.Next_Button.Visibility = _isShow ? Visibility.Visible : Visibility.Hidden;
                }
                
                
            }
        }

        private void ExcutePreviewYear_ButtonDown(object sender, MouseButtonEventArgs e)
        {
            int year = this.ShowTime.Year;
            int month = this.ShowTime.Month;
            switch (this.OwnerCtr.DisplayMode)
            {
                case CalendarMode.Month:
                case CalendarMode.Year:
                    if (this.OwnerCtr.Owener.IsRelevance)
                    {
                        this.OwnerCtr.Owener.MyCalendar_One.DisplayDate = new DateTime(year - 1, month, 1);
                        this.OwnerCtr.Owener.MyCalendar_Second.DisplayDate = new DateTime(year - 1, month, 1);
                    }
                    else 
                    {
                        this.OwnerCtr.DisplayDate = new DateTime(year - 1, month, 1);
                    }
                
                    break;
                case CalendarMode.Decade:
                    if (this.OwnerCtr.Owener.IsRelevance)
                    {
                        this.OwnerCtr.Owener.MyCalendar_One.DisplayDate = new DateTime(year - 10, month, 1);
                        this.OwnerCtr.Owener.MyCalendar_Second.DisplayDate = new DateTime(year - 10, month, 1);
                    }
                    else 
                    {
                        this.OwnerCtr.DisplayDate = new DateTime(year - 10, month, 1);                        
                    }
                  
                    break;
            }
        }

        private void ExcuteNextYear_ButtonDown(object sender, MouseButtonEventArgs e)
        {
            int year = this.ShowTime.Year;
            int month = this.ShowTime.Month;
            switch (this.OwnerCtr.DisplayMode)
            {
                case CalendarMode.Month:
                case CalendarMode.Year:
                    if (this.OwnerCtr.Owener.IsRelevance)
                    {
                        this.OwnerCtr.Owener.MyCalendar_One.DisplayDate = new DateTime(year + 1, month, 1);
                        this.OwnerCtr.Owener.MyCalendar_Second.DisplayDate = new DateTime(year + 1, month, 1);
                    }
                    else 
                    {
                        this.OwnerCtr.DisplayDate = new DateTime(year + 1, month, 1);
                    }
                    
                    break;
                case CalendarMode.Decade:
                    if (this.OwnerCtr.Owener.IsRelevance)
                    {
                        this.OwnerCtr.Owener.MyCalendar_One.DisplayDate = new DateTime(year + 10, month, 1);
                        this.OwnerCtr.Owener.MyCalendar_Second.DisplayDate = new DateTime(year + 10, month, 1);
                    }
                    else
                    {
                        this.OwnerCtr.DisplayDate = new DateTime(year + 10, month, 1);
                    }
                    
                    break;
            }
        }

        private void ExcuteLoad(object sender, RoutedEventArgs e)
        {
            SetMonthModeCalendarDayButtons();
        }


     
        public void UpdateMonthMode() 
        {
            SetDayHeaderButton();
            SetMonthModeDayTitles();
            SetMonthModeCalendarDayButtons();
        }

        public void ClearHigtLight() 
        {
            foreach (object item in this.Date_Contian_Grid.Children)
            {
                if (item is MyCalendarButton CalendarButtonItem) 
                {
                    CalendarButtonItem.IsSelected = false;
                    CalendarButtonItem.IsHighlight = false;
                }
            }

            foreach (object item in this.Month_Contian_Grid.Children)
            {
                if (item is MyCalendarButton CalendarButtonItem)
                {
                    CalendarButtonItem.IsSelected = false;
                    CalendarButtonItem.IsHighlight = false;
                }
            }
        }


        public void UpdateYearMode() 
        {
            SetMonthView();
        }

        public void UpdateDecadeMode() 
        {
            SetYearButtons();
        }

        private void InitMonthDayView() 
        {
            if (this.Date_Contian_Grid == null)
            {
                throw new Exception("初始化日期控件失败");
            }
           

            for (int i = 0; i < 7; i++)
            {
                MyCalendarButton calendarDayButton = new MyCalendarButton();              
                calendarDayButton.SetValue(Button.IsEnabledProperty, false);
                calendarDayButton.SetValue(Grid.RowProperty, 0);
                calendarDayButton.SetValue(Grid.ColumnProperty, i);
                this.Date_Contian_Grid.Children.Add(calendarDayButton);
                this.CalendarDayButtons[0, i] = calendarDayButton;
            }


   
            for (int j = 1; j < 7; j++)
            {
                for (int k = 0; k < 7; k++)
                {
                    MyCalendarButton calendarDayButton = new MyCalendarButton();
                  
                    calendarDayButton.SetValue(Grid.RowProperty, j);
                    calendarDayButton.SetValue(Grid.ColumnProperty, k);
                   
                    calendarDayButton.IsToday = false;
                    //calendarDayButton.IsBlackedOut = false;
                    calendarDayButton.IsSelected = false;

                    calendarDayButton.Click -= ExCuteMyCalendarButtonClick;
                    calendarDayButton.Click += ExCuteMyCalendarButtonClick;
                   
                    this.Date_Contian_Grid.Children.Add(calendarDayButton);
                    this.CalendarDayButtons[j, k] = calendarDayButton;
                }
            }


            SetMonthModeDayTitles();
            
        }

        private void InitMonthGrid()
        {
            if (this.Month_Contian_Grid == null)
            {
                throw new Exception("初始化日期控件失败");
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    MyCalendarButton calendarButton = new MyCalendarButton();
                    calendarButton.SetValue(Grid.RowProperty, i);
                    calendarButton.SetValue(Grid.ColumnProperty, j);
                    calendarButton.Click -= ExcuteMonthCalendarButtonClick;
                    calendarButton.Click += ExcuteMonthCalendarButtonClick;
                    this.Month_Contian_Grid.Children.Add(calendarButton);
                    this.CalendarButtons[i, j] = calendarButton;
                }
            }
        }

        public override void ExcuteMyCustomEvent(object ItemBoj)
        {
            RaiseEvent(new MyCustomRoutEventArgs<bool>(IsDateHandConfirmEvent, this)
            {
                Info = Convert.ToBoolean(ItemBoj)
            });       
        }

        private void ExCuteMyCalendarButtonClick(object sender, RoutedEventArgs e)
        {
            MyCalendarButton _itemButton = sender as MyCalendarButton;
            _itemButton.IsSelected = true;
            DateTime dateTime = (DateTime)_itemButton.DataContext;
            switch (this.OwnerCtr.DisplayMode)
            {
                case CalendarMode.Month:
                    if (this.OwnerCtr.Owener.IsExtenShowTime&&!string.IsNullOrEmpty(this.OwnerCtr.Owener.CurrentDate))
                    {
                        if (this.OwnerCtr.Owener.DataPickerType == DataPickerTypeEnum.Double)
                        {
                            string[] _arrayTime= this.OwnerCtr.Owener.CurrentDate.Split('~');
                            if (this.OwnerCtr.DataPickerType == DataPickerTypeEnum.One)
                            {
                                DateTime _STime = Convert.ToDateTime(_arrayTime[0]);

                                this.OwnerCtr.DisplayDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, _STime.Hour, _STime.Minute, _STime.Second);
                            }
                            else 
                            {
                                DateTime _STime = Convert.ToDateTime(_arrayTime[1]);

                                this.OwnerCtr.DisplayDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, _STime.Hour, _STime.Minute, _STime.Second);
                            }
                        }
                        else 
                        {
                            DateTime _STime = Convert.ToDateTime(this.OwnerCtr.Owener.CurrentDate);

                            this.OwnerCtr.DisplayDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, _STime.Hour, _STime.Minute, _STime.Second);
                        }
                    }
                    else
                    {                  
                        this.OwnerCtr.DisplayDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                    }
                    
                    if (this.OwnerCtr.Owener.DataPickerType == DataPickerTypeEnum.Double)
                    {
                        if (this.OwnerCtr.DataPickerType== DataPickerTypeEnum.Double) 
                        {
                            ExcuteMyCustomEvent(!this.OwnerCtr.Owener.IsExtenShowTime);
                        }
                    }
                    else 
                    {
                        ExcuteMyCustomEvent(!this.OwnerCtr.Owener.IsExtenShowTime);
                    }
                    this.OwnerCtr.ExcuteMyCustomEvent(null);
                    break;
            }
        }
        private void ExcuteMonthCalendarButtonClick(object sender, RoutedEventArgs e)
        {
            MyCalendarButton _itemButton= sender as MyCalendarButton;
            DateTime dateTime = (DateTime)_itemButton.DataContext;
            switch (this.OwnerCtr.DisplayMode)
            {
                case CalendarMode.Month:
                    break;
                case CalendarMode.Year:          
                    this.OwnerCtr.DisplayDate = new DateTime(dateTime.Year, dateTime.Month, 1);
 
                    this.OwnerCtr.DisplayMode = CalendarMode.Month;
                    break;
                case CalendarMode.Decade:
                    this.OwnerCtr.DisplayDate = new DateTime(dateTime.Year, this.ShowTime.Month, 1);
                    this.OwnerCtr.DisplayMode = CalendarMode.Year;
                    break;
            }
            SetButtonStateOnDoube(true);
            if (this.OwnerCtr.Owener.IsRelevance && this.OwnerCtr.Owener.DataPickerType == DataPickerTypeEnum.Double)
            {
                if (this.OwnerCtr.DataPickerType == DataPickerTypeEnum.One)
                {
                    ExcuteNext_ButtonMethod();
                }
                else
                {
                    ExcutePreview_ButtonMethod();
                }
            }
        }

        private void SetMonthView()
        {
            Head_Button.Content = OwnerCtr.DisplayDate.Year + "年";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int month = j + i * 4 + 1;
                    DateTime dateTime = new DateTime(OwnerCtr.DisplayDate.Year, month, 1);

                    this.CalendarButtons[i, j].DataContext = dateTime;
                    this.CalendarButtons[i, j].Content = month + "月";
                    this.CalendarButtons[i, j].Tag = month;
                    if (OwnerCtr.DisplayDate.Year== dateTime.Year&&dateTime.Month== OwnerCtr.DisplayDate.Month)
                    {
                        this.CalendarButtons[i, j].IsHighlight = true;
                    }
                }
            }
        }
      
        private void SetDayHeaderButton() 
        {
            if (OwnerCtr.DisplayDate.Month < 10)
            {
                Head_Button.Content = OwnerCtr.DisplayDate.Year + "年"+"0" + OwnerCtr.DisplayDate.Month + "月";
            }
            else 
            {
                Head_Button.Content = OwnerCtr.DisplayDate.Year + "年" + OwnerCtr.DisplayDate.Month + "月";
            }
            
        }

        private void SetMonthModeDayTitles()
        {
            string[] dayOfWeeks = new string[] { "日","一", "二", "三", "四", "五", "六" };

            for (int i = 0; i < 7; i++)
            {
                int index = (i + (int)DayOfWeek.Monday) % 7;
                this.CalendarDayButtons[0, i].Content = dayOfWeeks[index];
                this.CalendarDayButtons[0, i].IsHighlight = false;
            }
        }

        private void SetMonthModeCalendarDayButtons()
        {
            int year = OwnerCtr.DisplayDate.Year;
            int month = OwnerCtr.DisplayDate.Month;
            MonthViewJudgeTime= new DateTime(year, month, 1);
            int firstColIndex = (MonthViewJudgeTime.DayOfWeek - DayOfWeek.Monday + 7) % 7;

            int daysInMonth = DateTime.DaysInMonth(year, month);
            for (int i = 1; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    this.CalendarDayButtons[i, j].Content = "";
                    this.CalendarDayButtons[i, j].IsToday = false;
                    this.CalendarDayButtons[i, j].IsSelected = false;
                    this.CalendarDayButtons[i, j].IsHighlight = false;
                }
            }

            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime date = new DateTime(year, month, day);
                if (date > DateTime.MinValue && date < DateTime.MaxValue)
                {
                    int column, row;
                    row = (day + firstColIndex - 1) / 7 + 1;
                    column = (day + firstColIndex - 1) % 7;
                    this.CalendarDayButtons[row, column].IsBelongCurrentMonth = true;
                    this.CalendarDayButtons[row, column].IsToday = false;
                    this.CalendarDayButtons[row, column].IsSelected = false;
                    this.CalendarDayButtons[row, column].DataContext = date;
                    this.CalendarDayButtons[row, column].Content = day.ToString();
                    this.CalendarDayButtons[row, column].Tag = day;
                    this.CalendarDayButtons[row, column].IsHighlight = false;
                }
            }
            if (OwnerCtr.DisplayDate.Year == DateTime.Today.Year && OwnerCtr.DisplayDate.Month == DateTime.Today.Month)
            {
                this.SetTodayButtonHighlight();
            }

            this.ListOthertMonthDay(year, month);
           
            SetSelectButtonState();
        }

        private void SetTodayButtonHighlight()
        {
            //只有月模式下才高亮 “今日”
            if (this.OwnerCtr.DisplayMode == CalendarMode.Month)
            {
                foreach (object item in this.Date_Contian_Grid.Children)
                {
                    if (item is MyCalendarButton)
                    {
                        MyCalendarButton dayButton = item as MyCalendarButton;
                        if (dayButton.DataContext is DateTime)
                        {
                            DateTime dt = (DateTime)dayButton.DataContext;
                            if (dt == DateTime.Today)
                            {
                                dayButton.IsToday = true;
                                break;
                            }
                        }
                    }

                }
            }
        }


        private void SetSelectButtonState() 
        {
            if (this.OwnerCtr.DisplayMode == CalendarMode.Month)
            {
  
                foreach (object item in this.Date_Contian_Grid.Children)
                {
                    if (item is MyCalendarButton)
                    {
                        MyCalendarButton dayButton = item as MyCalendarButton;
                        if (dayButton.DataContext is DateTime)
                        {
                            DateTime dt = (DateTime)dayButton.DataContext; 
                          
                            if (dt.Day == this.OwnerCtr.SelectDate.Day&& dt.Month== this.OwnerCtr.SelectDate.Month&& dt.Year== this.OwnerCtr.SelectDate.Year)
                            {                               
                                if (dt != DateTime.Today) 
                                {
                                    dayButton.IsSelected = true;
                                }
                                   
                                break;
                            }
                        }
                    }

                }
            }
        }

        private void ListOthertMonthDay(int year, int month)
        {
            DateTime firstDay = this.GetFirsyDay(year, month);
            int firstDayColIndex = this.GetFirstDayColIndex(firstDay.DayOfWeek);

            int monthTemp = month;
            int yearTemp = year;
            if (month == 1)
            {
                yearTemp--;
                monthTemp = 12;
            }
            else
            {
                monthTemp--;
            }

            //获取上个月的天数
            int daysInMonth = DateTime.DaysInMonth(yearTemp, monthTemp);
            //设置当月中显示的上个月的多余的几天
            for (int i = firstDayColIndex - 1; i >= 0; i--)
            {
                DateTime dateTime = new DateTime(yearTemp, monthTemp, daysInMonth);
                this.CalendarDayButtons[1, i].DataContext = dateTime;
                this.CalendarDayButtons[1, i].Content = daysInMonth;
                this.CalendarDayButtons[1, i].Tag = daysInMonth;
                this.CalendarDayButtons[1, i].IsBelongCurrentMonth = false;
                daysInMonth--;
            }

            yearTemp = year;
            monthTemp = month;
            //如果当月是12月份，那么下个月就是明年的1月份
            if (month == 12)
            {
                yearTemp++;
                monthTemp = 1;
            }
            else
            {
                monthTemp++;
            }
            //获取下个月的天数
            daysInMonth = DateTime.DaysInMonth(year, month);
            int day = 1;
            for (int i = firstDayColIndex + daysInMonth + 7; i < 49; i++)
            {
                int colIndex = i % 7;
                int rowIndex = i / 7;
                DateTime dateTime = new DateTime(yearTemp, monthTemp, day);
                this.CalendarDayButtons[rowIndex, colIndex].DataContext = dateTime;
                this.CalendarDayButtons[rowIndex, colIndex].Content = day;
                this.CalendarDayButtons[rowIndex, colIndex].IsBelongCurrentMonth = false;
                day++;
            }
        }


        private int GetFirstDayColIndex(DayOfWeek dayOfWeek)
        {
            return (dayOfWeek - DayOfWeek.Monday + 7) % 7;
        }


        private DateTime GetFirsyDay(int year, int month)
        {
            return new DateTime(year, month, 1);
        }

        private void SetYearButtons()
        {
            int decadeStart = OwnerCtr.DisplayDate.Year - OwnerCtr.DisplayDate.Year % 10;

            this.Head_Button.Content = string.Format("{0}年 - {1}年", decadeStart, decadeStart + 9);

            int num = 0;
            foreach (object item in this.Month_Contian_Grid.Children)
            {
                DateTime dateTime = new DateTime(decadeStart + num, 1, 1);
                MyCalendarButton calendarButton = item as MyCalendarButton;
                calendarButton.DataContext = dateTime;
                calendarButton.Content = dateTime.Year;
                if (dateTime.Year == OwnerCtr.DisplayDate.Year)
                {
                    calendarButton.IsHighlight = true;
                }
                num++;
            }
        }

        private void ExcuteHead_ButtonClick(object sender, RoutedEventArgs e)
        {
            if(this.OwnerCtr.DisplayMode == CalendarMode.Month)
            {
                this.OwnerCtr.DisplayMode = CalendarMode.Year;
                SetButtonStateOnDoube(false);
            }
            else if (this.OwnerCtr.DisplayMode == CalendarMode.Year) 
            {
                this.OwnerCtr.DisplayMode = CalendarMode.Decade;   
            }
            else if (this.OwnerCtr.DisplayMode == CalendarMode.Decade) 
            {
                            
            }
        }


        private void ExcutePreview_ButtonMethod() 
        {
            int year = this.ShowTime.Year;
            int month = this.ShowTime.Month;

            switch (this.OwnerCtr.DisplayMode)
            {
                case CalendarMode.Month:
                    if (this.OwnerCtr.Owener.IsRelevance && this.OwnerCtr.Owener.DataPickerType == DataPickerTypeEnum.Double)
                    {
                        this.OwnerCtr.Owener.MyCalendar_Second.DisplayDate = new DateTime(year, month, 1);
                        month = month - 1;
                        if (month < 1)
                        {
                            this.OwnerCtr.Owener.MyCalendar_One.DisplayDate = new DateTime(year - 1, 12, 1);
                        }
                        else
                        {
                            this.OwnerCtr.Owener.MyCalendar_One.DisplayDate = new DateTime(year, month, 1);
                        }
                    }
                    else
                    {
                        if (month == 1)
                        {
                            this.OwnerCtr.DisplayDate = new DateTime(year - 1, 12, 1);
                        }
                        else
                        {
                            this.OwnerCtr.DisplayDate = new DateTime(year, month - 1, 1);
                        }
                    }

                    break;
                case CalendarMode.Year:
                    if (this.OwnerCtr.Owener.DataPickerType != DataPickerTypeEnum.Double) 
                    {
                        this.OwnerCtr.DisplayDate = new DateTime(year - 1, month, 1);
                    }
                   
                    break;
                case CalendarMode.Decade:
                    if (this.OwnerCtr.Owener.DataPickerType != DataPickerTypeEnum.Double) 
                    {
                        this.OwnerCtr.DisplayDate = new DateTime(year - 10, month, 1);
                    }  
                    break;
            }

        }

        private void ExcutePreview_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExcutePreview_ButtonMethod();
        }

        private void ExcuteNext_ButtonMethod() 
        {
            int year = this.ShowTime.Year;
            int month = this.ShowTime.Month;
            switch (this.OwnerCtr.DisplayMode)
            {
                case CalendarMode.Month:
                    if (this.OwnerCtr.Owener.IsRelevance && this.OwnerCtr.Owener.DataPickerType == DataPickerTypeEnum.Double)
                    {
                        this.OwnerCtr.Owener.MyCalendar_One.DisplayDate = new DateTime(year, month, 1);
                        month = month + 1;
                        if (month > 12)
                        {
                            this.OwnerCtr.Owener.MyCalendar_Second.DisplayDate = new DateTime(year + 1, 1, 1);
                        }
                        else
                        {
                            this.OwnerCtr.Owener.MyCalendar_Second.DisplayDate = new DateTime(year, month, 1);
                        }
                    }
                    else
                    {
                        if (month == 12)
                        {
                            this.OwnerCtr.DisplayDate = new DateTime(year + 1, 1, 1);
                        }
                        else
                        {
                            this.OwnerCtr.DisplayDate = new DateTime(year, month + 1, 1);
                        }
                    }
                    break;
                case CalendarMode.Year:
                    if(this.OwnerCtr.Owener.DataPickerType != DataPickerTypeEnum.Double)
                    {
                        this.OwnerCtr.DisplayDate = new DateTime(year + 1, month, 1);
                    }
                   
                    break;
                case CalendarMode.Decade:
                    if (this.OwnerCtr.Owener.DataPickerType != DataPickerTypeEnum.Double) 
                    {
                        this.OwnerCtr.DisplayDate = new DateTime(year + 10, month, 1);
                    }   
                    break;
            }

        }

        private void ExcuteNext_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExcuteNext_ButtonMethod();
        }
    }
}
