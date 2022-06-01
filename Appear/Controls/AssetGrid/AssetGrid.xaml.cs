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

        public AssetGrid()
        {
            UpdateGrid();

            InitializeComponent();
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

        public void OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new SelectedAssetChangedEventArgs(SelectionChangedEvent, (sender as ListView).SelectedItem as Asset));
        }
    }
}
