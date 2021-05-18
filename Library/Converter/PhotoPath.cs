using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.IO;

namespace Library.Converter
{
    class PhotoPath : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return $"pack://siteoforigin:,,,/ImageBooks/Photo.png";

            string filename = Path.GetFileName(value.ToString());
            string FullResult = $"pack://siteoforigin:,,,/ImageBooks/{filename}";
            return FullResult;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
