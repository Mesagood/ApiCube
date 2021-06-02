using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class LessionChild
    {
        public long Id { get; set; }
        public long LessionId{ get; set; }
        public long GroupChildId{ get; set; }
        public long NumberClassroom{ get; set; }
        public DateTime DateTimeChild{ get; set; }

        public virtual GroupChild GroupChild { get; set; }
        public virtual Lession Lession { get; set; }
    }
}
