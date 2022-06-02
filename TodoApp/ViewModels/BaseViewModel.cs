using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using TodoApp.Annotations;
using TodoApp.Extensions;

namespace TodoApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private static readonly PropertyChangedEventArgs AllPropertiesChanged = new PropertyChangedEventArgs(string.Empty);

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void SetProperty<T>(ref T storage, T value, Action<bool>? action, [CallerMemberName] string? propertyName = null)
        {
            if (action == null)
            {
                throw new ArgumentException($"{nameof(action)} should not be null", nameof(action));
            }

            action.Invoke(SetProperty(ref storage, value, propertyName));
        }


        [NotifyPropertyChangedInvocator]
        protected virtual bool SetProperty<T>(ref T storage, T value, Action? afterAction, [CallerMemberName] string? propertyName = null)
        {
            if (SetProperty(ref storage, value, propertyName))
            {
                afterAction?.Invoke();
                return true;
            }

            return false;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

        public virtual Task RaiseAllPropertiesChanged()
        {
            return RaisePropertyChanged(AllPropertiesChanged);
        }

        [NotifyPropertyChangedInvocator]
        public Task RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var name = this.GetPropertyNameFromExpression(propertyExpression);
            return RaisePropertyChanged(name);
        }

        [NotifyPropertyChangedInvocator]
        public virtual Task RaisePropertyChanged([CallerMemberName] string? whichProperty = "")
        {
            var changedArgs = new PropertyChangedEventArgs(whichProperty);
            return RaisePropertyChanged(changedArgs);
        }

        public virtual Task RaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            var taskCompletionSource = new TaskCompletionSource();

            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
            {
                PropertyChanged?.Invoke(this, changedArgs);
                taskCompletionSource.SetResult();
            }));

            return taskCompletionSource.Task;
        }
    }
}
