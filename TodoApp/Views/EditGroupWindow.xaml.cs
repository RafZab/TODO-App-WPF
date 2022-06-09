using System.Windows;
using TodoApp.Models;
using TodoApp.ViewModels;

namespace TodoApp.Views
{
    /// <summary>
    /// Interaction logic for EditGroupWindow.xaml
    /// </summary>
    public partial class EditGroupWindow : Window
    {
        public EditGroupWindow(TaskGroup taskGroup)
        {
            ViewModel = new EditGroupViewModel(taskGroup);
            ViewModel.OnRequestClose += ViewModelOnOnRequestClose;

            InitializeComponent();
        }

        public TaskGroup Result { get; set; }

        public EditGroupViewModel ViewModel { get; set; }

        public TaskGroup ShowDialogWithResult()
        {
            ShowDialog();
            return Result;
        }

        private void ViewModelOnOnRequestClose(object sender, AddGroupDialogCloseEventArgs e)
        {
            Result = e.Group;
            Host.Close();
        }
    }
}
