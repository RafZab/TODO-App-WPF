using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using MaterialDesignThemes.Wpf;
using TodoApp.ViewModels;

namespace TodoApp.Controls
{
    /// <summary>
    /// Interaction logic for IconPicker.xaml
    /// </summary>
    public partial class IconPicker : UserControl
    {
        public static readonly DependencyProperty SelectedIconProperty
            = DependencyProperty.Register(nameof(SelectedIcon), typeof(PackIconKind), typeof(IconPicker), new FrameworkPropertyMetadata(PackIconKind.Asterisk, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public PackIconKind SelectedIcon
        {
            get => (PackIconKind)GetValue(SelectedIconProperty);
            set => SetValue(SelectedIconProperty, value);
        }

        public IconPicker()
        {
            Icons = new ExtendedObservableCollection<PackIconKind>();
            Icons.AddRange(GenerateIcons());
            InitializeComponent();
        }

        public ExtendedObservableCollection<PackIconKind> Icons { get; set; }

        private void RandomizeButtonClick(object sender, RoutedEventArgs e)
        {
            Icons.Clear();
            Icons.AddRange(GenerateIcons());
        }

        private List<PackIconKind> GenerateIcons()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            var icons = new List<PackIconKind>();
            for (int i = 0; i < 100; i++)
            {
                icons.Add((PackIconKind)rnd.Next(0, 6700));
            }

            return icons;
        }

        private void RefreshView()
        {
            var view = CollectionViewSource.GetDefaultView(IconsListView.ItemsSource);
            view.Refresh();
        }
    }
}
