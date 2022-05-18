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



    }
}
