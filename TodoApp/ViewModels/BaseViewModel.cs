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
    public abstract class BaseViewModel : ExtendedNotifyPropertyChanged
    {
    }
}
