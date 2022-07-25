using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Appear.Services
{
    public static class StyleManager
    {
        private static WindowState currentState;
        private static WindowState previousState;

        private static Dictionary<string, Dictionary<string, Color>> themes = new Dictionary<string, Dictionary<string, Color>>()
        {
            {"Default", new Dictionary<string, Color>() {
                    { "Background", Color.FromRgb(0,56,68) },
                    { "Background_Bar", Color.FromRgb(0,56,68) },
                    { "Button_Base", Color.FromRgb(255,177,0) },
                    { "Button_HighLight", Color.FromRgb(255,235,198) },
                    { "ComboBoxNormalBorderBrush", Color.FromRgb(255,235,198) },
                    //{ "Button_HighLight", Color.FromRgb(241,148,180) },
                    //{ "Button_HighLight", Color.FromRgb(0,108,103) }
            } },
            {"Eggs", new Dictionary<string, Color>() {
                    { "Background", Color.FromRgb(176,158,153) },
                    { "Background_Bar", Color.FromRgb(176,158,153) },
                    { "Button_Base", Color.FromRgb(250,212,192) },
                    { "Button_HighLight", Color.FromRgb(254,233,225) },
                    { "ComboBoxNormalBorderBrush", Color.FromRgb(254,233,225) },
                        //{ "Button_HighLight", Color.FromRgb(100, 182, 172) },
                        //{ "Button_HighLight", Color.FromRgb(192, 253, 251) } }
            } },
            {"Nebula", new Dictionary<string, Color>() {
                    { "Button_HighLight", Color.FromRgb(218, 191, 255) },
                    { "ComboBoxNormalBorderBrush", Color.FromRgb(218, 191, 255) },
                    { "Button_Base", Color.FromRgb(144, 122, 214) },
                    //{ "Button_HighLight", Color.FromRgb(79, 81, 140) },
                    { "Background", Color.FromRgb(44, 42, 74) },
                    { "Background_Bar", Color.FromRgb(44, 42, 74) },
                //{ "Button_HighLight", Color.FromRgb(127, 222, 255) } }
            } },
            {"Sky", new Dictionary<string, Color>() {
                    { "Button_HighLight", Color.FromRgb(89, 149, 237) },
                    { "ComboBoxNormalBorderBrush", Color.FromRgb(89, 149, 237) },
                    { "Button_Base", Color.FromRgb(124, 175, 196) },
                    //{ "Button_HighLight", Color.FromRgb(255, 173, 5) },
                    { "Background", Color.FromRgb(4, 67, 137) },
                    { "Background_Bar", Color.FromRgb(4, 67, 137) },
                    //{ "Button_HighLight", Color.FromRgb(252, 255, 75) }
            } },
        };

        public static void SetPreferences(Window window)
        {
            if (Properties.Settings.Default.MaxOnStart)
            {
                currentState = WindowState.Normal;
                SetWindowState(window, "Maximize");
            }
            else
            {
                currentState = WindowState.Normal;
                previousState = WindowState.Normal;
            }

            UpdateStyle(currentState);
        }

        public static void SetWindowState(Window window, string state)
        {
            switch (state)
            {
                case "Maximize":
                    if(window.WindowState != WindowState.Maximized)
                    {
                        window.WindowState = WindowState.Maximized;
                        previousState = currentState;
                        currentState = window.WindowState;
                    }
                    UpdateStyle(currentState);
                    break;
                case "Restore":
                    window.WindowState = previousState;
                    previousState = currentState;
                    currentState = window.WindowState;
                    UpdateStyle(currentState);
                    break;
                case "Present":
                    window.WindowState = WindowState.Maximized;
                    break;
                case "StopPresenting":
                    window.WindowState = currentState;
                    break;
                default:
                    break;
            }
        }

        public static void SetTheme()
        {
            ApplyTheme(themes[Properties.Settings.Default["Styles"].ToString()]);
        }

        //public static void UpdateMenuBar()
        //{
        //    switch (Properties.Settings.Default["DockPositions"])
        //    {
        //        case "Top":
        //            App.Current.Resources["Corner_Bar"] = new CornerRadius(20, 20, 0, 0);
        //            break;
        //        case "Bottom":
        //            App.Current.Resources["Corner_Bar"] = new CornerRadius(0, 0, 20, 20);
        //            break;
        //        default:
        //            break;
        //    }

        public static void UpdateStyle()
        {
            StyleManager.UpdateStyle(currentState);
        }

        private static void UpdateStyle(WindowState state)
        {
            switch (state)
            {
                case WindowState.Maximized:
                    App.Current.Resources["Corner_Bar"] = new CornerRadius(0);
                    App.Current.Resources["Corner"] = new CornerRadius(0);
                    break;
                case WindowState.Normal:
                    App.Current.Resources["Corner"] = new CornerRadius(25);
                    switch (Properties.Settings.Default["DockPositions"])
                    {
                        case "Top":
                            App.Current.Resources["Corner_Bar"] = new CornerRadius(20, 20, 0, 0);
                            break;
                        case "Bottom":
                            App.Current.Resources["Corner_Bar"] = new CornerRadius(0, 0, 20, 20);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private static void ApplyTheme(Dictionary<string, Color> pairs)
        {
            foreach(var pair in pairs)
            {
                App.Current.Resources[pair.Key] = new SolidColorBrush(pair.Value);
            }
        }
    }
}
