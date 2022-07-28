using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Domain
{
    [Table("assets")]
    public class Asset
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("path")]
        public string Path { get; set; }

        [Column("filetypeId")]
        public int FileTypeId { get; set; }

        [ForeignKey("FileTypeId")]
        public FileType FileType { get; set; }

        public ICollection<AssetTag> AssetTags { get; set; }
        public ICollection<SceneAsset> SceneAssets { get; set; }
    }
}
