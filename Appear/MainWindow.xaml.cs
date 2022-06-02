    using Appear.Controls;
using Appear.Controls.AssetGrid;
using Appear.Controls.Buttons;
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
        public MainWindow()
        {
            //DataManager.DatabaseSetup();

            Content = new MainView();
            InitializeComponent();

            AddHandler(TextButton.TextButtonClickedEvent, new RoutedEventHandler(TextButtonClickedEventHandler));
            AddHandler(IconButton.IconButtonClickedEvent, new RoutedEventHandler(IconButtonClickedEventHandler));

            AddHandler(AssetGrid.SelectionChangedEvent, new RoutedEventHandler(AssetSelectionChangedEventHandler));

            StyleManager.SetTheme();
            StyleManager.SetPreferences(this);         
        }

        void OnLoad(object sender, RoutedEventArgs e)
        {
            (Content as MainView).AssetGrid.SetWidth(this);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (IsEnabled)
            {
                base.OnMouseLeftButtonDown(e);
                DragMove();
            }
        }

        public static readonly RoutedEvent MenuBarChangedEvent =
            EventManager.RegisterRoutedEvent("MenuBarChanged", RoutingStrategy.Tunnel,
                typeof(RoutedEventHandler), typeof(MainWindow));

        public event RoutedEventHandler MenuBarChanged
        {
            add { AddHandler(MenuBarChangedEvent, value); }
            remove { RemoveHandler(MenuBarChangedEvent, value); }
        }

        private void SurrenderFocus(Window window)
        {
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Closed += new EventHandler(ReturnFocus);
            window.Show();
            IsEnabled = false;
        }

        private void OnThemeChanged(object sender, EventArgs e)
        {
            StyleManager.SetTheme();
        }

        private void OnMenuBarChanged(object sender, EventArgs e)
        {
            (Content as MainView).vm.DockPosition = Properties.Settings.Default.DockPositions;
            StyleManager.UpdateMenuBar();
        }

        private void OnAssetListChanged(object sender, EventArgs e)
        {
            (Content as MainView).vm.HasAssets = AssetManager.HasAssets();

            if (AssetManager.HasAssets())
            {
                (Content as MainView).AssetGrid.UpdateGrid();
            }
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
                    if (this.WindowState == WindowState.Maximized)
                    {
                        StyleManager.UpdateStyle("Restore", this);
                        (Content as MainView).AssetGrid.SetWidth(this);
                    }
                    else
                    {
                        StyleManager.UpdateStyle("Maximize", this);
                        (Content as MainView).AssetGrid.SetWidth(this);
                    }
                    break;
                case "OpenInfo":
                    AboutWindow window_about = new AboutWindow();
                    SurrenderFocus(window_about);
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

        private void TextButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            TextButtonClickedEventArgs arg = (TextButtonClickedEventArgs)e;

            switch (arg.Action)
            {
                case "OpenStyles":
                    StylesWindow window_styles = new StylesWindow();
                    window_styles.ThemeChanged += new EventHandler(OnThemeChanged);
                    window_styles.MenuBarChanged += new EventHandler(OnMenuBarChanged);
                    SurrenderFocus(window_styles);
                    break;
                case "OpenAssets":
                    AssetWindow window_assets = new AssetWindow();
                    window_assets.AssetListChanged += new EventHandler(OnAssetListChanged);
                    SurrenderFocus(window_assets);
                    break;
                default:
                    break;
            }
        }

        private void AssetSelectionChangedEventHandler(object sender, RoutedEventArgs e)
        {
            SelectedAssetChangedEventArgs arg = (SelectedAssetChangedEventArgs)e;
            (Content as MainView).ControlPanel.SelectedAsset = arg.Asset;
        }
    }
}
