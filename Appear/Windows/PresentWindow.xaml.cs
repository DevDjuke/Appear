using Appear.Controls.Buttons;
using Appear.Events;
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

namespace Appear.Windows
{
    /// <summary>
    /// Interaction logic for PresentWindow.xaml
    /// </summary>
    public partial class PresentWindow : Window
    {
        public event EventHandler NextAsset;
        protected void OnNextAsset()
        {
            if (NextAsset != null)
            {
                NextAsset(this, EventArgs.Empty);
            }
        }

        public event EventHandler PreviousAsset;
        protected void OnPreviousAsset()
        {
            if (PreviousAsset != null)
            {
                PreviousAsset(this, EventArgs.Empty);
            }
        }

        public PresentWindow()
        {
            Content = new PresentView();
            InitializeComponent();

            AddHandler(IconButton.IconButtonClickedEvent, new RoutedEventHandler(IconButtonClickedEventHandler));
            AddHandler(TextButton.TextButtonClickedEvent, new RoutedEventHandler(TextButtonClickedEventHandler));
        }

        private void IconButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            IconButtonClickedEventArgs arg = (IconButtonClickedEventArgs)e;

            switch (arg.Action)
            {
                case "CloseDialog":
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void TextButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            TextButtonClickedEventArgs arg = (TextButtonClickedEventArgs)e;
            
            switch (arg.Action)
            {
                case "NextAsset":
                    this.OnNextAsset();
                    break;
                case "PreviousAsset":
                    this.OnPreviousAsset();
                    break;
                default:
                    break;
            }
        }


        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (IsEnabled)
            {
                base.OnMouseLeftButtonDown(e);
                DragMove();
            }
        }
    }
}
