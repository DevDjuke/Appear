using Appear.Domain;
using System;
using System.Collections.Generic;
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

namespace Appear.Controls.Present
{
    /// <summary>
    /// Interaction logic for PresenterControl.xaml
    /// </summary>
    public partial class PresenterControl : UserControl, INotifyPropertyChanged
    {
        private string path;
        public string Path
        {
            get { return path; }
            set { path = value; OnPropertyChanged(); }
        }

        private double imageHeight;
        public double ImageHeight
        {
            get { return imageHeight; }
            set { imageHeight = value; OnPropertyChanged(); }
        }

        private double imageWidth;
        public double ImageWidth
        {
            get { return imageWidth; }
            set { imageWidth = value; OnPropertyChanged(); }
        }

        private List<Asset> assets;
        public List<Asset> Assets
        {
            get { return assets; }
            set { 
                assets = value;
                OnPropertyChanged();
                Path = assets[selectedIndex].Path;
            }
        }

        private int selectedIndex = 0;

        public PresenterControl()
        {
            InitializeComponent();
        }

        public void SetDimensions(Window window)
        {
            ImageHeight = window.Height;
            ImageWidth = window.Width;
        }

        public void SetAssets(List<Asset> assets)
        {
            Assets = assets;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void Next()
        {
            selectedIndex = selectedIndex < assets.Count-1 ? selectedIndex+1 : 0;
            Path = assets[selectedIndex].Path;
        }

        public void Previous()
        {
            selectedIndex = selectedIndex > 0 ? selectedIndex - 1 : assets.Count - 1;
            Path = assets[selectedIndex].Path;
        }
    }
}
