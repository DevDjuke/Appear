using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Appear.Events
{
    public class SelectedAssetChangedEventArgs: RoutedEventArgs
    {
        private Asset asset { get; set; }
        public Asset Asset 
        { 
            get { return asset; } 
            set { asset = value; }
        }

        public SelectedAssetChangedEventArgs(RoutedEvent e, Asset asset) : base(e)
        {
            this.asset = asset;
        }
    }
}
