using Appear.Core;
using Appear.Domain;
using Appear.Domain.Enum;
using Appear.Events;
using Appear.Services.Data;
using Appear.Services.Data.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Appear.Controls.Components.List
{
    public partial class ImageGrid : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<AssetCollection> assets;
        public ObservableCollection<AssetCollection> Assets
        {
            get { return assets; }
            set { assets = value; OnPropertyChanged(); }
        }

        private int columnCount { get; set; }
        public int ColumnCount
        {
            get { return columnCount; }
            set { columnCount = value; OnPropertyChanged(); }
        }

        private double viewWidth { get; set; }
        public double ViewWidth
        {
            get { return viewWidth; }
            set { viewWidth = value; OnPropertyChanged(); }
        }

        private DisplayWidth displayWidth { get; set; }
        public DisplayWidth DisplayWidth
        {
            get { return displayWidth; }
            set 
            { 
                displayWidth = value;
                ColumnCount = (int)Math.Floor(ViewWidth / DisplayWidth.ToDouble()); 
                OnPropertyChanged(); 
            }
        }

        public ImageGrid()
        {
            UpdateGrid();
            InitializeComponent();
        }

        public void SetWidth(Window window)
        {
            ViewWidth = window.Width - 500;
            DisplayWidth = SettingsManager.UserSettings().DisplayWidth;

            ObservableCollection<AssetCollection> temp = assets;
            Assets = new ObservableCollection<AssetCollection>();
            Assets = temp;
        }

        public void UpdateGrid()
        {
            Assets = new ObservableCollection<AssetCollection>(AssetManager.Get());
        }

        public static readonly RoutedEvent SelectionChangedEvent =
            EventManager.RegisterRoutedEvent("SelectionChanged", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ImageGrid));

        public event RoutedEventHandler SelectionChanged
        {
            add { AddHandler(SelectionChangedEvent, value); }
            remove { RemoveHandler(SelectionChangedEvent, value); }
        }

        public void OnAssetSelectionChanged(object sender, RoutedEventArgs e)
        {
            List<Asset> assets = new List<Asset>() { (sender as ListView).SelectedItem as Asset };
            RaiseEvent(new SelectedAssetChangedEventArgs(SelectionChangedEvent, assets));
        }

        public void OnAssetListSelectionChanged(object sender, RoutedEventArgs e)
        {
            AssetCollection collection = ((sender as ListView).SelectedItem as AssetCollection);
            if(collection != null && collection.Assets != null)
            {
                List<Asset> assets = collection.Assets.ToList();
                RaiseEvent(new SelectedAssetChangedEventArgs(SelectionChangedEvent, assets));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
