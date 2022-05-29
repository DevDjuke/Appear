    using Appear.Controls;
using Appear.Core;
using Appear.Events;
using Appear.Services;
using Appear.ViewModel;
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
        private bool isPresenting = false;

        public MainWindow()
        {
            Content = new MainView();
            InitializeComponent();

            AddHandler(TextButton.TextButtonClickedEvent, new RoutedEventHandler(TextButtonClickedEventHandler));
            AddHandler(IconButton.IconButtonClickedEvent, new RoutedEventHandler(IconButtonClickedEventHandler));

            StyleManager.SetTheme();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (IsEnabled)
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
                    SurrenderFocus(new StylesWindow());
                    break;
                case "OpenAssets":
                    SurrenderFocus(new AssetWindow());
                    break;
                default:
                    break;
            }
        }

        private void SurrenderFocus(Window window)
        {
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Closed += new EventHandler(ReturnFocus);
            window.Show();
            IsEnabled = false;
        }

        private void ReturnFocus(object sender, EventArgs e)
        {
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
                        StyleManager.UpdateStyle("Restore");
                        WindowState = WindowState.Normal;
                    }
                    else
                    {
                        StyleManager.UpdateStyle("Maximize");
                        WindowState = WindowState.Maximized;
                    }
                    isPresenting = !isPresenting;
                    break;
                case "CloseStyles":
                    IsEnabled = true;
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
