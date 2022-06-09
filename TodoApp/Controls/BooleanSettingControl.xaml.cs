using System.Windows;
using System.Windows.Controls;

namespace TodoApp.Controls
{
    /// <summary>
    /// Interaction logic for BooleanSettingControl.xaml
    /// </summary>
    public partial class BooleanSettingControl : UserControl
    {
        public static readonly DependencyProperty SettingNameProperty =
            DependencyProperty.Register("SettingName", typeof(string), typeof(BooleanSettingControl), new FrameworkPropertyMetadata("Setting name", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        public static readonly DependencyProperty IsSettingEnabledProperty =
            DependencyProperty.Register("IsSettingEnabled", typeof(bool), typeof(BooleanSettingControl), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public bool IsSettingEnabled
        {
            get => (bool)GetValue(IsSettingEnabledProperty);
            set => SetValue(IsSettingEnabledProperty, value);
        }

        public string SettingName
        {
            get => (string)GetValue(SettingNameProperty);
            set => SetValue(SettingNameProperty, value);
        }

        public BooleanSettingControl()
        {
            InitializeComponent();
        }
    }
}
