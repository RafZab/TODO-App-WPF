using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private AppSettings _settings;

        public SettingsViewModel()
        {
            _settings = DataProvider.Instance.LoadAppSettings() ?? new AppSettings();
        }

        public AppSettings Settings
        {
            get => _settings;
            set => SetProperty(ref _settings, value);
        }

        public void SaveSettings()
        {
            DataProvider.Instance.SaveAppSettings(Settings);
        }
    }
}
