using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appear.Domain
{
    [Table("mediatypes")]

    public class MediaType
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public ICollection<FileType> FileTypes { get; set; }
    }
}
