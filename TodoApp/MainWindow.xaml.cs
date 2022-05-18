using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
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
        }

        public ObservableCollection<ToDoTask> Tasks { get; set; } = new ObservableCollection<ToDoTask>();

        void onClick_wazne(object sender, RoutedEventArgs e)
        {
            headline.Text = "Ważne";
        }

        void onClick_zaplanowane(object sender, RoutedEventArgs e)
        {
            headline.Text = "Zaplanowane";
        }

        void onClick_do_mnie(object sender, RoutedEventArgs e)
        {
            headline.Text = "Przydzielone do mnie";
        }

        void onClick_mojdzien(object sender, RoutedEventArgs e)
        {
            headline.Text = "Mój dzień";
        }

        void onClick_zadania(object sender, RoutedEventArgs e)
        {
            headline.Text = "Zadania";
        }

        void onClick_wprowadzenie(object sender, RoutedEventArgs e)
        {
            headline.Text = "Wprowadzenie";
        }

        void onClick_artykuly(object sender, RoutedEventArgs e)
        {
            headline.Text = "Artykuły spożywcze";
        }


    }
}
