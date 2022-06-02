using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
        public MainViewModel MainViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel = new MainViewModel();
            DataContext = MainViewModel;

            Tasks.Add(new ToDoTask{ IsDone = false, Name = "Test task"});
            Tasks.Add(new ToDoTask { IsDone = true, Name = "Done task", SubTasks = new ObservableCollection<ToDoSubTask>()
            {
                new ToDoSubTask{ IsDone = false, Name = "Not done sub task"},
                new ToDoSubTask{ IsDone = true, Name = "Done sub task"}
            }});
        }

        public ObservableCollection<ToDoTask> Tasks { get; set; } = new ObservableCollection<ToDoTask>();
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

        private void TasksListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TasksListView.SelectedItem is null)
            {
                return;
            }
            MainGrid.ColumnDefinitions[2].Width = GridLength.Auto;
            PropertiesPanel.Width = 270;
        }
    }
}
