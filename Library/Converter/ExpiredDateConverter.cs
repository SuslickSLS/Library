using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Library.Converter
{
    class ExpiredDateConverter : IValueConverter
    {
     

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush solidColor = new SolidColorBrush(Colors.LightGreen);
            DateTime date = (DateTime)value;
            DateTime now = DateTime.Now;
            if (date <= now)
            {
                return new SolidColorBrush(Color.FromRgb(196, 81, 81));
            }
            else
            {
                return solidColor;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
