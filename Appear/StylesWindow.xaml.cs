using Appear.Controls;
using Appear.Events;
using Appear.Services;
using Appear.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Appear
{
    /// <summary>
    /// Interaction logic for StylesWindow.xaml
    /// </summary>
    public partial class StylesWindow : Window
    {
        public StylesWindow()
        {
            Content = new StylesView();
            InitializeComponent();

            AddHandler(IconButton.IconButtonClickedEvent, new RoutedEventHandler(IconButtonClickedEventHandler));
            AddHandler(SelectionList.SelectionChangedEvent, new RoutedEventHandler(SelectionListChangedEventHandler));        
        }

        private void IconButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            IconButtonClickedEventArgs arg = (IconButtonClickedEventArgs)e;

            switch (arg.Action)
            {
                case "CloseStyles":
                    Close();
                    break;
                default:
                    break;
            }
        }

        public static readonly RoutedEvent EventRaisedEvent =
            EventManager.RegisterRoutedEvent("EventRaised", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(StylesWindow));

        public event RoutedEventHandler EventRaised
        {
            add { AddHandler(EventRaisedEvent, value); }
            remove { RemoveHandler(EventRaisedEvent, value); }
        }

        private void SelectionListChangedEventHandler(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedWindowEventArgs(EventRaisedEvent, e, "selectionChanged"));
        }
    }
}