using Appear.Events;
using Appear.Services;
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

namespace Appear.Controls.Panels.AssetView
{
    /// <summary>
    /// Interaction logic for AssetList.xaml
    /// </summary>
    public partial class AssetFolderListPanel : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<string> assets { get; set; }
        public ObservableCollection<string> Assets
        {
            get { return assets; }
            set { assets = value; OnPropertyChanged(); }
        }

        public AssetFolderListPanel()
        {
            SetAssetList();
            InitializeComponent();
        }

        private void SetAssetList()
        {
            if (AssetManager.HasAssets())
            {
                Assets = new ObservableCollection<string>(Properties.Settings.Default.Assets.Cast<string>().ToList());
            }
            else
            {
                Assets = new ObservableCollection<string>();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void UpdateAssetsEventHandler()
        {
            SetAssetList();
        }
    }
}
