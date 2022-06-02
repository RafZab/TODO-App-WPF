using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TodoApp.Models;

namespace TodoApp.Converters
{
    public class SubTasksToStatusHeaderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not ObservableCollection<ToDoSubTask> toDoSubTasks)
            {
                return string.Empty;
            }

            if (toDoSubTasks.Count == 0)
            {
                return "No subtasks!";
            }

            return $"{toDoSubTasks.Count(x => x.IsDone)} done of {toDoSubTasks.Count}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
