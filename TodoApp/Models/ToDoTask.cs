using System;
using TodoApp.ViewModels;

namespace TodoApp.Models
{
    public class ToDoTask : ExtendedNotifyPropertyChanged
    {
        private string _name;
        private bool _isDone;
        private DateTime _reminder;
        private string _repeat;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public bool IsDone
        {
            get => _isDone;
            set => SetProperty(ref _isDone, value);
        }

        public DateTime Reminder
        {
            get => _reminder;
            set => SetProperty(ref _reminder, value);
        }

        public string Repeat
        {
            get => _repeat;
            set => SetProperty(ref _repeat, value);
        }

        public ExtendedObservableCollection<ToDoSubTask> SubTasks { get; set; } =
            new ExtendedObservableCollection<ToDoSubTask>();
    }

    public class ToDoSubTask : ExtendedNotifyPropertyChanged
    {
        private string _name;
        private bool _isDone;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public bool IsDone
        {
            get => _isDone;
            set => SetProperty(ref _isDone, value);
        }
    }
}
