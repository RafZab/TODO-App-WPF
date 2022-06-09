using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.ViewModels
{
    public class ExtendedObservableCollection<T> : ObservableCollection<T>
    {
        private bool _isEmpty;

        public bool IsEmpty
        {
            get => _isEmpty;
            private set => SetProperty(ref _isEmpty, value);
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.PropertyName != nameof(Count))
            {
                return;
            }

            IsEmpty = Items.Count == 0;
        }

        protected virtual bool SetProperty<TRet>(ref TRet backingField, TRet newValue, Action<TRet> onPropertyChanged = null, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null || EqualityComparer<TRet>.Default.Equals(backingField, newValue))
            {
                return false;
            }

            backingField = newValue;
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
            onPropertyChanged?.Invoke(newValue);
            return true;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                return;
            }
            foreach (var i in collection) Items.Add(i);
            OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
