using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;
using TodoApp.Models;

namespace TodoApp.Behaviors
{
    class PropertyMenuBehavior : Behavior<Grid>
    {
        private ToDoTask _attached;
        public ToDoTask SelectedTask
        {
            get => (ToDoTask)GetValue(SelectedTaskProperty);
            set => SetValue(SelectedTaskProperty, value);
        }

        public static readonly DependencyProperty SelectedTaskProperty =
            DependencyProperty.Register("SelectedTask", typeof(ToDoTask), typeof(PropertyMenuBehavior),
                new PropertyMetadata( null));
    }
}
