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
        }

        public ObservableCollection<ToDoTask> Tasks { get; set; } = new ObservableCollection<ToDoTask>();

        void onClick_wazne(object sender, RoutedEventArgs e)
        {
            headline.Text = "Ważne";
            headline.Foreground = Brushes.Red;
            text.Foreground = Brushes.Red;
            kind.Foreground = Brushes.Red;
        }

        void onClick_zaplanowane(object sender, RoutedEventArgs e)
        {
            headline.Text = "Zaplanowane";
            headline.Foreground = Brushes.Green;
            text.Foreground = Brushes.Green;
            kind.Foreground = Brushes.Green;
        }

        void onClick_do_mnie(object sender, RoutedEventArgs e)
        {
            headline.Text = "Przydzielone do mnie";
            headline.Foreground = Brushes.Green;
            text.Foreground = Brushes.Green;
            kind.Foreground = Brushes.Green;
        }

        void onClick_mojdzien(object sender, RoutedEventArgs e)
        {
            headline.Text = "Mój dzień";
            headline.Foreground = Brushes.Purple;
            text.Foreground = Brushes.Purple;
            kind.Foreground = Brushes.Purple;
        }

        void onClick_zadania(object sender, RoutedEventArgs e)
        {
            headline.Text = "Zadania";
            headline.Foreground = Brushes.Red;
            text.Foreground = Brushes.Red;
            kind.Foreground = Brushes.Red;
        }

        void onClick_wprowadzenie(object sender, RoutedEventArgs e)
        {
            headline.Text = "Wprowadzenie";
            headline.Foreground = Brushes.Yellow;
            text.Foreground = Brushes.Yellow;
            kind.Foreground = Brushes.Yellow;

        }

        void onClick_artykuly(object sender, RoutedEventArgs e)
        {
            headline.Text = "Artykuły spożywcze";
            headline.Foreground = Brushes.Gray;
            text.Foreground = Brushes.Gray;
            kind.Foreground = Brushes.Gray;
        }


    }
}
