﻿using Appear.Controls;
using Appear.Events;
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
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Page
    {
        public MainViewModel vm { get; }

        public MainView()
        {
            vm = new MainViewModel();
            vm.DockPosition = Properties.Settings.Default.DockPositions;
            vm.HasAssets = Properties.Settings.Default.Assets != null 
                                && Properties.Settings.Default.Assets.Count > 0;

            InitializeComponent();

            DataContext = vm;
        }
    }
}
