using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoApp.Commands;
using TodoApp.ViewModels;

namespace TodoApp.Models
{
    public class ToDoTask
    {
        public string Name { get; set; }

        public bool IsDone { get; set; }

        public DateTime Reminder { get; set; }

        public string Repeat { get; set; }

        public ExtendedObservableCollection<ToDoSubTask> SubTasks { get; set; } =
            new ExtendedObservableCollection<ToDoSubTask>();
    }

    public class ToDoSubTask
    {
        public string Name { get; set; }

        public bool IsDone { get; set; }
    }
}
