using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;
using MaterialDesignThemes.Wpf;
using Microsoft.Toolkit.Mvvm.Input;
using TodoApp.Models;
using TodoApp.Services;
using TodoApp.Views;

namespace TodoApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private TaskGroup _selectedGroup;
        private ToDoTask _selectedTask;
        private string _newTaskName;
        private string _newSubTaskName;
        private string _newGroupName;

        public DateTime CurrentDate { get; } = DateTime.Today;

        public event EventHandler OnRefreshRequest;

        public MainViewModel()
        {
            TaskGroups = new ExtendedObservableCollection<TaskGroup>();
            
            AddGroupCommand = new RelayCommand(AddGroup);
            EditGroupCommand = new RelayCommand<TaskGroup>(EditGroup);
            AddTaskCommand = new RelayCommand(AddTask);
            ToggleTaskCommand = new RelayCommand<ToDoTask>(ToggleTask);
            ToggleSubTaskCommand = new RelayCommand<ToDoSubTask>(ToggleSubTask);
            DeleteTaskCommand = new RelayCommand<ToDoTask>(DeleteTask);
            DeleteGroupCommand = new RelayCommand<TaskGroup>(DeleteGroup);
            DeleteSubTaskCommand = new RelayCommand<ToDoSubTask>(DeleteSubTask);
            ToggleStarTaskCommand = new RelayCommand(ToggleStarCommand);
            PrintTasksCommand = new RelayCommand(PrintTasks);

            LoadData();

            SelectedGroup = TaskGroups.First();
            SelectedTask = null;
            _ = RaiseAllPropertiesChanged();

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += TimerTick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }

        private void PrintTasks()
        {
            var printDialog = new PrintDialog();
            bool? print = printDialog.ShowDialog();
            if (print == false)
            {
                return;
            }

            var document = CreateDocument();
            document.Name = "Tasks";
            IDocumentPaginatorSource idpSource = document;
            printDialog.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
        }

        private FlowDocument CreateDocument()
        {
            var doc = new FlowDocument();
            doc.Blocks.Add(new Paragraph(new Bold(new Run($"Tasks {DateTime.Today.ToShortDateString()}")) { FontSize = 18}));

            foreach (var taskGroup in TaskGroups)
            {
                var headerParagraph = new Paragraph(new Bold(new Run(taskGroup.Name)))
                {
                    FontSize = 14,
                    Margin = new Thickness(0, 40, 0, 0)
                };
                doc.Blocks.Add(headerParagraph);

                if (taskGroup.Tasks.Count == 0)
                {
                    doc.Blocks.Add(new Paragraph(new Italic(new Run("No tasks in group") { FontSize = 10 })));
                }

                var list = new List();
                foreach (var task in taskGroup.Tasks)
                {
                    var listItemTask = new ListItem(CreateTaskParagraph(task));

                    var subTaskList = new List();
                    foreach (var subTask in task.SubTasks)
                    {
                        subTaskList.ListItems.Add(new ListItem(CreateSubTaskParagraph(subTask)));
                    }
                    listItemTask.Blocks.Add(subTaskList);
                    list.ListItems.Add(listItemTask);
                }
                
                doc.Blocks.Add(list);
            }

            return doc;
        }

        private Paragraph CreateTaskParagraph(ToDoTask task)
        {
            if (task is null)
            {
                return new Paragraph();
            }

            var paragraph = new Paragraph(new Run(task.Name));

            if (task.IsDone)
            {
                paragraph.TextDecorations = TextDecorations.Strikethrough;
            }

            return paragraph;
        }

        private Paragraph CreateSubTaskParagraph(ToDoSubTask subTask)
        {
            if (subTask is null)
            {
                return new Paragraph();
            }

            var paragraph = new Paragraph(new Run(subTask.Name));

            if (subTask.IsDone)
            {
                paragraph.TextDecorations = TextDecorations.Strikethrough;
            }

            return paragraph;
        }

        private void EditGroup(TaskGroup group)
        {
            if (group == null)
            {
                return;
            }

            var dialog = new EditGroupWindow(group);
            var result = dialog.ShowDialogWithResult();
            if (result is null)
            {
                return;
            }

            TaskGroups[TaskGroups.IndexOf(group)] = result; //replace :/
            SelectedGroup?.RaiseAllPropertiesChanged();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            var tasks = TaskGroups.SelectMany(x => x.Tasks).ToList();
            foreach (var task in tasks)
            {
                if (!task.Reminder.HasValue)
                {
                    continue;
                }

                var reminder = task.Reminder.Value;

                var reminderDate = new DateTime(reminder.Year, reminder.Month, reminder.Day, reminder.Hour, reminder.Minute, 0,
                    DateTimeKind.Local);

                var dateNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0,
                    DateTimeKind.Local);

                if (reminderDate <= dateNow)
                {
                    NotificationService.Instance.ShowAlert($"Reminding of {task.Name}");

                    task.Reminder = null;
                }
            }
        }

        private void LoadData()
        {
            var data = DataProvider.Instance.LoadTaskGroups();
            TaskGroups.AddRange(data);

            if (TaskGroups.Count == 0)
            {
                InitDefaultData();
            }
        }

        private void InitDefaultData()
        {
            TaskGroups.Add(new TaskGroup("My Day", Colors.CornflowerBlue, PackIconKind.WeatherSunny));
            TaskGroups.Add(new TaskGroup("Important", Colors.IndianRed, PackIconKind.StarOutline));
            TaskGroups.Add(new TaskGroup("Planned", Colors.MediumAquamarine, PackIconKind.CalendarAccountOutline));
            TaskGroups.Add(new TaskGroup("Tasks", Colors.SlateBlue, PackIconKind.House));
            TaskGroups.Add(new TaskGroup("Shopping list", Colors.Gray, PackIconKind.ShoppingCart));
        }

        private void SaveData()
        {
            DataProvider.Instance.SaveTaskGroups(TaskGroups.ToList());
        }

        private void ToggleStarCommand()
        {
            if (SelectedTask is null)
            {
                return;
            }
            SelectedTask.Star = !SelectedTask.Star;
            SelectedTask?.RaiseAllPropertiesChanged();
            OnOnRefreshRequest();
            SaveData();
        }

        private void DeleteSubTask(ToDoSubTask subTask)
        {
            if (subTask is null)
            {
                return;
            }

            var result = DisplayMessageBox("Do you really want to delete this subtask?", "Delete SubTask", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }

            SelectedTask?.SubTasks.Remove(subTask);
            OnOnRefreshRequest();
            SaveData();
            NotificationService.Instance.ShowActionResult("Sub task deleted");
        }

        private void DeleteGroup(TaskGroup group)
        {
            if (group is null)
            {
                return;
            }

            var result = DisplayMessageBox("Do you really want to delete this task group?", "Delete Group", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }

            TaskGroups.Remove(group);
            SelectedGroup = null;
            SaveData();
            NotificationService.Instance.ShowActionResult("Group deleted");
        }

        private void DeleteTask(ToDoTask task)
        {
            if (task is null)
            {
                return;
            }

            var result = DisplayMessageBox( "Do you really want to delete this task?", "Delete Task", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }

            SelectedGroup?.Tasks.Remove(task);
            SelectedTask = null; //null selected task
            SaveData();
            NotificationService.Instance.ShowActionResult("Task deleted");
        }

        private void ToggleSubTask(ToDoSubTask subTask)
        {
            if (subTask is null)
            {
                return;
            }
            subTask.IsDone = !subTask.IsDone;
            subTask.RaiseAllPropertiesChanged();
            SelectedTask?.RaiseAllPropertiesChanged();
            SaveData();
        }

        private void ToggleTask(ToDoTask task)
        {
            if (task is null)
            {
                return;
            }

            if (!task.IsDone)
            {
                SoundPlayerService.Instance.PlayDoneSound();
            }

            task.IsDone = !task.IsDone;
            SelectedTask?.RaiseAllPropertiesChanged();
            OnOnRefreshRequest();
            SaveData();
        }

        public void AddTask()
        {
            if (string.IsNullOrEmpty(NewTaskName))
            {
                return;
            }

            if (SelectedGroup is null)
            {
                NotificationService.Instance.ShowError("There's no group selected!");
                NewTaskName = string.Empty;
                return;
            }

            SelectedGroup?.Tasks.Add(new ToDoTask { Name = NewTaskName, Created = DateTime.Now});
            NewTaskName = string.Empty; //clear form
            OnOnRefreshRequest();
            SaveData();
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
            SelectedGroup?.RaiseAllPropertiesChanged();
            SaveData();
        }

        private void AddGroup()
        {
            if (string.IsNullOrWhiteSpace(NewGroupName))
            {
                return;
            }
            var dialog = new AddGroupWindow(NewGroupName);
            var result = dialog.ShowDialogWithResult();

            if (result is null)
            {
                return;
            }
            
            TaskGroups.Add(result);
            SaveData();
            NewGroupName = string.Empty;
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

        public string NewGroupName
        {
            get => _newGroupName;
            set => SetProperty(ref _newGroupName, value);
        }

        private MessageBoxResult DisplayMessageBox(string message, string caption, MessageBoxButton button)
        {
            var settings = DataProvider.Instance.LoadAppSettings();
            if (!settings.ConfirmActions)
            {
                return MessageBoxResult.Yes;
            }

            return MessageBox.Show(message, caption, button);
        }

        public ExtendedObservableCollection<TaskGroup> TaskGroups { get; }

        public IRelayCommand AddGroupCommand { get; }

        public IRelayCommand<TaskGroup> EditGroupCommand { get; }

        public IRelayCommand AddTaskCommand { get; }

        public IRelayCommand<ToDoTask> ToggleTaskCommand { get; }

        public IRelayCommand<ToDoSubTask> ToggleSubTaskCommand { get; }

        public IRelayCommand<ToDoTask> DeleteTaskCommand { get; }

        public IRelayCommand<TaskGroup> DeleteGroupCommand { get; }

        public IRelayCommand<ToDoSubTask> DeleteSubTaskCommand { get; }

        public IRelayCommand ToggleStarTaskCommand { get; }

        public IRelayCommand PrintTasksCommand { get; }

        protected virtual void OnOnRefreshRequest()
        {
            OnRefreshRequest?.Invoke(this, EventArgs.Empty);
        }
    }
}
