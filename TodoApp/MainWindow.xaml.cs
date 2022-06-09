using System;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using TodoApp.Models;
using TodoApp.ViewModels;
using TodoApp.Views;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get;}

        public MainWindow()
        {
            ViewModel = new MainViewModel();
            DataContext = ViewModel;
            ViewModel.OnRefreshRequest += OnOnRefreshRequest;

            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            var view = CollectionViewSource.GetDefaultView(TasksListView.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("IsDone", ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription("Star", ListSortDirection.Descending));
        }

        private void OnOnRefreshRequest(object sender, EventArgs e)
        {
            var view = CollectionViewSource.GetDefaultView(TasksListView.ItemsSource);
            if (view is null)
            {
                return;
            }

            if (view.SortDescriptions.Count == 0)
            {
                view.SortDescriptions.Add(new SortDescription("IsDone", ListSortDirection.Ascending));
                view.SortDescriptions.Add(new SortDescription("Star", ListSortDirection.Descending));
            }
            view.Refresh();
        }

        public ObservableCollection<TaskGroup> Groups { get; set; } = new ObservableCollection<TaskGroup>();

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            //hack
            PropertiesPanel.Width = 0;
            MainGrid.ColumnDefinitions[2].Width = new GridLength(0);
        }

        private void Settings_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var dialogWindow = new SettingsWindow();
            dialogWindow.ShowDialog();
        }

        private void AddSubTaskTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ViewModel.AddSubTask();
            }
        }

        private bool GroupFilter(object item)
        {
            return item is TaskGroup taskGroup && taskGroup.Name.Contains(SearchTextBox.Text, StringComparison.CurrentCultureIgnoreCase);
        }

        private bool TasksFilter(object item)
        {
            return item is ToDoTask toDoTask && toDoTask.Name.Contains(TasksSearchTextBox.Text, StringComparison.CurrentCultureIgnoreCase);
        }

        private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var view = CollectionViewSource.GetDefaultView(GroupListView.ItemsSource);
            view.Filter = GroupFilter;
            view.Refresh();
        }

        private void TasksSearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var view = CollectionViewSource.GetDefaultView(TasksListView.ItemsSource);
            view.Filter = TasksFilter;
            view.Refresh();
        }

        private void TaskNameTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ViewModel.AddTask();
            }
        }
    }
}
