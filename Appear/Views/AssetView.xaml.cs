using Appear.Controls;
using Appear.Events;
using Appear.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Appear.Views
{
    /// <summary>
    /// Interaction logic for AssetView.xaml
    /// </summary>
    public partial class AssetView : Page
    {
        AssetViewModel vm;

        public AssetView()
        {
            vm = new AssetViewModel();
            if(Properties.Settings.Default.Assets != null)
            {
                vm.Assets = new ObservableCollection<string>(Properties.Settings.Default.Assets.Cast<string>().ToList());
            }
            else
            {
                vm.Assets = new ObservableCollection<string>();
            }

            InitializeComponent();

            DataContext = vm;

            AddHandler(FolderEntry.UpdateAssetsEvent, new RoutedEventHandler(UpdateAssetsEventHandler));
        }

        private void UpdateAssetsEventHandler(object sender, RoutedEventArgs e)
        {
            UpdateAssetsEventArgs args = (UpdateAssetsEventArgs)e;
            vm.Assets.Add(args.AssetPath);

            if(Properties.Settings.Default.Assets == null)
            {
                Properties.Settings.Default.Assets = new System.Collections.Specialized.StringCollection();
            }

            Properties.Settings.Default.Assets.Add(args.AssetPath.ToString());
            Properties.Settings.Default.Save(); 
        }
    }
}
