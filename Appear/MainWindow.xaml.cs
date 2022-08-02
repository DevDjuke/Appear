using Appear.Controls.Components.Buttons;
using Appear.Controls.Components.List;
using Appear.Domain;
using Appear.Domain.Enum;
using Appear.Events;
using Appear.Services;
using Appear.Services.Data;
using Appear.Services.Data.Domain;
using Appear.Views;
using Appear.Windows;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Appear
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Asset> SelectedAssets;

        public MainWindow()
        {   
            Content = new MainView();
            InitializeComponent();

            AddHandler(TextButton.TextButtonClickedEvent, new RoutedEventHandler(TextButtonClickedEventHandler));
            AddHandler(IconButton.IconButtonClickedEvent, new RoutedEventHandler(IconButtonClickedEventHandler));
            AddHandler(ImageGrid.SelectionChangedEvent, new RoutedEventHandler(AssetSelectionChangedEventHandler));

            StyleManager.StartUp(this);

            Loaded += OnLoad;
        }

        void OnLoad(object sender, RoutedEventArgs e)
        {
            (Content as MainView).AssetGrid.SetWidth(this);
            (Content as MainView).PresenterControl.SetDimensions(this);

#if !DEBUG
            if (Properties.Settings.Default.UpdateOnStart)
            {
                OkDialog dialog = new OkDialog("A new version is available.");
                SurrenderFocus(dialog);
            }           
#endif
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (IsEnabled)
            {
                base.OnMouseLeftButtonDown(e);
                DragMove();
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

        private void OnThemeChanged(object sender, EventArgs e)
        {
            string theme = ((ThemeChangedEventArgs)e).Theme;
            StyleManager.SetCurrentStyle(theme);
        }

        private void OnMenuBarChanged(object sender, EventArgs e)
        {
            string position = ((MenuBarChangedEventArgs)e).Position;
            SettingsManager.SetDockPosition((DockPosition)Enum.Parse(typeof(DockPosition), position));
            StyleManager.UpdateStyle();
            (Content as MainView).DockPosition = StyleManager.GetUserSettings().DockPosition.ToString();            
        }

        private void OnDisplayWidthChanged(object sender, EventArgs e)
        {
            string value = ((DisplayWidthChangedEventArgs)e).DisplayWidth;
            DisplayWidth displayWidth = (DisplayWidth)Enum.Parse(typeof(DisplayWidth), value);
            SettingsManager.SetDisplayWidth(displayWidth);
            (Content as MainView).AssetGrid.DisplayWidth = displayWidth;
        }

        private void OnAssetListChanged(object sender, EventArgs e)
        {
            (Content as MainView).HasAssets = FolderManager.HasFolders();

            if (FolderManager.HasFolders())
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
                case IconButtonAction.MaxMain:
                    if (this.WindowState == WindowState.Maximized)
                    {
                        StyleManager.SetWindowState(this, "Restore");
                        (Content as MainView).AssetGrid.SetWidth(this);
                    }
                    else
                    {
                        StyleManager.SetWindowState(this, "Maximize");
                        (Content as MainView).AssetGrid.SetWidth(this);
                    }
                    break;
                case IconButtonAction.OpenInfo:
                    AboutWindow window_about = new AboutWindow();
                    SurrenderFocus(window_about);
                    break;
                case IconButtonAction.CloseStyles:
                    IsEnabled = true;
                    break;
                case IconButtonAction.CloseMain:
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
                    window_styles.DisplayWidthChanged += new EventHandler(OnDisplayWidthChanged);
                    SurrenderFocus(window_styles);
                    break;
                case "OpenAssets":
                    AssetWindow window_assets = new AssetWindow();
                    window_assets.AssetListChanged += new EventHandler(OnAssetListChanged);
                    SurrenderFocus(window_assets);
                    break;
                case "PresentAsset":              
                    StartPresenting();
                    break;
                default:
                    break;
            }
        }

        private void StopPresenting(object sender, EventArgs e)
        {
            StyleManager.SetWindowState(this, "StopPresenting");           
            (Content as MainView).IsPresenting = false;
            (Content as MainView).PresenterControl.selectedIndex = 0;
        }

        private void StartPresenting()
        {
            this.Visibility = Visibility.Hidden;
            StyleManager.SetWindowState(this, "Present");
            (Content as MainView).PresenterControl.SetDimensions(this);
            (Content as MainView).IsPresenting = true;
            PresentWindow window_presents = new PresentWindow(SelectedAssets);
            this.Visibility = Visibility.Visible;
            SurrenderFocus(window_presents);
            window_presents.Closed += new EventHandler(StopPresenting);
            window_presents.NextAsset += new EventHandler(NextAsset);
            window_presents.PreviousAsset += new EventHandler(PrevAsset);
            window_presents.SelectedAsset += new EventHandler(SelectedAsset);
        }

        private void SelectedAsset(object sender, EventArgs e)
        {
            (Content as MainView).PresenterControl.Present(((PresentWindow)sender).selectedAsset);
        }


        private void NextAsset(object sender, EventArgs e)
        {
            (Content as MainView).PresenterControl.Next();
        }

        private void PrevAsset(object sender, EventArgs e)
        {
            (Content as MainView).PresenterControl.Previous();
        }

        private void AssetSelectionChangedEventHandler(object sender, RoutedEventArgs e)
        {
            SelectedAssetChangedEventArgs arg = (SelectedAssetChangedEventArgs)e;
            (Content as MainView).ControlPanel.SelectedAsset = arg.Assets[0];          
            (Content as MainView).PresenterControl.Assets = arg.Assets;
            SelectedAssets = arg.Assets;
        }
    }
}
