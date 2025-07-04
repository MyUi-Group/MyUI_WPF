using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MyUi.Controls
{
    public class MyTimeSelectButton : ListBoxItem
    {

        static MyTimeSelectButton() 
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyTimeSelectButton), new FrameworkPropertyMetadata(typeof(MyTimeSelectButton)));
        }

    }
}
