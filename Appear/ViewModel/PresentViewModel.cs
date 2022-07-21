using Appear.Core;
using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.ViewModel
{
    public class PresentViewModel : ObservableObject
    {
        public Asset[] Assets { get; set; }
    }
}
