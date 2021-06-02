using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class ModuleTest
    {
        public long Id { get; set; }

        public virtual ICollection<ModuleChild> ModuleChild { get; set; }
        public virtual ICollection<TestQuest> TestQuest { get; set; }
    }
}
