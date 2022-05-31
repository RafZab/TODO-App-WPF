using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TodoApp.Models;
using TodoApp.Views;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Tasks.Add(new ToDoTask{ IsDone = false, Name = "Test task"});
            Tasks.Add(new ToDoTask { IsDone = true, Name = "Done task" });

            Groups.Add(new TaskGroup("My Day", Colors.CornflowerBlue, PackIconKind.WeatherSunny));
            Groups.Add(new TaskGroup("Important", Colors.IndianRed, PackIconKind.StarOutline));
            Groups.Add(new TaskGroup("Planned", Colors.MediumAquamarine, PackIconKind.CalendarAccountOutline));
            Groups.Add(new TaskGroup("Tasks", Colors.SlateBlue, PackIconKind.House));
            Groups.Add(new TaskGroup("Shopping list", Colors.Gray, PackIconKind.ShoppingCart));
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
    }
}
