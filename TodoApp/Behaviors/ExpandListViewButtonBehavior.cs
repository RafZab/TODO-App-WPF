using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace TodoApp.Behaviors
{
    public class ExpandListViewButtonBehavior : Behavior<Button>
    {
        public static readonly DependencyProperty TargetListViewProperty =
            DependencyProperty.Register("TargetListView", typeof(ListView), typeof(ExpandListViewButtonBehavior),
                new PropertyMetadata(null));

        public static readonly DependencyProperty IsDisabledProperty =
            DependencyProperty.Register("IsDisabled", typeof(bool), typeof(ExpandListViewButtonBehavior),
                new PropertyMetadata(null));

        public ListView TargetListView
        {
            get => (ListView)GetValue(TargetListViewProperty);
            set => SetValue(TargetListViewProperty, value);
        }

        public bool IsDisabled
        {
            get => (bool)GetValue(IsDisabledProperty);
            set => SetValue(IsDisabledProperty, value);
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Click += AssociatedObjectOnClick;
        }

        private void AssociatedObjectOnClick(object sender, RoutedEventArgs e)
        {
            if (TargetListView.Height > 0)
            {
                TargetListView.Height = 0;
                return;
            }

            if (IsDisabled)
            {
                return;
            }
            TargetListView.Height = 200;
        }
    }
}
