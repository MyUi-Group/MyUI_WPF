using  MyUi.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MyUi.Converts
{
    /// <summary>
    /// LCL
    /// 非空转换器
    /// </summary>
    public class SelectDateStateConverter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility visibility = Visibility.Visible;
            if (value!=null) 
            {
                SelectTimeTypeEnum itemType = (SelectTimeTypeEnum)value;
                if (itemType.ToString()!= parameter.ToString()) 
                {
                    visibility = Visibility.Hidden;
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
