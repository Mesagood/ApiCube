using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class SelectGroup
    {
        public long Id { get; set; }
        public long ChildId{ get; set; }
        public long GroupId { get; set; }
        public string Certificate{ get; set; }

        public virtual Child Child { get; set; }
        public virtual Groups Groups { get; set; }

    }
}
