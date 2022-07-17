using Appear.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.ViewModel
{
    public class DialogViewModel : ObservableObject
    {
        private string text { get; set; }
        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged(); }
        }
    }
}
