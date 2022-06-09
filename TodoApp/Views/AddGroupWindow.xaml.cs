using System.Windows;
using System.Windows.Media;
using TodoApp.Models;
using TodoApp.ViewModels;

namespace TodoApp.Views
{
    /// <summary>
    /// Interaction logic for AddGroupWindow.xaml
    /// </summary>
    public partial class AddGroupWindow : Window
    {
        public AddGroupWindow(string groupName = "New group")
        {
            ViewModel = new AddGroupViewModel(groupName);
            ViewModel.OnRequestClose += ViewModelOnOnRequestClose;

            InitializeComponent();
        }

        private void ViewModelOnOnRequestClose(object sender, AddGroupDialogCloseEventArgs e)
        {
            Result = e.Group;
            Host.Close();
        }

        public TaskGroup Result { get; set; }

        public AddGroupViewModel ViewModel { get; set; }

        public TaskGroup ShowDialogWithResult()
        {
            ShowDialog();
            return Result;
        }
    }
}
