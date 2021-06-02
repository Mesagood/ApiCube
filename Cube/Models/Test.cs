using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class Test
    {
        public long Id { get; set; }
        public string NameTest { get; set; }

        public virtual ICollection<TestQuest> TestQuest { get; set; }
    }
}
