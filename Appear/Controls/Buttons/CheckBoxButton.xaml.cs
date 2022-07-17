using Appear.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Appear.Controls.Buttons
{
    /// <summary>
    /// Interaction logic for CheckBoxButton.xaml
    /// </summary>
    public partial class CheckBoxButton : UserControl, INotifyPropertyChanged
    {
        private bool isChecked { get; set; }
        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; OnPropertyChanged(); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string Id
        {
            get { return (string)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(CheckBoxButton),
                new UIPropertyMetadata(""));

        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register(
                "Id",
                typeof(string),
                typeof(CheckBoxButton),
                new UIPropertyMetadata(IdPropertyChangedHandler));

        public static void IdPropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            switch (e.NewValue)
            {
                case "StartUpMax":
                    ((CheckBoxButton)sender).IsChecked = Properties.Settings.Default.MaxOnStart;
                    break;
                case "StartUpUpdate":
                    ((CheckBoxButton)sender).IsChecked = Properties.Settings.Default.UpdateOnStart;
                    break;
                default:
                    break;
            }
        }

        public CheckBoxButton()
        {         
            InitializeComponent();
            
        }

        private void HandleChecked(object sender, RoutedEventArgs e)
        {
            HandleCheckboxToggle(true);
        }

        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {
            HandleCheckboxToggle(false);
        }

        private void HandleCheckboxToggle(bool isChecked)
        {
            RaiseEvent(new CheckBoxToggledEventArgs(CheckboxToggledEvent, isChecked, Id));
        }

        public static readonly RoutedEvent CheckboxToggledEvent =
            EventManager.RegisterRoutedEvent("CheckboxToggled", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(CheckBoxButton));

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event RoutedEventHandler CheckboxToggled
        {
            add { AddHandler(CheckboxToggledEvent, value); }
            remove { RemoveHandler(CheckboxToggledEvent, value); }
        }
    }
}
