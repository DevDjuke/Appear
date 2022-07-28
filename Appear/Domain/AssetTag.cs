using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appear.Domain
{
    [Table("assettags")]
    public class AssetTag
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("tagId")]
        public int TagId { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }

        [Column("assetId")]
        public int AssetId { get; set; }

        [ForeignKey("AssetId")]
        public Asset Asset { get; set; }
    }
}
