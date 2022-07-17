using Appear.ViewModel;
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

namespace Appear.Views
{
    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    public partial class AboutView : Page
    {
        AboutViewModel vm;

        public AboutView()
        {
            vm = new AboutViewModel();

            vm.Version = $"v {Properties.Settings.Default.Release} - {Properties.Settings.Default.Name}";

            InitializeComponent();

            DataContext = vm;
        }
    }
}
