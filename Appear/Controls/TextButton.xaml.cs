﻿using Appear.Events;
using Appear.ViewModel.Controls;
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

namespace Appear.Controls
{
    public partial class TextButton : UserControl
    {
        TextButtonViewModel vm;

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string Action
        {
            get { return (string)GetValue(ActionProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string Size
        {
            get { return (string)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
            "Text",
            typeof(string),
            typeof(TextButton),
            new UIPropertyMetadata(TextPropertyChangedHandler)
        );

        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register(
                "Size",
                typeof(string),
                typeof(TextButton),
                new UIPropertyMetadata(SizePropertyChangedHandler)
        );

        public static readonly DependencyProperty ActionProperty =
            DependencyProperty.Register(
                "Action",
                typeof(string),
                typeof(TextButton),
                new UIPropertyMetadata(ActionPropertyChangedHandler)
        );

        public static void TextPropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ((TextButton)sender).vm.Text = e.NewValue.ToString();
        }

        public static void SizePropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ((TextButton)sender).vm.Size = e.NewValue.ToString();
        }

        public static void ActionPropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ((TextButton)sender).vm.Action = e.NewValue.ToString();
        }

        public TextButton()
        {
            vm = new TextButtonViewModel();
            InitializeComponent();
            DataContext = vm;
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new TextButtonClickedEventArgs(TextButtonClickedEvent, vm.Action));
        }

        public static readonly RoutedEvent TextButtonClickedEvent =
            EventManager.RegisterRoutedEvent("TextButtonClicked", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(TextButton));

        public event RoutedEventHandler TextButtonClickedEventHandler
        {
            add { AddHandler(TextButtonClickedEvent, value); }
            remove { RemoveHandler(TextButtonClickedEvent, value); }
        }
    }
}
