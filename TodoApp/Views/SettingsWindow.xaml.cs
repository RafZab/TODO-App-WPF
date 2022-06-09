using System.ComponentModel;
using System.Windows;
using TodoApp.ViewModels;

namespace TodoApp.Views
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            ViewModel = new SettingsViewModel();
            DataContext = ViewModel;

            InitializeComponent();
        }

        public SettingsViewModel ViewModel { get; set; }

        private void HostWindowClosing(object sender, CancelEventArgs e)
        {
            ViewModel?.SaveSettings();
        }
    }
}
