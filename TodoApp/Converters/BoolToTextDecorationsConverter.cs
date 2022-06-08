using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TodoApp.Converters
{
    public class BoolToTextDecorationsConverter : IValueConverter
    {
        public TextDecorationCollection TrueDecorations { get; set; }
        public TextDecorationCollection FalseDecorations { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not bool boolValue)
            {
                return value;
            }

            return boolValue ? TrueDecorations : FalseDecorations;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
