using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TodoApp.Controls
{
    /// <summary>
    /// Interaction logic for BooleanSettingControl.xaml
    /// </summary>
    public partial class BooleanSettingControl : UserControl
    {
        public static readonly DependencyProperty SettingNameProperty =
            DependencyProperty.Register("SettingName", typeof(string), typeof(PropertyControl), new PropertyMetadata(null));


        public static readonly DependencyProperty IsSettingEnabledProperty =
            DependencyProperty.Register("IsSettingEnabled", typeof(bool), typeof(PropertyControl), new PropertyMetadata(null));

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
