using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class ModuleChild
    {
        public long Id { get; set; }
        public long ModuleId{ get; set; }
        public long UserId { get; set; }
        public long ModuleTestId { get; set; }

        public virtual Module Module { get; set; }
        public virtual ModuleTest ModuleTest { get; set; }
        public virtual User Users { get; set; }
    }
}
