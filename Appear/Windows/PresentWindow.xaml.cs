﻿using Appear.Controls;
using Appear.Controls.Buttons;
using Appear.Controls.Present;
using Appear.Domain;
using Appear.Events;
using Appear.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Appear.Windows
{
    /// <summary>
    /// Interaction logic for PresentWindow.xaml
    /// </summary>
    public partial class PresentWindow : Window
    {
        public Asset selectedAsset;

        public event EventHandler NextAsset;
        protected void OnNextAsset()
        {
            if (NextAsset != null)
            {
                NextAsset(this, EventArgs.Empty);
                (Content as PresentView).PicturePreview.NextPreview();
            }
        }

        public event EventHandler PreviousAsset;
        protected void OnPreviousAsset()
        {
            if (PreviousAsset != null)
            {
                PreviousAsset(this, EventArgs.Empty);
                (Content as PresentView).PicturePreview.PreviousPreview();
            }
        }

        public event EventHandler SelectedAsset;
        protected void OnSelectedAsset()
        {
            if (SelectedAsset != null)
            {
                SelectedAsset(this, EventArgs.Empty);
                (Content as PresentView).PicturePreview.SelectedAsset(selectedAsset);
            }
        }

        public PresentWindow(List<Asset> assets)
        {
            Content = new PresentView(assets);
            InitializeComponent();

            AddHandler(IconButton.IconButtonClickedEvent, new RoutedEventHandler(IconButtonClickedEventHandler));
            AddHandler(TextButton.TextButtonClickedEvent, new RoutedEventHandler(TextButtonClickedEventHandler));
            AddHandler(AutoPanel.TimerTickEvent, new RoutedEventHandler(TimerTickEventHandler));
            AddHandler(ManualPanel.SelectionChangedEvent, new RoutedEventHandler(AssetSelectionChangedEventHandler));
            AddHandler(SelectionList.SelectionChangedEvent, new RoutedEventHandler(SelectionChangedEventHandler));
        }

        private void IconButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            IconButtonClickedEventArgs arg = (IconButtonClickedEventArgs)e;

            switch (arg.Action)
            {
                case "NextAsset":
                    OnNextAsset();
                    break;
                case "PreviousAsset":
                    OnPreviousAsset();
                    break;
                case "CloseDialog":
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
                case "SelectedAsset":
                    OnSelectedAsset();
                    break;
                default:
                    break;
            }
        }

        private void AssetSelectionChangedEventHandler(object sender, RoutedEventArgs e)
        {
            SelectedAssetChangedEventArgs arg = (SelectedAssetChangedEventArgs)e;
            selectedAsset = arg.Assets[0];
        }

        private void TimerTickEventHandler(object sender, RoutedEventArgs e)
        {
            this.OnNextAsset();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (IsEnabled)
            {
                base.OnMouseLeftButtonDown(e);
                DragMove();
            }
        }

        private void SelectionChangedEventHandler(object sender, RoutedEventArgs e)
        {
            SelectionListChangedEventArgs arg = (SelectionListChangedEventArgs)e;

            switch (arg.Id)
            {
                case "Modes":
                    this.OnModeChanged(arg.Value);
                    break;
                default:
                    break;
            }
        }

        private void OnModeChanged(string value)
        {
            switch (value)
            {
                case "MANUAL":
                    (Content as PresentView).IsManualMode = true;
                    break;
                case "AUTO PLAY":
                    (Content as PresentView).IsManualMode = false;
                    break;
                default: break;
            }
        }
    }
}
