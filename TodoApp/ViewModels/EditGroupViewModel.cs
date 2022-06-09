using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using Microsoft.Toolkit.Mvvm.Input;
using TodoApp.Models;

namespace TodoApp.ViewModels
{
    public class EditGroupDialogCloseEventArgs : EventArgs
    {
        public TaskGroup Group { get; set; }
    }

    public class EditGroupViewModel : BaseViewModel
    {
        private TaskGroup _taskGroup;

        public TaskGroup TaskGroup
        {
            get => _taskGroup; 
            set => SetProperty(ref _taskGroup, value);
        }

        public event EventHandler<AddGroupDialogCloseEventArgs> OnRequestClose;

        public EditGroupViewModel(TaskGroup taskGroup)
        {

            EditGroupCommand = new RelayCommand(AddGroup);
            TaskGroup = taskGroup;
        }

        private void AddGroup()
        {
            OnRequestClose?.Invoke(this, new AddGroupDialogCloseEventArgs
            {
                Group = TaskGroup
            });
        }

        public ICommand EditGroupCommand { get; }
    }
}
