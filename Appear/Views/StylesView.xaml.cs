using Appear.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for StylesView.xaml
    /// </summary>
    public partial class StylesView : ObservablePage
    {
        private bool maxOnStartUp { get; set; } = Properties.Settings.Default.MaxOnStart;
        public bool MaxOnStartUp
        {
            get { return maxOnStartUp; }
            set { maxOnStartUp = value; OnPropertyChanged(); }
        }

        private bool updateOnStartUp { get; set; } = Properties.Settings.Default.UpdateOnStart;
        public bool UpdateOnStartUp
        {
            get { return updateOnStartUp; }
            set { updateOnStartUp = value; OnPropertyChanged(); }
        }

        public StylesView()
        {
            InitializeComponent();
        }
    }
}
