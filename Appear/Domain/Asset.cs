using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Domain
{
    public class Asset
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public int FileTypeId { get; set; }
    }
}
