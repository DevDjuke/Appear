    using Appear.Controls;
using Appear.Core;
using Appear.Events;
using Appear.Views;
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

namespace Appear
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isFocused = true;
        private bool isPresenting = false;

        public MainWindow()
        {
            Content = new MainView();
            InitializeComponent();

            AddHandler(TextButton.TextButtonClickedEvent, new RoutedEventHandler(TextButtonClickedEventHandler));
            AddHandler(IconButton.IconButtonClickedEvent, new RoutedEventHandler(IconButtonClickedEventHandler));
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (isFocused)
            {
                base.OnMouseLeftButtonDown(e);
                DragMove();
            }
        }

        private void TextButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            TextButtonClickedEventArgs arg = (TextButtonClickedEventArgs)e;

            switch (arg.Action)
            {
                case "OpenStyles":
                    StylesWindow window = new StylesWindow();
                    window.Owner = this;
                    window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    window.Closed += new EventHandler(ReturnFocus);
                    window.Show();
                    isFocused = false;
                    IsEnabled = false;
                    break;
                default:
                    break;
            }
        }

        private void ReturnFocus(object sender, EventArgs e)
        {
            isFocused = true;
            IsEnabled = true;
        }

        private void IconButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            IconButtonClickedEventArgs arg = (IconButtonClickedEventArgs)e;

            switch (arg.Action)
            {
                case "MaxMain":
                    if (isPresenting)
                    {
                        App.Current.Resources["Corner"] = new CornerRadius(25);
                        WindowState = WindowState.Normal;
                    }
                    else
                    {
                        App.Current.Resources["Corner"] = new CornerRadius(0);
                        WindowState = WindowState.Maximized;
                    }
                    isPresenting = !isPresenting;
                    break;
                case "CloseStyles":
                    isFocused = true;
                    break;
                case "CloseMain":
                    Close();
                    break;
                default:
                    break;
            }
        }
    }
}
