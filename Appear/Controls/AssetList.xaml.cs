using Appear.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Appear.Controls
{
    /// <summary>
    /// Interaction logic for AssetList.xaml
    /// </summary>
    public partial class AssetList : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<string> assets { get; set; }
        public ObservableCollection<string> Assets
        {
            get { return assets; }
            set { assets = value; OnPropertyChanged(); }
        }

        public AssetList()
        {
            if (Properties.Settings.Default.Assets != null)
            {
                Assets = new ObservableCollection<string>(Properties.Settings.Default.Assets.Cast<string>().ToList());
            }
            else
            {
                Assets = new ObservableCollection<string>();
            }

            InitializeComponent();
            AddHandler(FolderEntry.UpdateAssetsEvent, new RoutedEventHandler(UpdateAssetsEventHandler));
            AddHandler(AssetListItem.RemoveAssetEvent, new RoutedEventHandler(UpdateAssetsEventHandler));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static readonly RoutedEvent AssetListChangedEvent =
            EventManager.RegisterRoutedEvent("AssetListChanged", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(AssetList));

        public event RoutedEventHandler SelectionChanged
        {
            add { AddHandler(AssetListChangedEvent, value); }
            remove { RemoveHandler(AssetListChangedEvent, value); }
        }

        private void UpdateAssetsEventHandler(object sender, RoutedEventArgs e)
        {
            UpdateAssetsEventArgs args = (UpdateAssetsEventArgs)e;

            if (args.Action == UpdateAssetsEventArgs.ActionType.ADD)
            {
                Assets.Add(args.AssetPath);

                if (Properties.Settings.Default.Assets == null)
                {
                    Properties.Settings.Default.Assets = new System.Collections.Specialized.StringCollection();
                }

            }
            else if (args.Action == UpdateAssetsEventArgs.ActionType.REMOVE)
            {
                Assets.Remove(args.AssetPath);
                Properties.Settings.Default.Assets.Remove(args.AssetPath.ToString());
            }

            Properties.Settings.Default.Save();

            RaiseEvent(new RoutedEventArgs(AssetListChangedEvent, this));
        }
    }
}
