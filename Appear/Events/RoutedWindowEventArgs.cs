using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Appear.Events
{
    public class RoutedWindowEventArgs : RoutedEventArgs
    {
        private RoutedEventArgs original { get; set; }
        public RoutedEventArgs Original
        {
            get { return original; }
            set { original = value; }
        }

        private string id { get; set; }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public RoutedWindowEventArgs(RoutedEvent e, RoutedEventArgs original, string id) : base(e)
        {
            this.original = original;
            this.id = id;
        }
    }
}
