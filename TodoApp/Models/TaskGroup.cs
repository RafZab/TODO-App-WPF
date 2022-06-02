using System.Collections.ObjectModel;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using TodoApp.ViewModels;

namespace TodoApp.Models
{
    public class TaskGroup
    {
        public string Name { get; set; }
        public Brush IconBrush { get; set; }
        public PackIconKind Icon { get; set; }
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
