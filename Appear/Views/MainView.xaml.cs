using Appear.Controls;
using Appear.Controls.Components.List;
using Appear.Controls.Panels.MainView;
using Appear.Core;
using Appear.Events;
using Appear.Services;
using Appear.Services.Data.Domain;
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
        public ImageGrid AssetGrid
        {
            get
            {
                return this.GetChildOfType<ImageGrid>();
            }
        }
        public PresenterControlPanel PresenterControl
        {
            get
            {
                return this.GetChildOfType<PresenterControlPanel>();
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
            DockPosition = StyleManager.GetUserSettings().DockPosition.ToString();
            HasAssets = AssetManager.HasAssets();
            IsPresenting = false;

            InitializeComponent();
        }
    }
}
