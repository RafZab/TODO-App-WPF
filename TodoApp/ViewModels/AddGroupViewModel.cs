using System;
using System.Windows.Input;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using Microsoft.Toolkit.Mvvm.Input;
using TodoApp.Models;

namespace TodoApp.ViewModels
{
    public class AddGroupDialogCloseEventArgs : EventArgs
    {
        public TaskGroup Group { get; set; }
    }

    public class AddGroupViewModel : BaseViewModel
    {
        private string _groupName;
        private string _emojiIcon;
        private PackIconKind _iconKind;
        private Color _theme;

        public string GroupName
        {
            get => _groupName;
            set => SetProperty(ref _groupName, value);
        }

        public Color Theme
        {
            get => _theme;
            set => SetProperty(ref _theme, value);
        }

        public PackIconKind IconKind
        {
            get => _iconKind;
            set => SetProperty(ref _iconKind, value);
        }

        public string EmojiIcon
        {
            get => _emojiIcon;
            set => SetProperty(ref _emojiIcon, value);
        }

        public event EventHandler<AddGroupDialogCloseEventArgs> OnRequestClose;

        public AddGroupViewModel(string groupName)
        {
            AddGroupCommand = new RelayCommand(AddGroup);

            GroupName = groupName;
            IconKind = PackIconKind.Add;
            Theme = Colors.Gray;
        }

        private void AddGroup()
        {
            OnRequestClose?.Invoke(this, new AddGroupDialogCloseEventArgs
            {
                Group = new TaskGroup(GroupName, Theme, IconKind)
            });
        }

        public ICommand AddGroupCommand { get; }
    }
}
