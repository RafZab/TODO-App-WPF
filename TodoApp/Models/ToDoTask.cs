using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoApp.Commands;

namespace TodoApp.Models
{
    public class ToDoTask
    {
        public string Name { get; set; }

        public bool IsDone { get; set; }

        public DataTime Reminder { get; set; }


        public string Repeat { get; set; }

        public ObservableCollection<ToDoSubTask> SubTasks { get; set; }


    }

    public class ToDoSubTask
    {
        public string Name { get; set; }

        public bool IsDone { get; set; }
    }
}
