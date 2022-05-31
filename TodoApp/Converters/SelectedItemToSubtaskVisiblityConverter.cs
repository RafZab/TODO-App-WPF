using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using TodoApp.Models;

namespace TodoApp.Converters
{
    public class SelectedItemToSubtaskVisiblityConverter : IValueConverter
    {
        public bool Inverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not ToDoTask toDoTask)
            {
                return value;
            }

            if (toDoTask.SubTasks is null)
            {
                return Inverted ? Visibility.Visible : Visibility.Hidden;
            }

            if (Inverted)
            {
                return toDoTask.SubTasks.Count > 0 ? Visibility.Hidden : Visibility.Visible;
            }

            return toDoTask.SubTasks.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
