using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace MyWLUi.Controls
{
    public class MySlider: System.Windows.Controls.Slider
    {
        /// <summary>
        /// 进度条区域Size
        /// </summary>
        [Bindable(true)]
        public double SliderSize
        {
            get { return (double)GetValue(SliderSizeProperty); }
            set { SetValue(SliderSizeProperty, value); }
        }


        public static readonly DependencyProperty SliderSizeProperty =
            DependencyProperty.Register("SliderSize", typeof(double), typeof(MySlider), new PropertyMetadata(10.0));

    }
}
