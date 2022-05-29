using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Appear.Events
{
    public class UpdateAssetsEventArgs : RoutedEventArgs
    {
        private string assetPath { get; set; }
        public string AssetPath
        {
            get { return assetPath; }
        }

        public UpdateAssetsEventArgs(RoutedEvent e, string path) : base(e)
        {
            assetPath = path;
        }
    }
}
