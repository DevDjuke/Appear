using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Domain
{
    [Table("tags")]
    public class Tag
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public ICollection<AssetTag> AssetTags { get; set; }

    }
}
