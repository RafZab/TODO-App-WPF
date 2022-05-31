using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using TodoApp.Models;

namespace TodoApp.Converters
{
    public class SelectedGroupToBrushConverter : IValueConverter
    {
        public Color FallBackColor { get; set; } = Colors.Gray;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not TaskGroup taskGroup)
            {
                return new SolidColorBrush(FallBackColor);
            }

            return taskGroup.IconBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
