using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using TodoApp.Models;

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

        //void onClick_artykuly(object sender, RoutedEventArgs e)
        //{
        //    headline.Text = "Artykuły spożywcze";
        //    headline.Foreground = Brushes.Gray;
        //    text.Foreground = Brushes.Gray;
        //    kind.Foreground = Brushes.Gray;
        //    kind.Kind = PackIconKind.Shop;
        //}


        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            //hack
            PropertiesPanel.Width = 0;
            MainGrid.ColumnDefinitions[2].Width = new GridLength(0);
        }
    }
}
