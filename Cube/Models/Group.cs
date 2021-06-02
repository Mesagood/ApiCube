using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class Group
    {
        public long Id { get; set; }
        public long NumGroup { get; set; }
        public string Status { get; set; }

        public virtual ICollection<GroupChild> GroupChild{ get; set; }
    }
}
