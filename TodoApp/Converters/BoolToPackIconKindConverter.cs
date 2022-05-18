using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using MaterialDesignThemes.Wpf;

namespace TodoApp.Converters
{
    class BoolToPackIconKindConverter : IValueConverter
    {
        public PackIconKind TrueIcon { get; set; }
        public PackIconKind FalseIcon { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not bool booleanValue)
            {
                return value;
            }

            return booleanValue ? TrueIcon : FalseIcon;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
