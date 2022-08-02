using Appear.Data.DO;
using Appear.Domain.Enum;
using Appear.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.Repos
{
    public static class UserSettingRepository
    {
        public static UserSettings GetUserSettings()
        {
            UserSettings result = null;
            UserSettingsDTO settings = null;

            using (var db = new AppearContext())
            {
                settings = db.UserSettings.FirstOrDefault();
            }

            if(settings != null)
            {
                result = settings.ToUserSettings();
            }

            return result;
        }

        public static void Update(UserSettings settings)
        {
            UserSettingsDTO dto = settings.ToDTO();

            using (var db = new AppearContext())
            {
                var rec = db.UserSettings.Single(x => x.Id == settings.Id);
                rec.UpdateOnStart = dto.UpdateOnStart;
                rec.DockPosition = dto.DockPosition;
                rec.MaximizeOnStart = dto.MaximizeOnStart;
                rec.StyleId = dto.StyleId;
                db.SaveChanges();
            }
        }

        private static UserSettings ToUserSettings(this UserSettingsDTO dto)
        {
            return new UserSettings()
            {
                DockPosition = (DockPosition)Enum.Parse(typeof(DockPosition), dto.DockPosition),
                DisplayWidth = (DisplayWidth)Enum.Parse(typeof(DisplayWidth), dto.DisplayWidth),
                Id = dto.Id,
                MaximizeOnStart = Convert.ToBoolean(dto.MaximizeOnStart),
                UpdateOnStart = Convert.ToBoolean(dto.UpdateOnStart),
                StyleId = dto.StyleId,
            };
        }

        private static UserSettingsDTO ToDTO(this UserSettings settings)
        {
            return new UserSettingsDTO()
            {
                Id = settings.Id,
                DockPosition = Enum.GetName(typeof(DockPosition), settings.DockPosition),
                DisplayWidth = Enum.GetName(typeof(DisplayWidth), settings.DisplayWidth),
                StyleId = settings.StyleId,
                MaximizeOnStart = Convert.ToInt32(settings.MaximizeOnStart),
                UpdateOnStart = Convert.ToInt32(settings.UpdateOnStart),
            };
        } 
    }
}
