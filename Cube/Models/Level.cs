using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class Level
    {
        public long Id{ get; set; }
        public string NameLevel{ get; set; }

        public virtual ICollection<Event> Event { get; set; }
    }
}
