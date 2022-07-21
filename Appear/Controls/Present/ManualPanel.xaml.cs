using Appear.Domain;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Appear.Controls.Present
{
    /// <summary>
    /// Interaction logic for ManualPanel.xaml
    /// </summary>
    public partial class ManualPanel : UserControl
    {
        public ManualPanel()
        {
            InitializeComponent();
        }

        public Asset[] Assets
        {
            get { return (Asset[])GetValue(AssetsProperty); }
            set
            {
                SetValue(AssetsProperty, value);
            }
        }

        public static readonly DependencyProperty AssetsProperty =
           DependencyProperty.Register(
           "Assets",
           typeof(Asset[]),
           typeof(ManualPanel),
           new UIPropertyMetadata(new Asset[3])
       );
    }
}
