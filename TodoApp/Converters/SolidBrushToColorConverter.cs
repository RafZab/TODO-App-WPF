using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace TodoApp.Converters
{
    public class SolidBrushToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not SolidColorBrush brush)
            {
                return Colors.Gray;
            }

            return brush.Color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not Color color)
            {
                return new SolidColorBrush(Colors.Gray);
            }

            return new SolidColorBrush(color);
        }
    }
}
