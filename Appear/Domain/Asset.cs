using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Domain
{
    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int FolderId { get; set; }
        public int FileTypeId { get; set; }
    }
}
