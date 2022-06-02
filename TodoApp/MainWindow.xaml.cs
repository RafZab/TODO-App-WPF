using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TodoApp.Models;
using TodoApp.ViewModels;
using TodoApp.Views;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get;}

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            DataContext = ViewModel;
        }

        public ObservableCollection<TaskGroup> Groups { get; set; } = new ObservableCollection<TaskGroup>();

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            //hack
            PropertiesPanel.Width = 0;
            MainGrid.ColumnDefinitions[2].Width = new GridLength(0);
        }

        private void Settings_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var dialogWindow = new SettingsWindow();
            dialogWindow.ShowDialog();
        }

        private void TasksListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TasksListView.SelectedItem is null)
            {
                return;
            }
            MainGrid.ColumnDefinitions[2].Width = GridLength.Auto;
            PropertiesPanel.Width = 270;
        }

        private void AddSubTaskTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ViewModel.AddSubTask();
            }
        }
    }
}
