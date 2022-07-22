﻿using Appear.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Appear.Controls.Present
{
    /// <summary>
    /// Interaction logic for AutoPanel.xaml
    /// </summary>
    public partial class AutoPanel : System.Windows.Controls.UserControl, INotifyPropertyChanged
    {
        private Timer timer;
        private string time { get; set; } = "8";
        public string Time
        {
            get { return time; }
            set { time = value; OnPropertyChanged(); }
        }

        private bool isPlaying { get; set; } = false;
        public bool IsPlaying
        {
            get { return isPlaying; }
            set { isPlaying = value; OnPropertyChanged(); }
        }

        public AutoPanel()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(onTimerTick);
            timer.Interval = 1000;

            InitializeComponent();

        }

        public static readonly RoutedEvent TimerTickEvent =
            EventManager.RegisterRoutedEvent("IconButtonClicked", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(AutoPanel));

        public event RoutedEventHandler TimerTick
        {
            add { AddHandler(TimerTickEvent, value); }
            remove { RemoveHandler(TimerTickEvent, value); }
        }

        private void onTimerTick(object sender, EventArgs e)
        {
            int value = Int32.Parse(Time);
            value--;

            if(value <= 0)
            {
                value = 8;
                RaiseEvent(new TimerTickEventArgs(TimerTickEvent));
            }

            Time = value.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void Timer(bool start)
        {
            if (start)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
                IsPlaying = false;
                Time = "8";
            }
        }
    }
}
