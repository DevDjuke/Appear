using Appear.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private string dockPosition { get; set; }
        public string DockPosition
        {
            get { return dockPosition; }
            set { dockPosition = value; OnPropertyChanged(); }
        }
    }
}
