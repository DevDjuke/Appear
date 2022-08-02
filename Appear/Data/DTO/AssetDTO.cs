using Appear.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.DTO
{
    [Table("assets")]
    public class AssetDTO
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("folderId")]
        public int FolderId { get; set; }

        [Column("filetypeId")]
        public int FileTypeId { get; set; }
    }
}
