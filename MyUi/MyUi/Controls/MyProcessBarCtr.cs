using  MyUi.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace MyUi.Controls
{
    [TemplatePart(Name = "TemplateRoot", Type = typeof(Panel))]
    public class MyProcessBarCtr: System.Windows.Controls.ProgressBar
    {

        private Panel TemplateRoot;


        [Bindable(true)]
        public bool IsShowPercent
        {
            get { return (bool)GetValue(IsShowPercentProperty); }
            set { SetValue(IsShowPercentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsShowPercentProperty =
            DependencyProperty.Register("IsShowPercent", typeof(bool), typeof(MyProcessBarCtr), new PropertyMetadata(false));



        [Bindable(true)]
        public Brush TextForeground
        {
            get { return (Brush)GetValue(TextForegroundProperty); }
            set { SetValue(TextForegroundProperty, value); }
        }


        public static readonly DependencyProperty TextForegroundProperty =
            DependencyProperty.Register("TextForeground", typeof(Brush), typeof(MyProcessBarCtr), new PropertyMetadata(Brushes.White));



        [Bindable(true)]
        public double Radius
        {
            get { return (double)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius", typeof(double), typeof(MyProcessBarCtr), new PropertyMetadata(OnCornerRadiusChanged));

        private static void OnCornerRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MyProcessBarCtr MyProgress)
            {
                if (MyProgress.IsLoaded)
                    MyProgress.InvalidateVisual();
            }
        }

        [Bindable(true)]
        public ProcessBarTypeEnum ProcessBarType
        {
            get { return (ProcessBarTypeEnum)GetValue(ProcessBarTypeProperty); }
            set { SetValue(ProcessBarTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditingComboBoxColumnStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProcessBarTypeProperty =
            DependencyProperty.Register("ProcessBarType", typeof(ProcessBarTypeEnum), typeof(MyProcessBarCtr), new PropertyMetadata(ProcessBarTypeEnum.Rect));

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            TemplateRoot = GetTemplateChild("TemplateRoot") as Panel;
        }
        private void IndicatorCornerRadius()
        {
            TemplateRoot.Clip = new RectangleGeometry(new Rect(0, 0, this.ActualWidth, this.ActualHeight), Radius, Radius);
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            IndicatorCornerRadius();
        }
    }
}
