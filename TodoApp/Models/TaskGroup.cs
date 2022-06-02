using System.Collections.ObjectModel;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using TodoApp.ViewModels;

namespace TodoApp.Models
{
    public class TaskGroup : ExtendedNotifyPropertyChanged
    {
        private string _name;
        private Brush _iconBrush;
        private PackIconKind _icon;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public Brush IconBrush
        {
            get => _iconBrush;
            set => SetProperty(ref _iconBrush, value);
        }

        public PackIconKind Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        public ExtendedObservableCollection<ToDoTask> Tasks { get; set; } = new ExtendedObservableCollection<ToDoTask>();

        public TaskGroup(string name, Brush iconBrush, PackIconKind icon)
        {
            Name = name;
            IconBrush = iconBrush;
            Icon = icon;
        }

        public TaskGroup(string name, Color iconColor, PackIconKind icon)
        {
            Name = name;
            IconBrush = new SolidColorBrush(iconColor);
            Icon = icon;
        }
    }
}
