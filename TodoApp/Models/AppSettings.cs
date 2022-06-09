using TodoApp.ViewModels;

namespace TodoApp.Models
{
    public class AppSettings : ExtendedNotifyPropertyChanged
    {
        private bool _playSound;
        private bool _confirmActions;
        private bool _displayActionAlerts;
        private bool _displayAlerts;

        public bool PlaySound
        {
            get => _playSound;
            set => SetProperty(ref _playSound, value);
        }

        public bool ConfirmActions
        {
            get => _confirmActions;
            set => SetProperty(ref _confirmActions, value);
        }

        public bool DisplayActionAlerts
        {
            get => _displayActionAlerts;
            set => SetProperty(ref _displayActionAlerts, value);
        }

        public bool DisplayAlerts
        {
            get => _displayAlerts;
            set => SetProperty(ref _displayAlerts, value);
        }
    }
}
