using System.Windows.Input;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using Microsoft.Toolkit.Mvvm.Input;
using TodoApp.Models;

namespace TodoApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            TaskGroups = new ExtendedObservableCollection<TaskGroup>();
            AddGroupCommand = new RelayCommand<string>(AddGroup);
        }

        private void AddGroup(string groupName)
        {
            TaskGroups.Add(new TaskGroup(groupName, Brushes.Gray, PackIconKind.FilterList));
        }

        public ExtendedObservableCollection<TaskGroup> TaskGroups { get; }

        public ICommand AddGroupCommand { get; }
    }
}
