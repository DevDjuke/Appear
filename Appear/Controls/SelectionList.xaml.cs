using Appear.Events;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Appear.Controls
{
    /// <summary>
    /// Interaction logic for SelectionList.xaml
    /// </summary>
    public partial class SelectionList : UserControl, INotifyPropertyChanged
    {
        #region PROPERTIES

        private string selectedItem;
        public string SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; OnPropertyChanged(); }
        }

        private ObservableCollection<string> itemList; 
        public ObservableCollection<string> ItemList
        {
            get { return itemList; }
            set { itemList = value; OnPropertyChanged(); }
        }

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
            ((SelectionList)sender).Source = value;
            string[] res = Application.Current.FindResource(value) as string[];
            ((SelectionList)sender).ItemList = new ObservableCollection<string>(res);
            ((SelectionList)sender).SelectedItem = Properties.Settings.Default[value].ToString();
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
            ((SelectionList)sender).Text = value;
        }
        #endregion

        public SelectionList()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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
            if(!(sender as ComboBox).SelectedValue.Equals(Properties.Settings.Default[Source].ToString()))
            {
                SelectedItem = (sender as ComboBox).SelectedValue as string;

                Properties.Settings.Default[Source] = SelectedItem;
                Properties.Settings.Default.Save();

                RaiseEvent(new SelectionListChangedEventArgs(SelectionChangedEvent, Source, SelectedItem));            
            }
        }
    }
}
