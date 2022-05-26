using Appear.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.ViewModel.Controls
{
    public class TextButtonViewModel : ObservableObject
    {
        private string action { get; set; }
        public string Action 
        { 
            get { return action; }
            set { action = value; OnPropertyChanged(); }
        }

        private string text { get; set; }
        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged(); }
        }

        private string size { get; set; }
        public string Size
        {
            get { return size; }
            set { size = value; OnPropertyChanged(); }
        }
    }
}
