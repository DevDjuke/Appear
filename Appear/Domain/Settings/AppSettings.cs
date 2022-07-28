using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Domain.Settings
{
    [Table("appsettings")]
    public class AppSettings
    {
        [Key]
        [Column("version")]
        public string Version { get; set; }

        [Column("release")]
        public string Release { get; set; }
    }
}
