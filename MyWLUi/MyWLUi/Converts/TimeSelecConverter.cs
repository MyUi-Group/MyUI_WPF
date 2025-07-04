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
    public class TimeSelecConverter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime itemTime = DateTime.Now;
            if (value!=null) 
            {
                if (parameter!=null)
                {
                    if (parameter.ToString() == DataPickerTypeEnum.OnlyOne.ToString())
                    {
                        itemTime = System.Convert.ToDateTime(value);
                    }
                    else 
                    {
                        string[] _timeArray = value.ToString().Split('~');
                        if (parameter.ToString() == DataPickerTypeEnum.One.ToString())
                        {
                            itemTime = System.Convert.ToDateTime(_timeArray[0]);
                        }
                        else
                        {
                            itemTime = System.Convert.ToDateTime(_timeArray[1]);
                        }
                    }
                  
                }
            }

            return itemTime;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
