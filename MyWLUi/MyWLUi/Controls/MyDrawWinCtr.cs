using MyWLUi.Args;
using MyWLUi.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MyWLUi.Controls
{
    [TemplatePart(Name = "Drawer", Type = typeof(Border))]
    public class MyDrawWinCtr : System.Windows.Controls.ContentControl
    {
        Border Drawer;


        [Bindable(true)]
        public DrawDirectionTypeEnum DrawDirectionType
        {
            get { return (DrawDirectionTypeEnum)GetValue(DrawDirectionTypeProperty); }
            set { SetValue(DrawDirectionTypeProperty, value); }
        }


        public static readonly DependencyProperty DrawDirectionTypeProperty =
            DependencyProperty.Register("DrawDirectionType", typeof(DrawDirectionTypeEnum), typeof(MyDrawWinCtr), new PropertyMetadata(DrawerOpenChangeed));



        /// <summary>
        /// 抽屉开关
        /// </summary>
        [Bindable(true)]
        public bool IsDrawWinOpen
        {
            get { return (bool)GetValue(IsDrawWinOpenProperty); }
            set { SetValue(IsDrawWinOpenProperty, value); }
        }


        public static readonly DependencyProperty IsDrawWinOpenProperty =
            DependencyProperty.Register("IsDrawWinOpen", typeof(bool), typeof(MyDrawWinCtr), new PropertyMetadata(DrawerOpenChangeed));

        private static void DrawerOpenChangeed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MyDrawWinCtr host)
            {
                if (e.NewValue is bool)
                {

                    bool flg = (bool)e.NewValue;
                    if (flg)
                    {
                        host.SlideIn();
                    }
                    else
                    {
                        host.SlideOut();
                    }


                }
            }
        }

        public event EventHandler<MyCustomRoutEventArgs<bool>> AnimationInOver
        {
            add { AddHandler(AnimationInOverEvent, value); }
            remove { RemoveHandler(AnimationInOverEvent, value); }
        }


        public static readonly RoutedEvent AnimationInOverEvent = EventManager.RegisterRoutedEvent("AnimationInOver", RoutingStrategy.Bubble, typeof(EventHandler<MyCustomRoutEventArgs<bool>>), typeof(MyDrawWinCtr));


        public event EventHandler<MyCustomRoutEventArgs<bool>> AnimationOutOver
        {
            add { AddHandler(AnimationOutOverEvent, value); }
            remove { RemoveHandler(AnimationOutOverEvent, value); }
        }


        public static readonly RoutedEvent AnimationOutOverEvent = EventManager.RegisterRoutedEvent("AnimationOutOver", RoutingStrategy.Bubble, typeof(EventHandler<MyCustomRoutEventArgs<bool>>), typeof(MyDrawWinCtr));



        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Drawer=GetTemplateChild("Drawer") as Border;
            if (Drawer==null) 
            {
                throw new Exception("初始化控件失败");
            }
            this.Loaded -= ExcuteLoad;
            this.Loaded += ExcuteLoad;
        }

        private void ExcuteLoad(object sender, RoutedEventArgs e)
        {
            switch (DrawDirectionType)
            {
                case DrawDirectionTypeEnum.Right:
                    Drawer.RenderTransform = new TranslateTransform(Application.Current.MainWindow.ActualWidth, 0); 
                    break;
                case DrawDirectionTypeEnum.Left:                
                    Drawer.RenderTransform = new TranslateTransform(-Application.Current.MainWindow.ActualWidth, 0); 
                    break;
                case DrawDirectionTypeEnum.Top:
                    Drawer.RenderTransform = new TranslateTransform(0, -Application.Current.MainWindow.ActualHeight);
                    break;
                case DrawDirectionTypeEnum.Bottom:
                    Drawer.RenderTransform = new TranslateTransform(0, Application.Current.MainWindow.ActualHeight);
                    break;
            }
           
        }

        private void SlideIn()
        {
            DoubleAnimation slideInAnimation=null;
            switch (DrawDirectionType) 
            {
                case DrawDirectionTypeEnum.Right:
                    // 创建滑入动画
                    slideInAnimation = new DoubleAnimation
                    {
                        From = Application.Current.MainWindow.ActualWidth,
                        To = 0,
                        Duration = new Duration(TimeSpan.FromSeconds(0.5))
                    };
                    Drawer.RenderTransform.BeginAnimation(TranslateTransform.XProperty, slideInAnimation);
                    break;
                case DrawDirectionTypeEnum.Left:
                    // 创建滑入动画
                    slideInAnimation = new DoubleAnimation
                    {
                 
                        To = 0,
                        Duration = new Duration(TimeSpan.FromSeconds(0.5))
                    };
                    Drawer.RenderTransform.BeginAnimation(TranslateTransform.XProperty, slideInAnimation);
                    break;
                case DrawDirectionTypeEnum.Top:
                    slideInAnimation = new DoubleAnimation
                    {

                        To = 0,
                        Duration = new Duration(TimeSpan.FromSeconds(0.5))
                    };
                    Drawer.RenderTransform.BeginAnimation(TranslateTransform.YProperty, slideInAnimation);
                    break;
                case DrawDirectionTypeEnum.Bottom:
                    slideInAnimation = new DoubleAnimation
                    {
                        From = Application.Current.MainWindow.ActualHeight,
                        To =0,
                        Duration = new Duration(TimeSpan.FromSeconds(0.5))
                    };
                    Drawer.RenderTransform.BeginAnimation(TranslateTransform.YProperty, slideInAnimation);
                    break;
            }

            if (slideInAnimation==null) 
            {
                return;
            }
           
            slideInAnimation.Completed += (s, a) =>
            {
                RaiseEvent(new MyCustomRoutEventArgs<bool>(AnimationInOverEvent, this)
                {
                    Info = true
                });
            };

            
       
        }

        private void SlideOut()
        {
            // 创建滑出动画
            DoubleAnimation slideOutAnimation = null;
            switch (DrawDirectionType)
            {
                case DrawDirectionTypeEnum.Right:
                    // 创建滑出动画
                    slideOutAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = Application.Current.MainWindow.ActualWidth,
                        Duration = new Duration(TimeSpan.FromSeconds(0.5))
                    };
                    break;
                case DrawDirectionTypeEnum.Left:
                    // 创建滑出动画
                    slideOutAnimation = new DoubleAnimation
                    {

                        To = -(Application.Current.MainWindow.ActualWidth),
                        Duration = new Duration(TimeSpan.FromSeconds(0.5))
                    };
                    break;
                case DrawDirectionTypeEnum.Top:
                    slideOutAnimation = new DoubleAnimation
                    {

                        To = -(Application.Current.MainWindow.ActualHeight),
                        Duration = new Duration(TimeSpan.FromSeconds(0.5))
                    };
                    break;
                case DrawDirectionTypeEnum.Bottom:
                    slideOutAnimation = new DoubleAnimation
                    {

                        From = 0,
                        To= Application.Current.MainWindow.ActualHeight,
                        Duration = new Duration(TimeSpan.FromSeconds(0.5))
                    };
                    break;
            }
            if (slideOutAnimation==null) 
            {
                return;
            }

            // 动画完成后隐藏抽屉
            slideOutAnimation.Completed += (s, a) =>
            {
                switch (DrawDirectionType)
                {
                    case DrawDirectionTypeEnum.Right:
                        Drawer.RenderTransform = new TranslateTransform(Application.Current.MainWindow.ActualWidth, 0); // 确保抽屉在外部
                        break;
                    case DrawDirectionTypeEnum.Left:
                        Drawer.RenderTransform = new TranslateTransform(-Application.Current.MainWindow.ActualWidth, 0); // 确保抽屉在外部
                        break;
                    case DrawDirectionTypeEnum.Top:
                        Drawer.RenderTransform = new TranslateTransform(0, -Application.Current.MainWindow.ActualHeight);
                        break;
                    case DrawDirectionTypeEnum.Bottom:
                        Drawer.RenderTransform = new TranslateTransform(0, Application.Current.MainWindow.ActualHeight);
                        break;
                }
                
                RaiseEvent(new MyCustomRoutEventArgs<bool>(AnimationOutOverEvent, this)
                {
                    Info = true
                });
            };
            switch (DrawDirectionType)
            {
                case DrawDirectionTypeEnum.Right:                   
                case DrawDirectionTypeEnum.Left:
                    Drawer.RenderTransform.BeginAnimation(TranslateTransform.XProperty, slideOutAnimation);
                    break;
                case DrawDirectionTypeEnum.Top:
                case DrawDirectionTypeEnum.Bottom:
                    Drawer.RenderTransform.BeginAnimation(TranslateTransform.YProperty, slideOutAnimation);
                    break;
            }
           
        }

    }
}
