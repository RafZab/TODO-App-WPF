using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using MaterialDesignThemes.Wpf;
using TodoApp.Models;

namespace TodoApp.Converters
{
    public class SelectedGroupToIconKindConverter : IValueConverter
    {
        public PackIconKind FallBackIconKind { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not TaskGroup taskGroup)
            {
                return FallBackIconKind;
            }

            return taskGroup.Icon;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
