using Appear.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Appear.Events
{
    public class IconButtonClickedEventArgs : RoutedEventArgs
    {
        private IconButtonAction action;
        public IconButtonAction Action { get { return action; } }

        public IconButtonClickedEventArgs(RoutedEvent e, IconButtonAction action) : base(e)
        {
            this.action = action;
        }
    }
}
