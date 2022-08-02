using Appear.Services.Data.Domain;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Appear.Controls.Panels.AssetView
{
    public partial class AssetFolderListPanel : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<string> folders { get; set; }
        public ObservableCollection<string> Folders
        {
            get { return folders; }
            set { folders = value; OnPropertyChanged(); }
        }

        public AssetFolderListPanel()
        {
            SetFolderList();
            InitializeComponent();
        }

        private void SetFolderList()
        {
            if (FolderManager.HasFolders())
            {
                Folders = new ObservableCollection<string>(FolderManager.GetFolderPaths());
            }
            else
            {
                Folders = new ObservableCollection<string>();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void UpdateFoldersventHandler()
        {
            SetFolderList();
        }
    }
}