using System;
using System.Globalization;
using Microsoft.Maui.Controls;
namespace ecommerce_app.Converters
{
    public class StringNotNullOrEmptyConverter : IValueConverter
    {
        // Converts a string to true if not null or empty, false otherwise
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = value as string;
            return !string.IsNullOrEmpty(str);
        }

        // Back conversion not needed, just return false
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
