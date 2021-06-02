using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class Module
    {
        public long Id { get; set; }
        public string ModulesName { get; set; }

        public virtual ICollection<ModuleChild> ModuleChild { get; set; }
    }
}
