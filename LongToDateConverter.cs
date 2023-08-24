using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace phiPartners
{
    class LongToDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is long milliseconds))
                return value;

            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(milliseconds);
            DateTime dateTime = dateTimeOffset.UtcDateTime;
            return dateTime;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new NotImplementedException();
        }
    }
}
