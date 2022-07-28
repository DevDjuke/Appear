using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.DO
{
    [Table("usersettings")]
    public class UserSettingsDTO
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("dockposition")]
        public string DockPosition { get; set; }

        [Column("maxonstart")]
        public int MaximizeOnStart { get; set; }

        [Column("updateonstart")]
        public int UpdateOnStart { get; set; }

        [Column("styleId")]
        public int StyleId { get; set; }
    }
}
