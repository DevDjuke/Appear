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

namespace Appear.Controls.Control
{
    /// <summary>
    /// Interaction logic for PicturePreview.xaml
    /// </summary>
    public partial class PicturePreview : UserControl, INotifyPropertyChanged
    {
        private int previewIndex = 0;

        private string previousPath { get; set; }
        private string currentPath { get; set; }
        private string nextPath { get; set; }

        public string PreviousPath
        {
            get { return previousPath; }
            set { previousPath = value; OnPropertyChanged(); }
        }

        public string CurrentPath
        {
            get { return currentPath; }
            set { currentPath = value; OnPropertyChanged(); }
        }

        public string NextPath
        {
            get { return nextPath; }
            set { nextPath = value; OnPropertyChanged(); }
        }

        public Asset[] Assets
        {
            get { return (Asset[])GetValue(AssetsProperty); }
            set 
            { 
                SetValue(AssetsProperty, value);
                UpdatePreviews();
            }
        }

        public void NextPreview()
        {
            UpdateIndex(1);
            UpdatePreviews();
        }

        public void PreviousPreview()
        {
            UpdateIndex(-1);
            UpdatePreviews();
        }

        public static readonly DependencyProperty AssetsProperty =
            DependencyProperty.Register(
            "Assets",
            typeof(Asset[]),
            typeof(PicturePreview),
            new UIPropertyMetadata(new Asset[3])
        );

        //public static void AssetPropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        //{
        //}

        public PicturePreview()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void UpdateIndex(int dir)
        {
            previewIndex += dir;
            if(previewIndex > Assets.Length - 1)
            {
                previewIndex = 0;
            }
            else if(previewIndex < 0)
            {
                previewIndex = Assets.Length - 1;
            }
        }

        private void UpdatePreviews()
        {
            CurrentPath = Assets[previewIndex].Path;
            NextPath = GetNextPath();
            PreviousPath = GetPreviousPath();
        }

        private string GetNextPath()
        {
            string value = "";

            if(Assets != null && Assets.Length > 1)
            {
                if(previewIndex == Assets.Length - 1)
                {
                    value = Assets[0].Path;
                }
                else
                {
                    value = Assets[previewIndex+1].Path;
                }
            }

            return value;
        }

        private string GetPreviousPath()
        {
            string value = "";

            if(Assets != null  && Assets.Length > 1)
            {
                if(previewIndex == 0)
                {
                    value = Assets[Assets.Length - 1].Path;
                }
                else
                {
                    value = Assets[previewIndex -1].Path;
                }
            }

            return value;
        }
    }
}
