using Appear.Data.Repos;
using Appear.Domain.Enum;
using Appear.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Services.Data
{
    public static class SettingsManager
    {
        private static UserSettings userSettings;
        public static PresentMode DefaultPresentMode
        {
            get { return PresentMode.Manual; }
        }

        public static UserSettings UserSettings()
        {
            if(userSettings == null)
            {
                userSettings = UserSettingRepository.GetUserSettings();
            }

            return userSettings;
        }

        public static void SetStyle(int styleId)
        {
            var settings = UserSettings();
            settings.StyleId = styleId;
            UserSettingRepository.Update(settings);
        }

        public static void SetMaxOnStart(bool value)
        {
            var settings = UserSettings();
            settings.MaximizeOnStart = value;
            UserSettingRepository.Update(settings);
        }

        public static void SetUpdateOnStart(bool value)
        {
            var settings = UserSettings();
            settings.UpdateOnStart = value;
            UserSettingRepository.Update(settings);
        }

        public static void SetDockPosition(DockPosition position)
        {
            var settings = UserSettings();
            settings.DockPosition = position;
            UserSettingRepository.Update(settings);
        }

        public static string GetSettingByValue(string value)
        {
            UserSettings settings = UserSettings();

            switch (value)
            {
                case "DockPositions":
                    return Enum.GetName(typeof(DockPosition), settings.DockPosition);
                case "Modes":
                    return Enum.GetName(typeof(PresentMode), SettingsManager.DefaultPresentMode);
                case "Styles":
                    return StyleRepository.GetCurrentStyle().Name;
                default: return "";
            }
        }

        public static string GetSettingByProperty(string prop)
        {
            UserSettings settings = UserSettings();

            switch (prop)
            {
                case "DockPosition":
                    return Enum.GetName(typeof(DockPosition), settings.DockPosition);
                case "PresentMode":
                    return SettingsManager.DefaultPresentMode.ToString();
                default: return "";
            }
        }
    }
}
