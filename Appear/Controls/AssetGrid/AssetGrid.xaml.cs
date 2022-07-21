using Appear.Domain;
using Appear.Events;
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

namespace Appear.Controls.AssetGrid
{
    /// <summary>
    /// Interaction logic for AssetGrid.xaml
    /// </summary>
    public partial class AssetGrid : UserControl, INotifyPropertyChanged
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

        private double imagew { get; set; }
        public double Imagew
        {
            get { return imagew; }
            set { imagew = value; OnPropertyChanged(); }
        }

        public AssetGrid()
        {
            UpdateGrid();
            InitializeComponent();
        }

        public void SetWidth(Window window)
        {
            ViewWidth = window.Width - 500;
            Imagew = 100;
            ColumnCount = (int)Math.Floor(ViewWidth / Imagew);            

            ObservableCollection<AssetCollection> temp = assets;
            Assets = new ObservableCollection<AssetCollection>();
            Assets = temp;
        }

        public void UpdateGrid()
        {
            Assets = new ObservableCollection<AssetCollection>();
            foreach (string folder in Properties.Settings.Default.Assets)
            {
                AddToGrid(folder);
            }
        }

        public void AddToGrid(string folder)
        {
            string[] extensions = { ".png", ".jpg" };

            AssetCollection collection = new AssetCollection();
            collection.Path = folder;
            collection.Assets = new ObservableCollection<Asset>();

            foreach (string path in Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories)
                    .Where(s => extensions.Any(ext => ext == Path.GetExtension(s))))
            {
                collection.Assets.Add(new Asset
                {
                    Path = path,
                    Name = path.Split('\\').Last()
                });
            }

            Assets.Add(collection);
        }

        public static readonly RoutedEvent SelectionChangedEvent =
            EventManager.RegisterRoutedEvent("SelectionChanged", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(AssetGrid));

        public event RoutedEventHandler SelectionChanged
        {
            add { AddHandler(SelectionChangedEvent, value); }
            remove { RemoveHandler(SelectionChangedEvent, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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
    }
}
