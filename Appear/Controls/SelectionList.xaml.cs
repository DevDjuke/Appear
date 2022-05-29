using Appear.Events;
using Appear.ViewModel.Controls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Appear.Controls
{
    /// <summary>
    /// Interaction logic for SelectionList.xaml
    /// </summary>
    public partial class SelectionList : UserControl
    {
        SelectionListViewModel vm;

        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register(
                "Source",
                typeof(string),
                typeof(SelectionList),
                new UIPropertyMetadata(SourcePropertyChangedHandler));

        public static void SourcePropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            ((SelectionList)sender).vm.Id = value;
            string[] res = Application.Current.FindResource(value) as string[];
            ((SelectionList)sender).vm.ItemList = new List<string>(res);
            ((SelectionList)sender).vm.SelectedItem = Properties.Settings.Default[value].ToString();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(SelectionList),
                new UIPropertyMetadata(TextPropertyChangedHandler));

        public static void TextPropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            ((SelectionList)sender).vm.Text = value;
        }

        public SelectionList()
        {
            vm = new SelectionListViewModel();

            InitializeComponent();
            DataContext = vm;
        }

        public static readonly RoutedEvent SelectionChangedEvent =
            EventManager.RegisterRoutedEvent("SelectionChanged", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(SelectionList));

        public event RoutedEventHandler SelectionChanged
        {
            add { AddHandler(SelectionChangedEvent, value); }
            remove { RemoveHandler(SelectionChangedEvent, value); }
        }

        private void OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            if(!(sender as ComboBox).SelectedValue.Equals(Properties.Settings.Default[vm.Id].ToString()))
            {
                vm.SelectedItem = (sender as ComboBox).SelectedValue as string;

                Properties.Settings.Default[vm.Id] = vm.SelectedItem;
                Properties.Settings.Default.Save();

                //RaiseEvent(new SelectionListChangedEventArgs(SelectionChangedEvent, vm.Id, vm.SelectedItem));

                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
        }
    }
}
