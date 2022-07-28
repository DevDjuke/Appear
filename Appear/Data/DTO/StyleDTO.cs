using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.DTO
{
    [Table("styles")]
    public class StyleDTO
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("backgroundcolorId")]
        public int BG_ColorId { get; set; }

        [Column("barcolorId")]
        public int Bar_ColorId { get; set; }

        [Column("buttoncolorId")]
        public int Button_ColorId { get; set; }

        [Column("buttonhighlightcolorId")]
        public int Button_HL_ColorId { get; set; }

        [Column("comboboxcolorId")]
        public int CBBox_ColorId { get; set; }
    }
}
