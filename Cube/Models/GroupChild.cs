using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class GroupChild
    {
        public long Id { get; set; }
        public long GroupId{ get; set; }
        public long ChildId { get; set; }

        public virtual Child Child { get; set; }
        public virtual Group Group { get; set; }

        public virtual ICollection<LessionChild> LessionChild { get; set; }
    }
}
