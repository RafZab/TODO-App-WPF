using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Animation;
using TodoApp.Models;

namespace TodoApp.Converters
{
    public class SelectedGroupToTextConverter : IValueConverter
    {
        public string FallBackValue { get; set; } = "New Group";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not TaskGroup taskGroup)
            {
                return FallBackValue;
            }

            return taskGroup.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
