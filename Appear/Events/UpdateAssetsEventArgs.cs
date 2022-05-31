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

        private ActionType action { get; set; }
        public ActionType Action
        {
            get { return action; }
        }

        public UpdateAssetsEventArgs(RoutedEvent e, string path, ActionType action) : base(e)
        {
            assetPath = path;
            this.action = action;
        }

        public enum ActionType
        {
            ADD,
            REMOVE
        }
    }
}
