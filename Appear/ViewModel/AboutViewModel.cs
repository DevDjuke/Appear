using Appear.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.ViewModel
{
    public class AboutViewModel : ObservableObject
    {
        private string version { get; set; }
        public string Version
        {
            get { return version; }
            set { version = value; OnPropertyChanged(); }
        }
    }
}
