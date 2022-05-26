using Appear.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.ViewModel.Controls
{
    public class IconButtonViewModel : ObservableObject
    {
        private string action { get; set; }
        public string Action
        {
            get { return action; }
            set { action = value; OnPropertyChanged(); }
        }

        private string icon { get; set; }
        public string Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                OnPropertyChanged();
            }
        }
    }
}
