using Appear.Controls;
using Appear.Controls.AssetList;
using Appear.Controls.Buttons;
using Appear.Events;
using Appear.Services;
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
using System.Windows.Shapes;

namespace Appear
{
    /// <summary>
    /// Interaction logic for AssetWindow.xaml
    /// </summary>
    public partial class AssetWindow : Window
    {
        public event EventHandler AssetListChanged;
        protected void OnAssetListChanged()
        {
            if (AssetListChanged != null)
            {
                AssetListChanged(this, EventArgs.Empty);
            }
        }

        public AssetWindow()
        {
            Content = new AssetView();

            InitializeComponent();

            AddHandler(IconButton.IconButtonClickedEvent, new RoutedEventHandler(IconButtonClickedEventHandler));
            AddHandler(FolderEntry.UpdateAssetsEvent, new RoutedEventHandler(UpdateAssetsEventHandler));
            AddHandler(AssetListItem.RemoveAssetEvent, new RoutedEventHandler(UpdateAssetsEventHandler));
        }

        private void IconButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            IconButtonClickedEventArgs arg = (IconButtonClickedEventArgs)e;

            switch (arg.Action)
            {
                case "CloseDialog":
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void UpdateAssetsEventHandler(object sender, RoutedEventArgs e)
        {
            UpdateAssetsEventArgs args = (UpdateAssetsEventArgs)e;
            if (args.Action == UpdateAssetsEventArgs.ActionType.ADD)
            {
                AssetManager.AddAsset(args.AssetPath.ToString());
            }
            else if (args.Action == UpdateAssetsEventArgs.ActionType.REMOVE)
            {
                AssetManager.RemoveAsset(args.AssetPath.ToString());
            }

            (Content as AssetView).AssetList.UpdateAssetsEventHandler();

            this.OnAssetListChanged();
        }
    }
}
