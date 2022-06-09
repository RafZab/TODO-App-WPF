using System;
using System.Media;

namespace TodoApp.Services
{
    public class SoundPlayerService
    {
        private const string doneSound = "completed.wav";

        private SoundPlayerService()
        {
        }

        private static SoundPlayerService _instance;

        public static SoundPlayerService Instance => _instance ??= new SoundPlayerService();

        public void PlayDoneSound()
        {
            var settings = DataProvider.Instance.LoadAppSettings();
            if (!settings.PlaySound)
            {
                return;
            }

            var sound = new SoundPlayer($"./Resources/Sound/{doneSound}");
            sound.Play();
        }
    }
}
