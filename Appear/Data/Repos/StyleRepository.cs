using Appear.Data.DO;
using Appear.Data.DTO;
using Appear.Domain;
using Appear.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Appear.Data.Repos
{
    public static class StyleRepository
    {
        public static Style GetCurrentStyle()
        {
            Style result = null;
            StyleDTO style = null;

            using (var db = new AppearContext())
            {
                UserSettingsDTO settings = db.UserSettings.FirstOrDefault();

                if (settings != null)
                {
                    style = db.Styles.Where(x => x.Id == settings.StyleId).SingleOrDefault();
                }
                else
                {
                    style = db.Styles.Where(x => x.Name == "Default").SingleOrDefault();
                }
            }

            if (style != null)
            {
                result = style.ToStyle();
            }

            return result;
        }

        public static List<Style> GetAll()
        {
            List<Style> result = new List<Style>();
            List<StyleDTO> styles = null;

            using (var db = new AppearContext())
            {
                styles = db.Styles.ToList();
            }

            foreach (var style in styles)
            {
                result.Add(style.ToStyle());
            }

            return result;
        }

        public static Style GetStyleByName(string name)
        {
            Style result = null;
            StyleDTO style = null;

            using(var db = new AppearContext())
            {
                style = db.Styles.Where(x => x.Name.Equals(name)).SingleOrDefault();
            }

            if(style != null)
            {
                result=style.ToStyle();
            }

            return result;
        }

        private static Style ToStyle(this StyleDTO dto)
        {
            using (var db = new AppearContext())
            {
                return new Style()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    BackgroundColor = new Tuple<string, Color>(
                        "Background", ColorDTOToColor(db.Colors.Where(x => x.Id == dto.BG_ColorId).SingleOrDefault())),
                    BarBackgroundColor = new Tuple<string, Color>(
                        "Background_Bar", ColorDTOToColor(db.Colors.Where(x => x.Id == dto.Bar_ColorId).SingleOrDefault())),
                    ButtonColor = new Tuple<string, Color>(
                        "Button_Base", ColorDTOToColor(db.Colors.Where(x => x.Id == dto.Button_ColorId).SingleOrDefault())),
                    ButtonHighLighColor = new Tuple<string, Color>(
                        "Button_HighLight", ColorDTOToColor(db.Colors.Where(x => x.Id == dto.Button_HL_ColorId).SingleOrDefault())),
                    ComboBoxColor = new Tuple<string, Color>(
                        "ComboBoxNormalBorderBrush", ColorDTOToColor(db.Colors.Where(x => x.Id == dto.CBBox_ColorId).SingleOrDefault())),
                };
            }
        }

        private static Color ColorDTOToColor(ColorDTO dto)
        {
            return Color.FromRgb((byte)dto.R, (byte)dto.G, (byte)dto.B);
        }
    }
}
