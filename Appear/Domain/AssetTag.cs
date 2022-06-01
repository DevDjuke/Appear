using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Domain
{
    public class AssetTag
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public int TagId { get; set; }
    }
}
