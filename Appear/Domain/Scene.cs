using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Domain
{
    public class Scene
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<int> Assets_Ids { get; set; }
    }
}
