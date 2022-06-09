using System;
using TodoApp.Converters;
using TodoApp.ViewModels;

namespace TodoApp.Models
{
    public class ToDoTask : ExtendedNotifyPropertyChanged
    {
        private DateTime _created;
        private string _name;
        private bool _isDone;
        private DateTime? _reminder;
        private string _repeat;
        private string _note;
        private bool _star;

        public DateTime Created
        {
            get => _created;
            set => SetProperty(ref _created, value);
        }

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

        public DateTime? Reminder
        {
            get => _reminder;
            set => SetProperty(ref _reminder, value);
        }

        public string Repeat
        {
            get => _repeat;
            set => SetProperty(ref _repeat, value);
        }

        public string Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }

        public bool Star
        {
            get => _star;
            set => SetProperty(ref _star, value);
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
