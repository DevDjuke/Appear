using Appear.Controls.Control;
using Appear.Core;
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
    /// Interaction logic for PresentView.xaml
    /// </summary>
    public partial class PresentView : Page
    {
        public PresentViewModel vm;
        public PicturePreview PicturePreview
        {
            get
            {
                return this.GetChildOfType<PicturePreview>();
            }
        }

        public PresentView()
        {
            vm = new PresentViewModel();
            InitializeComponent();
            DataContext = vm;
        }
    }
}
