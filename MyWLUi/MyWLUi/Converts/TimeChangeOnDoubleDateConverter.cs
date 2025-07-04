using  MyUi.Global;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public class TimeChangeOnDoubleDateConverter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string str = "";
            if (value!=null) 
            {
                string[] _timeArray= value.ToString().Split('~');
                str=parameter.ToString() == DataPickerTypeEnum.One.ToString() ? _timeArray[0] : _timeArray[1];             
            }

            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
