using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class CinChild
    {
        public long Id { get; set; }
        public string NameCin { get; set; }

        public virtual ICollection<TestQuest> TestQuest { get; set; }
    }
}
