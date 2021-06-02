using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class Lession
    {
        public long Id { get; set; }
        public string NameLessions { get; set; }
        public string Status { get; set; }

        public virtual ICollection<LessionChild> LessionChild { get; set; }
        public virtual ICollection<LessionEmployee> LessionEmployee{ get; set; }
    }
}
