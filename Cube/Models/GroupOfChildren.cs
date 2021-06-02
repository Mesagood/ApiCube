using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class GroupOfChildren
    {
        public long Id{ get; set; }
        public long GroupsOfId { get; set; }
        public long ChildOfId { get; set; }

        public virtual Child Child { get; set; }
        public virtual Group Group { get; set; }
    }
}
