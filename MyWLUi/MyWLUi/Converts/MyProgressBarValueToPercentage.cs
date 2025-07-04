using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyWLUi.Converts
{
    public class MyProgressBarValueToPercentage : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var maximum = System.Convert.ToDouble(values[0]);
            var value = System.Convert.ToDouble(values[1]);
            var minimum = System.Convert.ToDouble(values[2]);

            if (maximum == 0)
            {
                return "0" + "%";
            }

            double progressValue = (value - minimum) / (maximum - minimum) * 100;
            return (Math.Round(progressValue)).ToString() + "%";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
