using Appear.Controls;
using Appear.Controls.AssetGrid;
using Appear.Controls.Control;
using Appear.Controls.Present;
using Appear.Core;
using Appear.Events;
using Appear.Services;
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

namespace Appear.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : ObservablePage
    {
        public ControlPanel ControlPanel
        {
            get
            {
                return this.GetChildOfType<ControlPanel>();
            }
        }
        public AssetGrid AssetGrid
        {
            get
            {
                return this.GetChildOfType<AssetGrid>();
            }
        }
        public PresenterControl PresenterControl
        {
            get
            {
                return this.GetChildOfType<PresenterControl>();
            }
        }

        private string dockPosition { get; set; }
        public string DockPosition
        {
            get { return dockPosition; }
            set { dockPosition = value; OnPropertyChanged(); }
        }

        private bool hasAssets { get; set; }
        public bool HasAssets
        {
            get { return hasAssets; }
            set { hasAssets = value; OnPropertyChanged(); }
        }

        private bool isPresenting { get; set; }
        public bool IsPresenting
        {
            get { return isPresenting; }
            set { isPresenting = value; OnPropertyChanged(); }
        }

        public MainView()
        {
            DockPosition = Properties.Settings.Default.DockPositions;
            HasAssets = AssetManager.HasAssets();
            IsPresenting = false;

            InitializeComponent();
        }
    }
}
