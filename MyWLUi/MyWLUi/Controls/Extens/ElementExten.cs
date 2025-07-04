using Microsoft.Win32;
using MyUi.Args;
using  MyUi.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyUi.Controls
{
    /// <summary>
    /// LCL
    /// Element附加属性
    /// </summary>
    public class ElementExten : DependencyObject
    {

        public static void SetListBoxType(DependencyObject obj, object value)
        {
            obj.SetValue(ListBoxTypeProperty, value);
        }
        public static object GetListBoxType(DependencyObject obj)
        {
            return obj.GetValue(ListBoxTypeProperty);
        }

        public static readonly DependencyProperty ListBoxTypeProperty =
            DependencyProperty.RegisterAttached("ListBoxType", typeof(ListBoxTypeEnum), typeof(ElementExten));




        public static void SetCheckBoxType(DependencyObject obj, object value)
        {
            obj.SetValue(CheckBoxTypeProperty, value);
        }
        public static object GetCheckBoxType(DependencyObject obj)
        {
            return obj.GetValue(CheckBoxTypeProperty);
        }

        public static readonly DependencyProperty CheckBoxTypeProperty =
            DependencyProperty.RegisterAttached("CheckBoxType", typeof(CheckBoxTypeEnum), typeof(ElementExten));




        public static void SetDataPickerType(DependencyObject obj, object value)
        {
            obj.SetValue(DataPickerTypeProperty, value);
        }
        public static object GetDataPickerType(DependencyObject obj)
        {
            return obj.GetValue(DataPickerTypeProperty);
        }

        public static readonly DependencyProperty DataPickerTypeProperty =
            DependencyProperty.RegisterAttached("DataPickerType", typeof(DataPickerTypeEnum), typeof(ElementExten));



        public static void SetMouseHoverBackGround(DependencyObject obj, object value)
        {
            obj.SetValue(MouseHoverBackGroundProperty, value);
        }

        public static readonly DependencyProperty MouseHoverBackGroundProperty = 
            DependencyProperty.RegisterAttached("MouseHoverBackGround", typeof(Brush), typeof(ElementExten));


        public static void SetMouseHoverBorderBrush(DependencyObject obj, object value)
        {
            obj.SetValue(MouseHoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty MouseHoverBorderBrushProperty = 
            DependencyProperty.RegisterAttached("MouseHoverBorderBrush",typeof(Brush),typeof(ElementExten));


        public static void SetIcoHeight(DependencyObject obj, object value)
        {
            obj.SetValue(IcoHeightProperty, value);
        }
        public static object GetIcoHeight(DependencyObject obj)
        {
            return obj.GetValue(IcoHeightProperty);
        }

        public static readonly DependencyProperty IcoHeightProperty =
            DependencyProperty.RegisterAttached("IcoHeight", typeof(double), typeof(ElementExten));



        public static void SetIcoAngle(DependencyObject obj, object value)
        {
            obj.SetValue(IcoAngleProperty, value);
        }

        public static object GetIcoAngle(DependencyObject obj)
        {
            return obj.GetValue(IcoAngleProperty);
        }

        public static readonly DependencyProperty IcoAngleProperty =
            DependencyProperty.RegisterAttached("IcoAngle", typeof(double), typeof(ElementExten));



        public static void SetIcoWidth(DependencyObject obj, object value)
        {
            obj.SetValue(IcoWidthProperty, value);
        }

        public static object GetIcoWidth(DependencyObject obj)
        {
            return obj.GetValue(IcoWidthProperty);
        }

        public static readonly DependencyProperty IcoWidthProperty =
            DependencyProperty.RegisterAttached("IcoWidth", typeof(double), typeof(ElementExten));


        public static void SetIcoPathData(DependencyObject obj, object value)
        {
            obj.SetValue(IcoPathDataProperty, value);
        }


        public static readonly DependencyProperty IcoPathDataProperty =
            DependencyProperty.RegisterAttached("IcoPathData", typeof(PathGeometry), typeof(ElementExten));


        public static void SetButtonType(DependencyObject obj, object value)
        {
            obj.SetValue(ButtonTypeProperty, value);
        }

        public static object GetButtonType(DependencyObject obj)
        {
            return obj.GetValue(ButtonTypeProperty);
        }

        public static readonly DependencyProperty ButtonTypeProperty =
            DependencyProperty.RegisterAttached("ButtonType", typeof(ButtonTypeEnum), typeof(ElementExten), new PropertyMetadata(OnTextBoxTypeChange));



        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }

       
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ElementExten));

        public static object GetWatermark(DependencyObject obj)
        {
            return obj.GetValue(WatermarkProperty);
        }

        public static void SetWatermark(DependencyObject obj, object value)
        {
            obj.SetValue(WatermarkProperty, value);
        }

        
        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.RegisterAttached("Watermark", typeof(object), typeof(ElementExten));



        public static void SetTextBoxType(DependencyObject obj, object value)
        {
            obj.SetValue(TextBoxTypeProperty, value);
        }

        public static object GetTextBoxType(DependencyObject obj)
        {
            return obj.GetValue(TextBoxTypeProperty);
        }
        
        public static readonly DependencyProperty TextBoxTypeProperty =
            DependencyProperty.RegisterAttached("TextBoxType", typeof(InputBoxTypeEnum), typeof(ElementExten), new PropertyMetadata(OnTextBoxTypeChange));

        private static void OnTextBoxTypeChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            System.Windows.Controls.TextBox _textBox = d as System.Windows.Controls.TextBox;
            if (_textBox != null)
            {
                var item = e.NewValue.ToString();
                if (item == InputBoxTypeEnum.SelectFile.ToString() || item == InputBoxTypeEnum.Search.ToString())
                {
                    _textBox.Loaded += textBoxLoad;
                }
                if (item == InputBoxTypeEnum.Number.ToString()|| item == InputBoxTypeEnum.Phone.ToString()) 
                {
                    _textBox.PreviewTextInput -= Text_PreviewTextInput;
                    _textBox.PreviewTextInput += Text_PreviewTextInput;

                }
                
                
                _textBox.GotFocus += textBoxGotFocus;
            }
        }


        private static void Text_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Windows.Controls.TextBox TextObj = sender as System.Windows.Controls.TextBox;
            switch (GetTextBoxType(TextObj))
            {
                case InputBoxTypeEnum.Default:
                    e.Handled = false;
                    break;
                case InputBoxTypeEnum.Number:
                    e.Handled = new Regex(@"[^0-9|\-|\.]").IsMatch(e.Text);
                    break;
                case InputBoxTypeEnum.Phone:
                    e.Handled = IsEffectPhone(e);
                    break;
                default:
                    e.Handled = false;
                    break;
            }
        }
        private static bool IsEffectPhone(System.Windows.Input.TextCompositionEventArgs e)
        {
            if ((e.OriginalSource as System.Windows.Controls.TextBox).Text.ToCharArray().Length > 10) return true;
            return System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"[^(1)\d{10}$]");
        }
        private static void textBoxGotFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox textBox = sender as System.Windows.Controls.TextBox;
            if (textBox != null)
            {
                textBox.CaretIndex = textBox.Text.Length;
            }

        }

        private static void textBoxLoad(object sender, RoutedEventArgs e)
        {
            var _textBox = sender as System.Windows.Controls.TextBox;
            Grid Selecte_Grid = _textBox.Template?.FindName("Icon_Grid", _textBox) as Grid;
            Grid Search_Grid = _textBox.Template?.FindName("Icon_Grid_Search", _textBox) as Grid;
            if (Selecte_Grid != null)
            {
                Selecte_Grid.PreviewMouseDown -= ExcuteGridPreviewMouseDown;
                Selecte_Grid.PreviewMouseDown += ExcuteGridPreviewMouseDown;
            }
            if (Search_Grid != null)
            {
                Search_Grid.PreviewMouseDown -= ExcuteSearchGridPreviewMouseDown;
                Search_Grid.PreviewMouseDown += ExcuteSearchGridPreviewMouseDown;
            }
        }

        private static void ExcuteSearchGridPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Grid _SearchGrid = sender as Grid;
            if (_SearchGrid != null)
            {
                RoutedEventArgs reArgs = new RoutedEventArgs(MyEventManager.SearchButtonDownEvent, e);
                _SearchGrid.RaiseEvent(reArgs);
            }
        }

        private static void ExcuteGridPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Grid _grid = sender as Grid;
            if (_grid != null)
            {
                if (_grid.Tag is System.Windows.Controls.TextBox _TextBos)
                {
                    System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
                    openFileDialog.Multiselect = false;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string files = openFileDialog.FileName;
                        _TextBos.Text = files;
                    }
                }

            }
        }

    }
}
