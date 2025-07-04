using MyWLUi.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyWLUi.Controls
{
     public class MyExtenControlCtr: System.Windows.Controls.ContentControl
    {

        [Bindable(true)]
        public ExtenControlTypeEnum ExtenControlType
        {
            get { return (ExtenControlTypeEnum)GetValue(ExtenControlTypeProperty); }
            set { SetValue(ExtenControlTypeProperty, value); }
        }

        
        public static readonly DependencyProperty ExtenControlTypeProperty =
            DependencyProperty.Register("ExtenControlType", typeof(ExtenControlTypeEnum), typeof(MyExtenControlCtr), new PropertyMetadata(ExtenControlTypeEnum.Mark));


        [Bindable(true)]
        public string MarkContent
        {
            get { return (string)GetValue(MarkContentProperty); }
            set { SetValue(MarkContentProperty, value); }
        }


        public static readonly DependencyProperty MarkContentProperty =
            DependencyProperty.Register("MarkContent", typeof(string), typeof(MyExtenControlCtr));


        [Bindable(true)]
        public System.Windows.Media.Brush MarkAreaBackGround
        {
            get { return (System.Windows.Media.Brush)GetValue(MarkAreaBackGroundProperty); }
            set { SetValue(MarkAreaBackGroundProperty, value); }
        }


        public static readonly DependencyProperty MarkAreaBackGroundProperty =
            DependencyProperty.Register("MarkAreaBackGround", typeof(System.Windows.Media.Brush), typeof(MyExtenControlCtr));

    }
}
