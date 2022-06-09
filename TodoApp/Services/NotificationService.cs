using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace TodoApp.Services
{
    public class NotificationService
    {
        private readonly Notifier _notifier;

        private NotificationService()
        {
            _notifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider(
                    parentWindow: Application.Current.MainWindow,
                    corner: Corner.TopRight,
                    offsetX: 10,
                    offsetY: 10);

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(5),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                cfg.Dispatcher = Application.Current.Dispatcher;
            });
        }

        private static NotificationService _instance;

        public static NotificationService Instance => _instance ??= new NotificationService();


        public void ShowAlert(string message)
        {
            var settings = DataProvider.Instance.LoadAppSettings();
            if (!settings.DisplayAlerts)
            {
                return;
            }

            Application.Current.Dispatcher.Invoke(() =>
            {
                _notifier.ShowInformation(message);
            });
        }

        public void ShowActionResult(string message)
        {
            var settings = DataProvider.Instance.LoadAppSettings();
            if (!settings.DisplayActionAlerts)
            {
                return;
            }

            Application.Current.Dispatcher.Invoke(() =>
            {
                _notifier.ShowSuccess(message);
            });
        }
    }
}
