﻿using Appear.Controls;
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
        public event EventHandler ThemeChanged;
        protected void OnThemeChanged()
        {
            if(ThemeChanged != null)
            {
                ThemeChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler MenuBarChanged;
        protected void OnMenuBarChanged()
        {
            if (MenuBarChanged != null)
            {
                MenuBarChanged(this, EventArgs.Empty);
            }
        }

        public StylesWindow()
        {
            Content = new StylesView();
            InitializeComponent();

            AddHandler(IconButton.IconButtonClickedEvent, new RoutedEventHandler(IconButtonClickedEventHandler));
            AddHandler(SelectionList.SelectionChangedEvent, new RoutedEventHandler(SelectionChangedEventHandler));
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

        private void SelectionChangedEventHandler(object sender, RoutedEventArgs e)
        {
            SelectionListChangedEventArgs arg = (SelectionListChangedEventArgs)e;

            switch (arg.Id)
            {
                case "Styles":
                    this.OnThemeChanged();
                    break;
                case "DockPositions":
                    this.OnMenuBarChanged();
                    break;
                default:
                    break;
            }
                
        }
    }
}