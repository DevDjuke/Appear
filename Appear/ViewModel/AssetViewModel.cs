using Appear.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.ViewModel
{
    public class AssetViewModel : ObservableObject
    {
        private ObservableCollection<string> assets { get; set; }
        public ObservableCollection<string> Assets
        {
            get { return assets; }
            set { assets = value; OnPropertyChanged(); }
        }
    }
}
