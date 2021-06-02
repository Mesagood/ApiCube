using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class ConnectionGroup
    {
        public long Id{ get; set; }
        public string NameGroups { get; set; }
        public string Certificate { get; set; }

        public virtual ICollection<Group> Group { get; set; }

    }
}
