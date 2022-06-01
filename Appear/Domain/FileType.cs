using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Domain
{
    public class FileType
    {
        public int Id { get; set; }
        public string Extension { get; set; }

        public int MediaTypeId { get; set; }
    }
}
