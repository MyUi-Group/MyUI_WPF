using MyUi.Args;
using MyUi.Controls.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MyUi.Controls
{
    public class MyPageButtonCtr : CustomCtrBase
    {
        private Button PerviewButton;

        private TextBox GoPageTextBox;

        private StackPanel ButtonContaNerPanel;

        private Button NextButton;


        /// <summary>
        /// 总条数
        /// </summary>
        public int DateSum 
        {
            set 
            {
                SetValue(DateSumProperty, value);
            }

            get 
            { 
                return (int)GetValue(DateSumProperty); 
            }
        }


        public static readonly DependencyProperty DateSumProperty = DependencyProperty.Register("DateSum", typeof(int), typeof(MyPageButtonCtr),new PropertyMetadata(1,PageSumChangedMethod));

        private static void PageSumChangedMethod(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
          
        }


        /// <summary>
        /// 手动跳转页/当前页
        /// </summary>
        public int CurrentPage
        {
            set 
            {
                SetValue(CurrentPageProperty, value);
            }

            get 
            {
                return (int)GetValue(CurrentPageProperty);
            }
        }

        public static readonly DependencyProperty CurrentPageProperty = DependencyProperty.Register("CurrentPage", typeof(int),typeof(MyPageButtonCtr),new PropertyMetadata(1, ToGoPageIndexChanged));

     

        private static void ToGoPageIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           
        }


        public ObservableCollection<int> Limits 
        {
            set 
            { 
                SetValue(LimitsProperty, value);
            } 
            get 
            { 
                return (ObservableCollection<int>)GetValue(LimitsProperty);
            }
        }


        public static readonly DependencyProperty LimitsProperty = DependencyProperty.Register("Limits",typeof(ObservableCollection<int>),typeof(MyPageButtonCtr)); 

        /// <summary>
        /// 每页展示数量
        /// </summary>
        public int EveryPageShowNum 
        {
            set 
            {
                SetValue(EveryPageShowNumProperty,value);
            }

            get 
            {
                return (int)GetValue(EveryPageShowNumProperty);
            }
        }


        public static readonly DependencyProperty EveryPageShowNumProperty = DependencyProperty.Register("EveryPageShowNum",typeof(int),typeof(MyPageButtonCtr),new PropertyMetadata(EveryPageShowNumChanged));

        private static void EveryPageShowNumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MyPageButtonCtr pagination) 
            {
                pagination.UpdateAllPageButton();
            }
        }

  
        private int PageCount { set; get; }


        private bool IsHaveLoad;

        public MyPageButtonCtr() 
        {
            this.Loaded -= ExcuteLoad;
            this.Loaded += ExcuteLoad;
            this.Unloaded -= ExcuteUnloaded;
            this.Unloaded += ExcuteUnloaded;
        }

        private void ExcuteUnloaded(object sender, RoutedEventArgs e)
        {
            IsHaveLoad = false;
        }

        private void ExcuteLoad(object sender, RoutedEventArgs e)
        {
            IsHaveLoad = true;
     
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            PerviewButton = GetTemplateChild("PerviewButton") as Button;          
            NextButton = GetTemplateChild("NextButton") as Button;                     
            ButtonContaNerPanel= GetTemplateChild("ButtonContaNerPanel") as StackPanel;
            GoPageTextBox= GetTemplateChild("GoPageTextBox") as TextBox;
            if (PerviewButton == null || NextButton==null||  ButtonContaNerPanel==null|| GoPageTextBox==null)
            {
                throw new Exception("实例化分页控件失败");
            }
            else
            {
                PerviewButton.Click -= ExcutePerviewButtonClick;
                PerviewButton.Click += ExcutePerviewButtonClick;

                NextButton.Click -= ExcuteNextButtonClick;
                NextButton.Click += ExcuteNextButtonClick;
                GoPageTextBox.TextChanged -= ExcuteGoPageTextBoxTextChanged;
                GoPageTextBox.TextChanged += ExcuteGoPageTextBoxTextChanged;
                GoPageTextBox.LostFocus -= ExcuteTextBoxLostFocus;
                GoPageTextBox.LostFocus += ExcuteTextBoxLostFocus;
            }
        }

        private void ExcuteTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox itemT = sender as TextBox;
            if (string.IsNullOrEmpty(itemT.Text))
            {
                itemT.Text = CurrentPage.ToString();
            }
        }

        private void ExcuteGoPageTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            if (PageCount==0) 
            {
                return;
            }
            TextBox itemT=sender as TextBox;
            if (string.IsNullOrEmpty(itemT.Text))
            {
                return;
            }
            if (Convert.ToInt32(itemT.Text)>PageCount) 
            {
                itemT.Text = PageCount.ToString();
            }
            UpdateAllPageButton();
        }

       
        private void ExcutePerviewButtonClick(object sender, RoutedEventArgs e)
        {
            var _midleNum = CurrentPage -= 1;
           
            if (_midleNum > 0) 
            {
                CurrentPage = _midleNum;
            }
        }

        private void ExcuteNextButtonClick(object sender, RoutedEventArgs e)
        {
            var _midleNum = CurrentPage+= 1;
            if (_midleNum<=PageCount) 
            {
                CurrentPage = _midleNum;
            }
        }



        #region
        private void UpdateAllPageButton() 
        {
            if (EveryPageShowNum==0) 
            {
                return;
            }
            PageCount = 1;
            if (DateSum % EveryPageShowNum > 0)
            {
                PageCount = DateSum / EveryPageShowNum + 1;
            }
            else 
            {
                PageCount = DateSum / EveryPageShowNum;
            }
            PerviewButton.IsEnabled = CurrentPage > 1 ? true : false;
            NextButton.IsEnabled = CurrentPage < PageCount ? true : false;
            
            ButtonContaNerPanel.Children.Clear();
            ButtonContaNerPanel.Children.Add(CreatButton(1));

            int _IncrementSpaceNum = 1;
            int JudgeNum = 4;
            if (PageCount > _IncrementSpaceNum)
            {
                if (CurrentPage > JudgeNum)
                {
                    ButtonContaNerPanel.Children.Add(CreatButton(-1,false));
                }

                var _LeftIndex = CurrentPage - 2;
                if (_LeftIndex > _IncrementSpaceNum)
                {
                    ButtonContaNerPanel.Children.Add(CreatButton(_LeftIndex));
                }
                _LeftIndex = CurrentPage - 1;
                if (_LeftIndex > _IncrementSpaceNum)
                {
                    ButtonContaNerPanel.Children.Add(CreatButton(_LeftIndex));
                }


                if (CurrentPage>1&& CurrentPage< PageCount) 
                {
                    ButtonContaNerPanel.Children.Add(CreatButton(CurrentPage));
                }
                

                var _RightIndex = CurrentPage + 1;
                if (_RightIndex < PageCount)
                {
                    ButtonContaNerPanel.Children.Add(CreatButton(_RightIndex));
                }
                _RightIndex = CurrentPage + 2;
                if (_RightIndex < PageCount)
                {
                    ButtonContaNerPanel.Children.Add(CreatButton(_RightIndex));
                }

                if ((PageCount - _RightIndex) >= 2)
                {
                    ButtonContaNerPanel.Children.Add(CreatButton(-1, false));
                }

                ButtonContaNerPanel.Children.Add(CreatButton(PageCount));               
            }
            ExcuteMyCustomEvent(null);

        }

        private RadioButton CreatButton(int _Content, bool _isEnabled=true) 
        {
            RadioButton _middleButton = new RadioButton();
            _middleButton.Click -= ExcuteMiddleButton;
            _middleButton.Click += ExcuteMiddleButton;
            _middleButton.IsEnabled = _isEnabled;
            _middleButton.Content = _isEnabled?_Content.ToString():"...";
            _middleButton.Tag = _Content;
            _middleButton.IsChecked = _Content == CurrentPage ? true : false;
            return _middleButton;
        }

        private void ExcuteMiddleButton(object sender, RoutedEventArgs e)
        {
            var _itemBtn = sender as RadioButton;
            CurrentPage =Convert.ToInt32(_itemBtn.Tag);
        }


        public override void ExcuteMyCustomEvent(object item)
        {
            if (!IsHaveLoad)
            {
                return;
            }

            RaiseEvent(new MyCustomRoutEventArgs<int>(PageDateUpdateEvent, this)
            {
                Info = CurrentPage
            });

        }

        #endregion
    }
}
