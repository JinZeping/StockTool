using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPFCommonExtension.Converters
{
    public class AmountUnitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "";
            }

            decimal d = (decimal)value;
            return (d / 10000).ToString("0.00####");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = (string)value;

            if (decimal.TryParse(s, out decimal d))
            {
                return d * 10000;
            }
            else
            {
                return 0;
            }
        }
    }
}
