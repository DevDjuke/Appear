using Appear.Controls.Control;
using Appear.Controls.Present;
using Appear.Core;
using Appear.Domain;
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

namespace Appear.Views
{
    /// <summary>
    /// Interaction logic for PresentView.xaml
    /// </summary>
    public partial class PresentView: ObservablePage
    {
        private ObservableCollection<Asset> assets { get; set; }
        public ObservableCollection<Asset> Assets
        {
            get { return assets; }
            set { assets = value; OnPropertyChanged(); }
        }

        private bool isManualMode { get; set; } = true;
        public bool IsManualMode
        {
            get { return isManualMode; }
            set { isManualMode = value; OnPropertyChanged(); }
        }

        public PicturePreview PicturePreview
        {
            get
            {
                return this.GetChildOfType<PicturePreview>();
            }
        }

        public PresentView(List<Asset> assets)
        {
            Assets = new ObservableCollection<Asset>(assets);
            InitializeComponent();
        }
    }
}
