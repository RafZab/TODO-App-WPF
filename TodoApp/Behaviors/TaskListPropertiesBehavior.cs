using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;
using TodoApp.Models;

namespace TodoApp.Behaviors
{
    public class TaskListPropertiesBehavior : Behavior<ListView>
    {
        public static readonly DependencyProperty TargetGridProperty =
            DependencyProperty.Register("TargetGrid", typeof(Grid), typeof(TaskListPropertiesBehavior),
                new PropertyMetadata(null));

        public Grid TargetGrid
        {
            get => (Grid)GetValue(TargetGridProperty);
            set => SetValue(TargetGridProperty, value);
        }

        public static readonly DependencyProperty PropertyMenuProperty =
            DependencyProperty.Register("PropertyMenu", typeof(Grid), typeof(TaskListPropertiesBehavior),
                new PropertyMetadata(null));

        public Grid PropertyMenu
        {
            get => (Grid)GetValue(PropertyMenuProperty);
            set => SetValue(PropertyMenuProperty, value);
        }


        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += AssociatedObjectOnSelectionChanged;
        }

        private void AssociatedObjectOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AssociatedObject?.SelectedItem is null)
            {
                HideGridColumn();
                return;
            }

            ShowGridColumn();
        }

        private void ShowGridColumn()
        {
            if (PropertyMenu.Width > 0)
            {
                return;
            }

            TargetGrid.ColumnDefinitions[2].Width = GridLength.Auto;
            PropertyMenu.Width = 270;
        }

        private void HideGridColumn()
        {
            if (PropertyMenu.Width == 0)
            {
                return;
            }

            PropertyMenu.Width = 0;
            TargetGrid.ColumnDefinitions[2].Width = new GridLength(0);
        }
    }
}
