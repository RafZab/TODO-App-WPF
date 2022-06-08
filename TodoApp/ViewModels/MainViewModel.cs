using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using MaterialDesignThemes.Wpf;
using Microsoft.Toolkit.Mvvm.Input;
using TodoApp.Models;
using TodoApp.Views;

namespace TodoApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private TaskGroup _selectedGroup;
        private ToDoTask _selectedTask;
        private string _newTaskName;
        private string _newSubTaskName;

        public DateTime CurrentDate { get; set; } = DateTime.Today;

        public MainViewModel()
        {
            TaskGroups = new ExtendedObservableCollection<TaskGroup>();

            AddGroupCommand = new RelayCommand<string>(AddGroup);
            AddTaskCommand = new RelayCommand(AddTask);
            ToggleTaskCommand = new RelayCommand<ToDoTask>(ToggleTask);
            ToggleSubTaskCommand = new RelayCommand<ToDoSubTask>(ToggleSubTask);
            DeleteTaskCommand = new RelayCommand<ToDoTask>(DeleteTask);
            DeleteGroupCommand = new RelayCommand<TaskGroup>(DeleteGroup);
            DeleteSubTaskCommand = new RelayCommand<ToDoSubTask>(DeleteSubTask);

            TaskGroups.Add(new TaskGroup("My Day", Colors.CornflowerBlue, PackIconKind.WeatherSunny));
            TaskGroups.Add(new TaskGroup("Important", Colors.IndianRed, PackIconKind.StarOutline));
            TaskGroups.Add(new TaskGroup("Planned", Colors.MediumAquamarine, PackIconKind.CalendarAccountOutline));
            TaskGroups.Add(new TaskGroup("Tasks", Colors.SlateBlue, PackIconKind.House));
            TaskGroups.Add(new TaskGroup("Shopping list", Colors.Gray, PackIconKind.ShoppingCart));


            TaskGroups[0].Tasks.Add(new ToDoTask {IsDone = false, Name = "Not done task"});
            TaskGroups[0].Tasks.Add(new ToDoTask { IsDone = false, Name = "Done task" });
            _ = RaiseAllPropertiesChanged();
        }

        private void DeleteSubTask(ToDoSubTask subTask)
        {
            if (subTask is null)
            {
                return;
            }

            SelectedTask?.SubTasks.Remove(subTask);
        }

        private void DeleteGroup(TaskGroup group)
        {
            if (group is null)
            {
                return;
            }

            TaskGroups.Remove(group);
            SelectedGroup = null;
        }

        private void DeleteTask(ToDoTask task)
        {
            if (task is null)
            {
                return;
            }

            SelectedGroup?.Tasks.Remove(task);
            SelectedTask = null; //null selected task
        }

        private void ToggleSubTask(ToDoSubTask subTask)
        {
            if (subTask is null)
            {
                return;
            }
            subTask.IsDone = !subTask.IsDone;
            subTask.RaisePropertyChanged("IsDone");
            SelectedTask?.RaiseAllPropertiesChanged();
        }

        private void ToggleTask(ToDoTask task)
        {
            if (task is null)
            {
                return;
            }
            task.IsDone = !task.IsDone;
            SelectedTask?.RaiseAllPropertiesChanged();
        }

        public void AddTask()
        {
            if (string.IsNullOrEmpty(NewTaskName))
            {
                return;
            }
            SelectedGroup?.Tasks.Add(new ToDoTask { Name = NewTaskName});
            NewTaskName = string.Empty; //clear form
        }

        public void AddSubTask()
        {
            if (string.IsNullOrEmpty(NewSubTaskName))
            {
                return;
            }

            SelectedTask?.SubTasks.Add(new ToDoSubTask {Name = NewSubTaskName});
            NewSubTaskName = string.Empty; //clear form
            SelectedTask?.RaiseAllPropertiesChanged();
        }

        private void AddGroup(string groupName)
        {
            //TaskGroups.Add(new TaskGroup(groupName, Brushes.Gray, PackIconKind.FilterList));
            var dialog = new AddGroupWindow(groupName);

            var result = dialog.ShowDialogWithResult();

            if (result is null)
            {
                return;
            }
            
            TaskGroups.Add(result);
        }

        public TaskGroup SelectedGroup
        {
            get => _selectedGroup;
            set => SetProperty(ref _selectedGroup, value);
        }

        public ToDoTask SelectedTask
        {
            get => _selectedTask;
            set => SetProperty(ref _selectedTask, value);
        }

        public string NewTaskName
        {
            get => _newTaskName;
            set => SetProperty(ref _newTaskName, value);
        }

        public string NewSubTaskName
        {
            get => _newSubTaskName;
            set => SetProperty(ref _newSubTaskName, value);
        }

        public ExtendedObservableCollection<TaskGroup> TaskGroups { get; }

        public IRelayCommand<string> AddGroupCommand { get; }

        public IRelayCommand AddTaskCommand { get; }

        public IRelayCommand<ToDoTask> ToggleTaskCommand { get; }

        public IRelayCommand<ToDoSubTask> ToggleSubTaskCommand { get; }

        public IRelayCommand<ToDoTask> DeleteTaskCommand { get; }

        public IRelayCommand<TaskGroup> DeleteGroupCommand { get; }

        public IRelayCommand<ToDoSubTask> DeleteSubTaskCommand { get; }
    }
}
