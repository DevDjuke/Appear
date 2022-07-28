using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appear.Domain
{
    [Table("fileTypes")]

    public class FileType
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("extension")]
        public string Extension { get; set; }

        [Column("mediaTypeId")]
        public int MediaTypeId { get; set; }

        [ForeignKey("MediaTypeId")]
        public MediaType MediaType { get; set; }

        public ICollection<Asset> Assets { get; set; }
    }
}
