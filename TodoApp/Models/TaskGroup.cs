using System.Windows.Media;
using MaterialDesignThemes.Wpf;

namespace TodoApp.Models
{
    public class TaskGroup
    {
        public string Name { get; set; }
        public Brush IconBrush { get; set; }

        public PackIconKind Icon { get; set; }

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
