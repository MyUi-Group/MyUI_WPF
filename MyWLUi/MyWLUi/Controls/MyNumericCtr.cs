using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyWLUi.Controls
{
    [TemplatePart(Name = "PART_Reduce_Border", Type =typeof(Button))]
    [TemplatePart(Name = "PART_Add_Border", Type = typeof(Button))]
    [TemplatePart(Name = "PART_ContentHost", Type = typeof(TextBox))]
    public class MyNumericCtr : System.Windows.Controls.ContentControl
    {
        private Button PART_Reduce_Border;
        private Button PART_Add_Border;


        [Bindable(true)]
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }


        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(MyNumericCtr), new PropertyMetadata(false));




        [Bindable(true)]
        public Brush HoverBorderBrush
        {
            get { return (Brush)GetValue(HoverBorderBrushProperty); }
            set { SetValue(HoverBorderBrushProperty, value); }
        }

       
        public static readonly DependencyProperty HoverBorderBrushProperty =
            DependencyProperty.Register("HoverBorderBrush", typeof(Brush), typeof(MyNumericCtr), new PropertyMetadata(Brushes.Gray));


        [Bindable(true)]
        public Brush IconFilColor
        {
            get { return (Brush)GetValue(IconFilColorProperty); }
            set { SetValue(IconFilColorProperty, value); }
        }


        public static readonly DependencyProperty IconFilColorProperty =
            DependencyProperty.Register("IconFilColor", typeof(Brush), typeof(MyNumericCtr), new PropertyMetadata(Brushes.Gray));


        [Bindable(true)]
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(MyNumericCtr), new PropertyMetadata(OnValueChanged));

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MyNumericCtr itemCtr) 
            {
                itemCtr.SetState();
            }
        }

        [Bindable(true)]
        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(double), typeof(MyNumericCtr), new PropertyMetadata(100.0,OnMaxValueChanged));

        private static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }

        [Bindable(true)]
        public double MinValue
        {
            get { return (double)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(double), typeof(MyNumericCtr), new PropertyMetadata(0.0,OnMinValueChanged));

        private static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            PART_Reduce_Border = GetTemplateChild("PART_Reduce_Border") as Button;
            PART_Add_Border = GetTemplateChild("PART_Add_Border") as Button;
            if (PART_Reduce_Border != null&& PART_Add_Border!=null) 
            {
                PART_Reduce_Border.PreviewMouseDown -= ExcuteReduce_BorderMouseDown;
                PART_Reduce_Border.PreviewMouseDown += ExcuteReduce_BorderMouseDown;

                PART_Add_Border.PreviewMouseDown -= ExcuteAdd_BorderMouseDown;
                PART_Add_Border.PreviewMouseDown += ExcuteAdd_BorderMouseDown;
            }
            SetState();
        }


        private void SetState() 
        {
            if (this.Value <= this.MinValue)
            {
                Value = MinValue;
                if (this.PART_Reduce_Border != null)
                {
                    this.PART_Reduce_Border.IsEnabled = false;
                    this.PART_Add_Border.IsEnabled = true;
                }

                return;
            }
            if (this.Value >= this.MaxValue)
            {
                Value = MaxValue;
                if (this.PART_Add_Border != null)
                {
                    this.PART_Add_Border.IsEnabled = false;
                    this.PART_Reduce_Border.IsEnabled = true;
                }
                return;
            }
            if (this.PART_Reduce_Border != null)
            {
                this.PART_Reduce_Border.IsEnabled = true;
            }
            if (this.PART_Add_Border != null)
            {
                this.PART_Add_Border.IsEnabled = true;
            }
        }

        private void ExcuteReduce_BorderMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Value--;
        }

        private void ExcuteAdd_BorderMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Value++;
        }

       
    }
}
