using MyWLUi.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MyWLUi.Converts
{
    /// <summary>
    /// LCL
    /// 
    /// </summary>
    public class ContentToShowConverter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility visibility = Visibility.Collapsed;
            if (value!=null) 
            {
                string str=value.ToString();
                if (string.IsNullOrEmpty(str)) 
                {
                    visibility = Visibility.Visible;
                }
            }
            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
